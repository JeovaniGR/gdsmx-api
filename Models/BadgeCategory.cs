using System;
using System.Collections.Generic;

namespace gdsmx_back_netcoreAPI.Models
{
    /// <summary>
    /// Badge category
    /// </summary>
    public partial class BadgeCategory
    {
        public BadgeCategory()
        {
            BadgeTopics = new HashSet<BadgeTopic>();
        }

        /// <summary>
        /// Id of the table
        /// </summary>
        public int IdBadgeCategory { get; set; }
        /// <summary>
        /// Description
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

        public virtual ICollection<BadgeTopic> BadgeTopics { get; set; }
    }
}
