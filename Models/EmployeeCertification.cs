using System;
using System.Collections.Generic;

namespace gdsmx_back_netcoreAPI.Models
{
    /// <summary>
    /// Relation between an employee and his/her certifications
    /// </summary>
    public partial class EmployeeCertification
    {
        /// <summary>
        /// Id of the table
        /// </summary>
        public int IdEmployeeCertification { get; set; }
        /// <summary>
        /// Id of the Certification
        /// </summary>
        public int IdCertification { get; set; }
        /// <summary>
        /// Id of the Employee
        /// </summary>
        public int IdEmployee { get; set; }
        /// <summary>
        /// Date of when the certification was obtained
        /// </summary>
        public DateTime ObtainedDate { get; set; }
        /// <summary>
        /// Date of certification&apos;s expiration date
        /// </summary>
        public DateTime? ExpirationDate { get; set; }
        /// <summary>
        /// Id of who created the row
        /// </summary>
        public int? IdCreated { get; set; }
        /// <summary>
        /// Creation date of the row
        /// </summary>
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// Id of who updated the row
        /// </summary>
        public int? IdUpdated { get; set; }
        /// <summary>
        /// Last updated date
        /// </summary>
        public DateTime? LastUpdatedDate { get; set; }

        public virtual CertificationCatalog IdCertificationNavigation { get; set; } = null!;
        public virtual Employee IdEmployeeNavigation { get; set; } = null!;
    }
}
