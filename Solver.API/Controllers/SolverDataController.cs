using Microsoft.AspNetCore.Mvc;
using Solver.API.Helpers;
using Solver.API.Models;
using Solver.API.Services;
using Solver.Service;

namespace Solver.API.Controllers
{
    [ApiController]
    [Route("api/")]
    [Produces("application/json")]
    public class SolverDataController : ControllerBase
    {
        private readonly ILogger<SolverDataController> logger;
        private readonly ISolverService solverService;
        private readonly IUriService uriService;

        public SolverDataController(ILogger<SolverDataController> logger, ISolverService solverService, IUriService uriService)
        {
            this.logger = logger;
            this.solverService = solverService;
            this.uriService = uriService;
        }

        [HttpGet]
        [Route("{databaseId}/data/{schema}/{tableName}")]
        public async Task<IActionResult> GetTableData([FromQuery] Pagination pagination, string databaseId, string schema, string tableName)
        {
            var data = await solverService.GetDataAsDictionary(databaseId, schema, tableName);

            if (data == null)
            {
                return Ok(new SolverResponse<string>
                {
                    Succeeded = false,
                    Message = "No records found."
                });
            }

            var filter = new Pagination(pagination.PageNumber, pagination.PageSize);
            var pagedData = data.Skip((filter.PageNumber - 1) * filter.PageSize).Take(filter.PageSize);
            var pagedResponse = PaginationHelper.CreatePagedResponse(pagedData.ToList(), filter, data.ToList().Count, uriService, Request.Path.Value);
            pagedResponse.Columns = PaginationHelper.GetColumns(pagedData.ToList());

            return Ok(pagedResponse);
        }

        [HttpPost]
        [Route("{databaseId}/data/{schema}/{tableName}")]
        public async Task<IActionResult> GenerateCSV(string databaseId, string schema, string tableName)
        {
            var fileNameAndPath = @"C:\results.csv";
            var data = await solverService.GetDataAsObjects(databaseId, schema, tableName);
            var (isGenerated, message) = await solverService.GenerateCSV(data, fileNameAndPath);
            var response = new SolverResponse<string>
            {
                Succeeded = isGenerated,
                Message = message
            };
            return Ok(response);
        }
    }
}