namespace Solver.Service
{
    public interface ISolverService
    {
        Task<IEnumerable<IDictionary<string, object>>> GetDataAsDictionary(string databaseId, string schema, string tableName);
        Task<IEnumerable<object>> GetDataAsObjects(string databaseId, string schema, string tableName);
        Task<IEnumerable<string>> GetCustomColumnsForCustomerById(Guid customerId);
        Task<(bool, string)> GenerateCSV(IEnumerable<object> results, string fileNameAndPath);
    }
}
