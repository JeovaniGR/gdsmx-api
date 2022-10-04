using System;
using System.Collections.Generic;

namespace gdsmx_back_netcoreAPI.Models
{
    /// <summary>
    /// Person Segment Catalog
    /// </summary>
    public partial class PersonSegmentCatalog
    {
        public PersonSegmentCatalog()
        {
            Employees = new HashSet<Employee>();
        }

        /// <summary>
        /// Id of the table
        /// </summary>
        public int IdPersonSegmentCatalog { get; set; }
        /// <summary>
        /// Name of the Person Segment
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
        /// Created date of the row
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

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
