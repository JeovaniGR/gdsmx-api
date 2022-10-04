using System;
using System.Collections.Generic;

namespace gdsmx_back_netcoreAPI.Models
{
    /// <summary>
    /// Relation between the badge courses and the employee
    /// </summary>
    public partial class BadgeCourseEmployee
    {
        /// <summary>
        /// Id principal of the table
        /// </summary>
        public int IdBadgeCourseEmployee { get; set; }
        /// <summary>
        /// Id of the employee
        /// </summary>
        public int IdEmployee { get; set; }
        /// <summary>
        /// Id of the domain
        /// </summary>
        public int IdBadgeDomain { get; set; }
        /// <summary>
        /// Id of the subdomain
        /// </summary>
        public int IdBadgeSubDomain { get; set; }
        /// <summary>
        /// Id of the topic
        /// </summary>
        public int IdBadgeTopic { get; set; }
        /// <summary>
        /// Id of the course
        /// </summary>
        public int IdBadgeCourse { get; set; }
        /// <summary>
        /// Id fo the level of the badge
        /// </summary>
        public int IdBadgeLevel { get; set; }
        /// <summary>
        /// Id of the status 
        /// </summary>
        public int IdBadgeStatus { get; set; }
        /// <summary>
        /// Comments
        /// </summary>
        public string? Comments { get; set; }
        /// <summary>
        /// Start date of the badge
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// End date of the badge
        /// </summary>
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// Creation date
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// Id of who created the row
        /// </summary>
        public int? IdCreated { get; set; }
        /// <summary>
        /// Id of who updated the row
        /// </summary>
        public int? IdUpdated { get; set; }
        /// <summary>
        /// Last updated date
        /// </summary>
        public DateTime? LastUpdatedDate { get; set; }

        public virtual BadgeCourse IdBadgeCourseNavigation { get; set; } = null!;
        public virtual BadgeDomain IdBadgeDomainNavigation { get; set; } = null!;
        public virtual BadgeLevel IdBadgeLevelNavigation { get; set; } = null!;
        public virtual BadgeStatus IdBadgeStatusNavigation { get; set; } = null!;
        public virtual BadgeSubDomain IdBadgeSubDomainNavigation { get; set; } = null!;
        public virtual BadgeTopic IdBadgeTopicNavigation { get; set; } = null!;
        public virtual Employee IdEmployeeNavigation { get; set; } = null!;
    }
}
