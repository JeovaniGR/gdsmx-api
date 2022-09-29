using System;
using System.Collections.Generic;

namespace gdsmx_back_netcoreAPI.Models
{
    /// <summary>
    /// Relation between all the levels of one employee on the time
    /// </summary>
    public partial class EmployeeLevel
    {
        /// <summary>
        /// Id Employee
        /// </summary>
        public int IdEmployee { get; set; }
        /// <summary>
        /// Id Level Catalog
        /// </summary>
        public int IdLevel { get; set; }
        /// <summary>
        /// Indicate if the row is active
        /// </summary>
        public bool? IsActive { get; set; }
        /// <summary>
        /// Id of who created the row
        /// </summary>
        public int? IdCreated { get; set; }
        /// <summary>
        /// Creation date of the row
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

        public virtual Employee IdEmployeeNavigation { get; set; } = null!;
        public virtual LevelCatalog IdLevelNavigation { get; set; } = null!;
    }
}
