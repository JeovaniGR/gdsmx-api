using System;
using System.Collections.Generic;

namespace gdsmx_back_netcoreAPI.Models
{
    /// <summary>
    /// Sub category of the principal catalog
    /// </summary>
    public partial class GenericSubCatalog
    {
        public GenericSubCatalog()
        {
            Employees = new HashSet<Employee>();
        }

        /// <summary>
        /// Id Sub-catalog
        /// </summary>
        public int IdGenericSubCatalog { get; set; }
        /// <summary>
        /// Id catalog
        /// </summary>
        public int IdGenericCatalog { get; set; }
        /// <summary>
        /// Description of the sub-catalog
        /// </summary>
        public string Description { get; set; } = null!;
        /// <summary>
        /// Order of the sub-catalog
        /// </summary>
        public int? Position { get; set; }
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

        public virtual GenericCatalog IdGenericCatalogNavigation { get; set; } = null!;
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
