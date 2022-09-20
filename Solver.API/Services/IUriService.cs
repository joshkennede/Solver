using Solver.API.Models;

namespace Solver.API.Services
{
    public interface IUriService
    {
        Uri GetPageUri(Pagination pagination, string route);
        Uri SetPageUri(Pagination pagination, int totalPages, string route);
    }
}
