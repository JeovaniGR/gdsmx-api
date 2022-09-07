using System;
using System.Collections.Generic;

namespace gdsmx_back_netcoreAPI.Models
{
    public partial class Employee
    {
        /// <summary>
        /// Id Employee
        /// </summary>
        public int IdEmployee { get; set; }
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
        /// Joined date of the employee on the firm
        /// </summary>
        public DateTime JoinedDate { get; set; }
        /// <summary>
        /// GPN number
        /// </summary>
        public string? Gpn { get; set; }
        /// <summary>
        /// Birthdate
        /// </summary>
        public DateTime? Birthdate { get; set; }
        /// <summary>
        /// Creation date of the row
        /// </summary>
        public DateTime CreateDate { get; set; }
    }
}
