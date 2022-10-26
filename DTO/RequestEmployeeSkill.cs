namespace gdsmx_back_netcoreAPI.DTO
{
    public class RequestEmployeeSkill
    {
        public RequestEmployeeSkill()
        {
            Page = 1;
            PageSize = 1;
        }
        public int Option { get; set; }
        public string? Skill { get; set; }
        public string? Rank { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
