using System;
using System.Collections.Generic;

namespace gdsmx_back_netcoreAPI.Models
{
    /// <summary>
    /// Catalog of certifications
    /// </summary>
    public partial class CertificationCatalog
    {
        public CertificationCatalog()
        {
            EmployeeCertifications = new HashSet<EmployeeCertification>();
        }

        /// <summary>
        /// Id of the table
        /// </summary>
        public int IdCertificationCatalog { get; set; }
        /// <summary>
        /// Name of the institution that grants the certification
        /// </summary>
        public string Institution { get; set; } = null!;
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; } = null!;
        /// <summary>
        /// Indicates if the record is active or not
        /// </summary>
        public bool IsActive { get; set; }
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

        public virtual ICollection<EmployeeCertification> EmployeeCertifications { get; set; }
    }
}
