namespace gdsmx_back_netcoreAPI.DTO
{
    public class RequestEmployee
    {
        public string GPN { get; set; }
        public int IdEmployee { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string? Competency { get; set; }
	    public string? Level { get; set; }
	    public string? Status { get; set; }
    }
}
