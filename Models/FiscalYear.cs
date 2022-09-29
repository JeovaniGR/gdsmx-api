using System;
using System.Collections.Generic;

namespace gdsmx_back_netcoreAPI.Models
{
    /// <summary>
    /// Fiscal year management
    /// </summary>
    public partial class FiscalYear
    {
        /// <summary>
        /// Id of the table
        /// </summary>
        public int IdFiscalYear { get; set; }
        /// <summary>
        /// Id of the location
        /// </summary>
        public int IdLocation { get; set; }
        /// <summary>
        /// Start date of the year
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// End date of the year
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// Indicate if the row is active
        /// </summary>
        public bool IsActive { get; set; }
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
