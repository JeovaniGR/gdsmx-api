using System;
using System.Collections.Generic;

namespace gdsmx_back_netcoreAPI.Models
{
    /// <summary>
    /// Sub level catalog of the employee
    /// </summary>
    public partial class LevelSubCatalog
    {
        public LevelSubCatalog()
        {
            EmployeeLevels = new HashSet<EmployeeLevel>();
        }

        /// <summary>
        /// Id of the catalog
        /// </summary>
        public int IdLevelSubCatalog { get; set; }
        /// <summary>
        /// Id of the principal catalog (Level Catalog)
        /// </summary>
        public int IdLevelCatalog { get; set; }
        /// <summary>
        /// Grade
        /// </summary>
        public string Grade { get; set; } = null!;
        /// <summary>
        /// Indicate if the row is active
        /// </summary>
        public bool? IsActive { get; set; }
        /// <summary>
        /// Id who create the row
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
        /// Date of the last updated day
        /// </summary>
        public DateTime? LastUpdatedDate { get; set; }

        public virtual LevelCatalog IdLevelCatalogNavigation { get; set; } = null!;
        public virtual ICollection<EmployeeLevel> EmployeeLevels { get; set; }
    }
}
