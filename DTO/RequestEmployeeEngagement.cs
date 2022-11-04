namespace gdsmx_back_netcoreAPI.DTO
{
    /// <summary>
    /// DTO class for employee's Engagement data requests
    /// </summary>
    public class RequestEmployeeEngagement
    {
        /// <summary>
        /// RequestEmployeeCertification class constructor with default values
        /// </summary>
        public RequestEmployeeEngagement()
        {
            Page = 1;
            PageSize = 1;
        }
        
        /// <summary>
        /// Starting status to filter. Default value:  Status Employee.
        /// </summary>
        public int IdEmployeeStatus { get; set; }
        /// <summary>
        /// Starting amount weeks to filter. Amount weeks before end engagement.
        /// </summary>
        public int WeeksBeforeEnd { get; set; }      
        /// <summary>
        /// Current page number. Default value: 1
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// Size of current page. Default value: 1
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// Is active Engagement. Default value: 0
        /// </summary>
        public int IsActive { get; set; }


    }
}
