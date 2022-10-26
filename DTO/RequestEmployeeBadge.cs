namespace gdsmx_back_netcoreAPI.DTO
{
    public class RequestEmployeeBadge
    {
        public string? Level { get; set; }
        public string? Status { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }

        public RequestEmployeeBadge()
        {
            Page = 1;
            PageSize = 1;
        }
    }
}
