using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace Solver.Repository
{
    public class SolverRepository : ISolverRepository
    {
        private readonly ConnectionString connectionString;

        public SolverRepository(ConnectionString connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<IEnumerable<string>> GetCustomerColumnName(string databaseId, string schema, string tableName)
        {
            var tableExists = await VerifyTableExists(databaseId, schema, tableName);
            if (tableExists)
            {
                var sqlQuery = $"SELECT CustomerColumnName FROM [Customer.ColumnMap] WHERE TableName = @tableName";
                using (IDbConnection db = new SqlConnection(connectionString.Value))
                {
                    var data = db.Query<string>(sqlQuery, new { tableName });
                    return data;
                }
            }
            return Enumerable.Empty<string>();
        }

        public async Task<IEnumerable<IDictionary<string, object>>?> GetDataAsDictionary(string databaseId, string schema, string tableName)
        {
            var tableExists = await VerifyTableExists(databaseId, schema, tableName);
            if (tableExists)
            {
                var sqlQuery = $"SELECT * FROM {databaseId}.{schema}.{tableName}";

                using (IDbConnection db = new SqlConnection(connectionString.Value))
                {
                    var data = db.Query(sqlQuery) as IEnumerable<IDictionary<string, object>>;
                    return data?.Select(row => row.ToDictionary(k => k.Key, v => v.Value));
                }
            }
            else
                return null;
        }

        public async Task<IEnumerable<object>?> GetDataAsObjects(string databaseId, string schema, string tableName)
        {
            var tableExists = await VerifyTableExists(databaseId, schema, tableName);
            if (tableExists)
            {
                var sqlQuery = $"SELECT * FROM {databaseId}.{schema}.{tableName}";

                using (IDbConnection db = new SqlConnection(connectionString.Value))
                {
                    return db.Query(sqlQuery);
                }
            }
            else
                return null;
        }

        private async Task<bool> VerifyTableExists(string databaseId, string schema, string tableName)
        {
            var sqlQuery = $"USE {databaseId} SELECT * FROM information_schema.tables WHERE TABLE_SCHEMA IN ('{schema}') AND TABLE_NAME IN ('{tableName}')";

            using (IDbConnection db = new SqlConnection(connectionString.Value))
            {
                var result = await db.QueryAsync<object>(sqlQuery);
                return result.Count() > 0 ? true : false;
            }
        }
    }
}