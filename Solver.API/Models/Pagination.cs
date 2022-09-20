namespace Solver.API.Models
{
    public class Pagination
    {
        public Pagination()
        {
            PageNumber = 1;
            PageSize = 10;
        }

        public Pagination(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageSize < 100 && pageSize > 0 ? pageSize : 10;
        }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
