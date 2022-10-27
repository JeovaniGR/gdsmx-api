namespace gdsmx_back_netcoreAPI.DTO
{
    /// <summary>
    /// DTO class for employees data requests
    /// </summary>
    public class RequestEmployee
    {   
        /// <summary>
        /// RequestEmployee class constructor with default values
        /// </summary>
        public RequestEmployee()
        {
            GPN = "";
            IdEmployee = 0;
            Page = 1;
            PageSize = 1;
        }
        /// <summary>
        /// Employee's EY ID. Default value: ""
        /// </summary>
        public string GPN { get; set; }
        /// <summary>
        /// Employee's database ID. Default value: 0
        /// </summary>
        public int IdEmployee { get; set; }
        /// <summary>
        /// Current page number. Default value: 1
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// Size of current page. Default value: 1
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// Competency filter
        /// </summary>
        public string? Competency { get; set; }
        /// <summary>
        /// Level filter
        /// </summary>
	    public string? Level { get; set; }
        /// <summary>
        /// Status filter
        /// </summary>
	    public string? Status { get; set; }
    }
}
