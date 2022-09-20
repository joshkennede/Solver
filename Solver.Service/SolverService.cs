using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using Solver.Repository;

namespace Solver.Service
{
    public class SolverService : ISolverService
    {
        private readonly ISolverRepository repository;

        public SolverService(ISolverRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<IDictionary<string, object>>?> GetDataAsDictionary(string databaseId, string schema, string tableName)
        {
            var data = await repository.GetDataAsDictionary(databaseId, schema, tableName);
            if (data != null)
                return data;
            else
                return null;
        }

        public async Task<IEnumerable<object>?> GetDataAsObjects(string databaseId, string schema, string tableName)
        {
            var data = await repository.GetDataAsObjects(databaseId, schema, tableName);
            if (data != null)
                return data;
            else
                return null;
        }

        public Task<IEnumerable<string>> GetCustomColumnsForCustomerById(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public async Task<(bool, string)> GenerateCSV(IEnumerable<object> results, string fileNameAndPath)
        {
            var file = !string.IsNullOrEmpty(fileNameAndPath) ? fileNameAndPath : File.Create(@"C:\results.csv").ToString();
            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
            };

            try
            {
                using (var writer = new StreamWriter(file))
                {
                    using (var csvWriter = new CsvWriter(writer, configuration))
                    {
                        csvWriter.WriteRecords(results);
                        return (true, "Csv file created.");
                    }
                }
            }
            catch (Exception exception)
            {

                return (false, $"An exception was encountered: {exception.Message}");
            }
        }
    }
}