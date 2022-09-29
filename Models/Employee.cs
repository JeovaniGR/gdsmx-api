using System;
using System.Collections.Generic;

namespace gdsmx_back_netcoreAPI.Models
{
    /// <summary>
    /// Principal table of the employee
    /// </summary>
    public partial class Employee
    {
        public Employee()
        {
            BadgeCourseEmployees = new HashSet<BadgeCourseEmployee>();
            Engagements = new HashSet<Engagement>();
        }

        /// <summary>
        /// Id Employee
        /// </summary>
        public int IdEmployee { get; set; }
        /// <summary>
        /// GPN number
        /// </summary>
        public string? Gpn { get; set; }
        /// <summary>
        /// First name of the employee
        /// </summary>
        public string FirstName { get; set; } = null!;
        /// <summary>
        /// Middle name of the employee
        /// </summary>
        public string? MiddleName { get; set; }
        /// <summary>
        /// Last name of the employee
        /// </summary>
        public string LastName { get; set; } = null!;
        /// <summary>
        /// Second lastname
        /// </summary>
        public string? SecondLastName { get; set; }
        /// <summary>
        /// Prefered name of the employee
        /// </summary>
        public string? PreferredName { get; set; }
        /// <summary>
        /// Birthdate
        /// </summary>
        public DateTime? Birthdate { get; set; }
        /// <summary>
        /// Email of the employee
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// Joined date of the employee on the firm
        /// </summary>
        public DateTime JoinedDate { get; set; }
        /// <summary>
        /// Indicate if the employee is a counselor
        /// </summary>
        public bool? IsCounselor { get; set; }
        /// <summary>
        /// Id of the counselor
        /// </summary>
        public int? IdCounselor { get; set; }
        /// <summary>
        /// Id of the location of the office
        /// </summary>
        public int? IdLocation { get; set; }
        /// <summary>
        /// Id of the person segment catalog
        /// </summary>
        public int? IdPersonSegment { get; set; }
        /// <summary>
        /// Competency of the employee
        /// </summary>
        public int? IdCompetency { get; set; }
        /// <summary>
        /// Status of the employee
        /// </summary>
        public int? IdStatus { get; set; }
        /// <summary>
        /// Notes
        /// </summary>
        public string? Notes { get; set; }
        /// <summary>
        /// Indicate if the row is active
        /// </summary>
        public bool? IsActive { get; set; }
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

        public virtual CompetenciesCatalog? IdCompetencyNavigation { get; set; }
        public virtual PersonSegmentCatalog? IdPersonSegmentNavigation { get; set; }
        public virtual GenericSubCatalog? IdStatusNavigation { get; set; }
        public virtual EmployeeLevel EmployeeLevel { get; set; } = null!;
        public virtual ICollection<BadgeCourseEmployee> BadgeCourseEmployees { get; set; }
        public virtual ICollection<Engagement> Engagements { get; set; }
    }
}
