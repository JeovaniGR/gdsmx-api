using System;
using System.Collections.Generic;

namespace gdsmx_back_netcoreAPI.Models
{
    /// <summary>
    /// Principal table of the generic catalog
    /// </summary>
    public partial class GenericCatalog
    {
        public GenericCatalog()
        {
            GenericSubCatalogs = new HashSet<GenericSubCatalog>();
        }

        /// <summary>
        /// Id Catalog
        /// </summary>
        public int IdGenericCatalog { get; set; }
        /// <summary>
        /// Description of the catalog
        /// </summary>
        public string Description { get; set; } = null!;
        /// <summary>
        /// Comments about the new catalog
        /// </summary>
        public string? Comments { get; set; }
        /// <summary>
        /// Is active the row
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

        public virtual ICollection<GenericSubCatalog> GenericSubCatalogs { get; set; }
    }
}
