using System;
using System.Collections.Generic;

namespace gdsmx_back_netcoreAPI.Models
{
    /// <summary>
    /// Catalog of the sub-domain of the badges like Technology-Cloud
    /// </summary>
    public partial class BadgeSubDomain
    {
        public BadgeSubDomain()
        {
            BadgeCourseEmployees = new HashSet<BadgeCourseEmployee>();
            BadgeCourses = new HashSet<BadgeCourse>();
            BadgeTopics = new HashSet<BadgeTopic>();
        }

        /// <summary>
        /// Id of the table
        /// </summary>
        public int IdBadgeSubDomain { get; set; }
        /// <summary>
        /// Id of the domain
        /// </summary>
        public int IdBadgeDomain { get; set; }
        /// <summary>
        /// Description of the subdomain
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
        public virtual ICollection<BadgeCourseEmployee> BadgeCourseEmployees { get; set; }
        public virtual ICollection<BadgeCourse> BadgeCourses { get; set; }
        public virtual ICollection<BadgeTopic> BadgeTopics { get; set; }
    }
}
