namespace Solver.API.Models
{
    public class SolverResponse<T>
    {
        public SolverResponse() { }

        public SolverResponse(T data)
        {
            Succeeded = true;
            Message = string.Empty;
            Errors = null;
            Data = data;
        }

        public List<string> Columns { get; set; }
        public T Data { get; set; }
        public bool Succeeded { get; set; }
        public string[] Errors { get; set; }
        public string Message { get; set; }
    }
}
