using System;
using System.Collections.Generic;

namespace gdsmx_back_netcoreAPI.Models
{
    public partial class Catalog
    {
        public Catalog()
        {
            SubCatalogs = new HashSet<SubCatalog>();
        }

        /// <summary>
        /// Id Catalog
        /// </summary>
        public int IdCatalog { get; set; }
        /// <summary>
        /// Description of the catalog
        /// </summary>
        public string Description { get; set; } = null!;
        /// <summary>
        /// Is active the row
        /// </summary>
        public bool? IsActive { get; set; }
        /// <summary>
        /// Creation date
        /// </summary>
        public DateTime CreateDate { get; set; }

        public virtual ICollection<SubCatalog> SubCatalogs { get; set; }
    }
}
