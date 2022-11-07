using System.ComponentModel.DataAnnotations;

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
            GPN = string.Empty;
            WeeksBeforeEnd = string.Empty;
            Page = 1;
            PageSize = 1;
            SearchEmployee = string.Empty;
        }

        /// <summary>
        /// Starting GPN to filter.
        /// </summary>
        public string GPN { get; set; }
        /// <summary>
        /// Starting amount weeks to filter. Amount weeks before end engagement.
        /// </summary>
        public string WeeksBeforeEnd { get; set; }
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
        public bool IsActive { get; set; }
        /// <summary>
        /// Engagement status
        /// </summary>
        public string? Status { get; set; }
        /// <summary>
        /// Employee status filter
        /// </summary>
        public string? EmployeeStatus { get; set; }
        /// <summary>
        /// Employee name filter
        /// </summary>
        public string SearchEmployee { get; set; }
    }
}
