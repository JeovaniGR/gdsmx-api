namespace gdsmx_back_netcoreAPI.DTO
{
    /// <summary>
    /// DTO class for employee's badges data requests
    /// </summary>
    public class RequestEmployeeBadge
    {
        /// <summary>
        /// RequestEmployeeBadge class constructor with default values
        /// </summary>
        public RequestEmployeeBadge()
        {
            Page = 1;
            PageSize = 1;
        }
        /// <summary>
        /// Level filter
        /// </summary>
        public string? Level { get; set; }
        /// <summary>
        /// Status filter
        /// </summary>
        public string? Status { get; set; }
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
