using System;
using System.Collections.Generic;

namespace gdsmx_back_netcoreAPI.Models
{
    /// <summary>
    /// Catalog of competencies
    /// </summary>
    public partial class CompetenciesCatalog
    {
        public CompetenciesCatalog()
        {
            Employees = new HashSet<Employee>();
        }

        /// <summary>
        /// Id of the competency
        /// </summary>
        public int IdCompetencyCatalog { get; set; }
        /// <summary>
        /// Name of the competency
        /// </summary>
        public string Description { get; set; } = null!;
        /// <summary>
        /// Indicate if the compentecy is active
        /// </summary>
        public bool? IsActive { get; set; }
        /// <summary>
        /// Id of the user who created the row
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

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
