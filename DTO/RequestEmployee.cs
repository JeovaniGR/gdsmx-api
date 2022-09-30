namespace gdsmx_back_netcoreAPI.DTO
{
    public class RequestEmployee
    {
        public string? GPN { get; set; }
        public int? page { get; set; }
        public int? pageSize { get; set; }
        public string? competency { get; set; }
	    public string? level { get; set; }
	    public string? status { get; set; }
    }
}
