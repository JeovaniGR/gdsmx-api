namespace gdsmx_back_netcoreAPI.DTO
{
    public class RequestEmployee
    {
        public string? GPN { get; set; }
        public string? page { get; set; }
        public string? pageSize { get; set; }
        public string? competency { get; set; }
	    public string? level { get; set; }
	    public string? status { get; set; }
    }
}
