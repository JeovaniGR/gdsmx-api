using System;
using System.Collections.Generic;

namespace gdsmx_back_netcoreAPI.Models
{
    /// <summary>
    /// Catalog of the courses of the badges like Technology-Cloud-Silver Private
    /// </summary>
    public partial class BadgeCourse
    {
        public BadgeCourse()
        {
            BadgeCourseEmployees = new HashSet<BadgeCourseEmployee>();
        }

        /// <summary>
        /// Id of the table
        /// </summary>
        public int IdBadgeCourse { get; set; }
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
        /// Id of the level of the badge
        /// </summary>
        public int IdBadgeLevel { get; set; }
        /// <summary>
        /// Description of the course
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// Indicate if the row is active
        /// </summary>
        public bool? IsActive { get; set; }
        /// <summary>
        /// Id of who created the row
        /// </summary>
        public int? IdCreated { get; set; }
        /// <summary>
        /// Creation date
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

        public virtual BadgeDomain IdBadgeDomainNavigation { get; set; } = null!;
        public virtual BadgeLevel IdBadgeLevelNavigation { get; set; } = null!;
        public virtual BadgeSubDomain IdBadgeSubDomainNavigation { get; set; } = null!;
        public virtual BadgeTopic IdBadgeTopicNavigation { get; set; } = null!;
        public virtual ICollection<BadgeCourseEmployee> BadgeCourseEmployees { get; set; }
    }
}
