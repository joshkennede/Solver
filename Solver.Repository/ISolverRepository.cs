namespace Solver.Repository
{
    public interface ISolverRepository
    {
        Task<IEnumerable<object>?> GetDataAsObjects(string databaseId, string schema, string tableName);
        Task<IEnumerable<IDictionary<string, object>>?> GetDataAsDictionary(string databaseId, string schema, string tableName);
        Task<IEnumerable<string>> GetCustomerColumnName(string databaseId, string schema, string tableName);
    }
}
