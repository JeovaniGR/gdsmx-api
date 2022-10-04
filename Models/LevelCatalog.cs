using System;
using System.Collections.Generic;

namespace gdsmx_back_netcoreAPI.Models
{
    /// <summary>
    /// Level catalog of the employee
    /// </summary>
    public partial class LevelCatalog
    {
        public LevelCatalog()
        {
            EmployeeLevels = new HashSet<EmployeeLevel>();
            LevelSubCatalogs = new HashSet<LevelSubCatalog>();
        }

        /// <summary>
        /// Id Level Catalog
        /// </summary>
        public int IdLevelCatalog { get; set; }
        /// <summary>
        /// Rank
        /// </summary>
        public int Rank { get; set; }
        /// <summary>
        /// Level
        /// </summary>
        public string Level { get; set; } = null!;
        /// <summary>
        /// Indicate if the row is active
        /// </summary>
        public bool? IsActive { get; set; }
        /// <summary>
        /// Id of who created the row
        /// </summary>
        public int? IdCreated { get; set; }
        /// <summary>
        /// Create date of the row
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

        public virtual ICollection<EmployeeLevel> EmployeeLevels { get; set; }
        public virtual ICollection<LevelSubCatalog> LevelSubCatalogs { get; set; }
    }
}
