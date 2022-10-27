namespace gdsmx_back_netcoreAPI.DTO
{
    /// <summary>
    /// DTO class for employee's certification data requests
    /// </summary>
    public class RequestEmployeeCertification
    {
        /// <summary>
        /// RequestEmployeeCertification class constructor with default values
        /// </summary>
        public RequestEmployeeCertification()
        {
            Page = 1;
            PageSize = 1;
            Option = 0;
            StartDate = DateTime.Now;
            EndDate = DateTime.Now.AddDays(1);
        }

        /// <summary>
        /// Option filter: 0 without filter, 1 will filter by start date, 2 will filter by ending date. Default: 0
        /// </summary>
        public int Option { get; set; }
        /// <summary>
        /// Starting date to filter. Default value: current date.
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// Starting date to filter. Default value: current date plus one day.
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// Certification filter
        /// </summary>
        public string? Certification { get; set; }
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
