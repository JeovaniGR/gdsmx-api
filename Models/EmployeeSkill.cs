using System;
using System.Collections.Generic;

namespace gdsmx_back_netcoreAPI.Models
{
    /// <summary>
    /// Relation between an employee and his/her skills
    /// </summary>
    public partial class EmployeeSkill
    {
        /// <summary>
        /// Id Employee Skill
        /// </summary>
        public int IdEmployeeSkills { get; set; }
        /// <summary>
        /// Id Employee
        /// </summary>
        public int IdEmployee { get; set; }
        /// <summary>
        /// Id Skill
        /// </summary>
        public int IdSkill { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// Id Rank
        /// </summary>
        public int? IdRank { get; set; }
        /// <summary>
        /// Indicate if the skill is a primary skill
        /// </summary>
        public bool IsPrimarySkill { get; set; }
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

        public virtual Employee IdEmployeeNavigation { get; set; } = null!;
        public virtual GenericSubCatalog? IdRankNavigation { get; set; }
    }
}
