namespace Solver.Service
{
    public interface ISolverService
    {
        Task<IEnumerable<IDictionary<string, object>>> GetDataAsDictionary(string databaseId, string schema, string tableName);
        Task<IEnumerable<object>> GetDataAsObjects(string databaseId, string schema, string tableName);
        Task<IEnumerable<string>> GetCustomColumnsForCustomerByTableName(string databaseId, string schema, string tableName);
        Task<(bool, string)> GenerateCSV(IEnumerable<object> results, string fileNameAndPath);
    }
}
