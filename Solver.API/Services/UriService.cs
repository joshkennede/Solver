using Solver.API.Models;
using Microsoft.AspNetCore.WebUtilities;

namespace Solver.API.Services
{
    public class UriService : IUriService
    {
        private readonly string baseUri;

        public UriService(string baseUri)
        {
            this.baseUri = baseUri;
        }

        public Uri GetPageUri(Pagination pagination, string route)
        {
            var endpointUri = new Uri(string.Concat(baseUri, route));
            var modifiedUri = QueryHelpers.AddQueryString(endpointUri.ToString(), "pageNumber", pagination.PageNumber.ToString());
            modifiedUri = QueryHelpers.AddQueryString(modifiedUri, "pageSize", pagination.PageSize.ToString());
            return new Uri(modifiedUri);
        }

        public Uri SetPageUri(Pagination pagination, int totalPages, string route)
        {
            if (pagination.PageNumber >= 1 && pagination.PageNumber < totalPages)
                return GetPageUri(new Pagination(pagination.PageNumber + 1, pagination.PageSize), route);
            else if (pagination.PageNumber - 1 >= 1 && pagination.PageNumber <= totalPages)
                return GetPageUri(new Pagination(pagination.PageNumber - 1, pagination.PageSize), route);
            else
                return null;
        }
    }
}
