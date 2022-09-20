using Solver.API.Models;
using Solver.API.Services;

namespace Solver.API.Helpers
{
    public static class PaginationHelper
    {
        public static SolverPagedResponse<List<T>> CreatePagedResponse<T>
            (List<T> pagedData,
            Pagination pagination,
            int totalRecords,
            IUriService uriService,
            string route)
        {
            var response = new SolverPagedResponse<List<T>>(pagedData, pagination.PageNumber, pagination.PageSize);
            var totalPages = ((double)totalRecords / (double)pagination.PageSize);
            var roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));

            response.NextPage = uriService.SetPageUri(pagination, roundedTotalPages, route);
            response.PreviousPage = uriService.SetPageUri(pagination, roundedTotalPages, route);
            response.FirstPage = uriService.GetPageUri(new Pagination(1, pagination.PageSize), route);
            response.LastPage = uriService.GetPageUri(new Pagination(roundedTotalPages, pagination.PageSize), route);
            response.TotalPages = roundedTotalPages;
            response.TotalRecords = totalRecords;
            return response;
        }

        public static List<string> GetColumns(IEnumerable<IDictionary<string, object>> data)
            => data.SelectMany(d => d.Keys).Distinct().ToList();
    }
}