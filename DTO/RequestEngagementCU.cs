using System.ComponentModel.DataAnnotations;

namespace gdsmx_back_netcoreAPI.DTO
{
    /// <summary>
    /// DTO class to create/update engagement's data
    /// </summary>
    public class RequestEngagementCU
    { 
        /// <summary>
        /// Engagement description
        /// </summary>
        [Required]
        public string Description {get; set;}
        /// <summary>
        /// Customer name
        /// </summary>
        public string CustomerName {get; set;}
        /// <summary>
        /// Project name
        /// </summary>
        public string ProjectName {get; set;}
        /// <summary>
        /// GDS engagement ID
        /// </summary>
        public string EngagementId {get; set;}
        /// <summary>
        /// Projct manager name
        /// </summary>
        public string ProjectManagerName {get; set;}
        /// <summary>
        /// Project manager email
        /// </summary>
        public string ProjectManagerEmail {get; set;}
        /// <summary>
        /// Engagement start date
        /// </summary>
        [Required]
        public DateTime StartDate {get; set;}
        /// <summary>
        /// Engagement end date
        /// </summary>
        [Required]
        public DateTime EndDate {get; set;}

        /// <summary>
        /// Engagement register status
        /// </summary>
        public bool IsActive {get; set;}
    }
}
