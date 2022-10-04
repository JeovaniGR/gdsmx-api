using System;
using System.Collections.Generic;

namespace gdsmx_back_netcoreAPI.Models
{
    /// <summary>
    /// Indicates all the engagement of the employee
    /// </summary>
    public partial class Engagement
    {
        public Engagement()
        {
            InverseIdParentNavigation = new HashSet<Engagement>();
        }

        /// <summary>
        /// Id of the engagement
        /// </summary>
        public int IdEngagement { get; set; }
        /// <summary>
        /// Id employee
        /// </summary>
        public int IdEmployee { get; set; }
        /// <summary>
        /// Name of the engagement
        /// </summary>
        public string Description { get; set; } = null!;
        /// <summary>
        /// Id of the previous engagement
        /// </summary>
        public int? IdParent { get; set; }
        /// <summary>
        /// Starting date of the engagement
        /// </summary>
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// Ending date of the engagement
        /// </summary>
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// Is active the row
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

        public virtual Employee IdEmployeeNavigation { get; set; } = null!;
        public virtual Engagement? IdParentNavigation { get; set; }
        public virtual ICollection<Engagement> InverseIdParentNavigation { get; set; }
    }
}
