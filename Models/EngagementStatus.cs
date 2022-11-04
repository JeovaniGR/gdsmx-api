using System;
using System.Collections.Generic;

namespace gdsmx_back_netcoreAPI.Models
{
    /// <summary>
    /// Catalog of the status of the engaement like Open, Close,Cancel and Pending
    /// </summary>
    public partial class EngagementStatus
    {
        /// <summary>
        /// Id of the table
        /// </summary>
        public int IdEngagementStatus { get; set; }
        /// <summary>
        /// Description of the status
        /// </summary>
        public string Description { get; set; } = null!;
        /// <summary>
        /// Indicate if the row is active
        /// </summary>
        public bool? IsActive { get; set; }
        /// <summary>
        /// Id of who created the row
        /// </summary>
        public int? IdCreated { get; set; }
        /// <summary>
        /// Creation date
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// Id of who updated the row
        /// </summary>
        public int? IdUpdated { get; set; }
        /// <summary>
        /// Last updated date
        /// </summary>
        public DateTime? LastUpdatedDate { get; set; }
    }
}
