namespace gdsmx_back_netcoreAPI.DTO
{
    public class RequestEmployeeSkill
    {
        public RequestEmployeeSkill()
        {
            IdEmployee = 0;
            Page = 1;
            PageSize = 1;
        }
        public int IdEmployee { get; set; }
        public int Option { get; set; }
        public string? Skill { get; set; }
        public string? Rank { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
