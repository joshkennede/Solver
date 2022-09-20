using Microsoft.AspNetCore.Mvc;

namespace Solver.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SolverDataController : ControllerBase
    {
        private readonly ILogger<SolverDataController> _logger;

        public SolverDataController(ILogger<SolverDataController> logger)
        {
            _logger = logger;
        }
    }
}