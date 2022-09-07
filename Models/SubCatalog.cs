using System;
using System.Collections.Generic;

namespace gdsmx_back_netcoreAPI.Models
{
    public partial class SubCatalog
    {
        /// <summary>
        /// Id Sub-catalog
        /// </summary>
        public int IdSubCatalog { get; set; }
        /// <summary>
        /// Id catalog
        /// </summary>
        public int IdCatalog { get; set; }
        /// <summary>
        /// Description of the sub-catalog
        /// </summary>
        public string Description { get; set; } = null!;
        /// <summary>
        /// Order of the sub-catalog
        /// </summary>
        public int? Order { get; set; }
        public bool? IsActive { get; set; }
        /// <summary>
        /// Creation date
        /// </summary>
        public DateTime CreateDate { get; set; }

        public virtual Catalog IdCatalogNavigation { get; set; } = null!;
    }
}
