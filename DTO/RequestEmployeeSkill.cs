namespace gdsmx_back_netcoreAPI.DTO
{
    /// <summary>
    /// DTO class for employee's skills data requests
    /// </summary>
    public class RequestEmployeeSkill
    {
        /// <summary>
        /// RquestEmployeeSkill class constructor with default values
        /// </summary>
        public RequestEmployeeSkill()
        {
            Page = 1;
            PageSize = 1;
            Option = 2;
        }
        /// <summary>
        /// Option filter: 2 without primary/secondary skill, 1 is primary, 0 is secondary. Default value: 2
        /// </summary>
        public int Option { get; set; }
        /// <summary>
        /// Skill filter
        /// </summary>
        public string? Skill { get; set; }
        /// <summary>
        /// Rank filter
        /// </summary>
        public string? Rank { get; set; }
        /// <summary>
        /// Current page number. Default value: 1
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// Size of current page. Default value: 1
        /// </summary>
        public int PageSize { get; set; }
    }
}
