namespace Solver.Service
{
    public class SolverService : ISolverService
    {
        public Task<(bool, string)> GenerateCSV(IEnumerable<object> results, string fileNameAndPath)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> GetCustomColumnsForCustomerById(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IDictionary<string, object>>> GetDataAsDictionary(string databaseId, string schema, string tableName)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<object>> GetDataAsObjects(string databaseId, string schema, string tableName)
        {
            throw new NotImplementedException();
        }
    }
}