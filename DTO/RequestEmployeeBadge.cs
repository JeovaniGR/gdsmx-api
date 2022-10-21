namespace gdsmx_back_netcoreAPI.DTO
{
    public class RequestEmployeeBadge
    {
        public int IdEmployee { get; set; }
        public string? Level { get; set; }
        public string? Status { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }

        public RequestEmployeeBadge()
        {
            IdEmployee = 0;
            Page = 1;
            PageSize = 1;
        }
    }
}
