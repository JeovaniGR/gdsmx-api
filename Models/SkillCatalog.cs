using System;
using System.Collections.Generic;

namespace gdsmx_back_netcoreAPI.Models
{
    /// <summary>
    /// Catalog of the skills
    /// </summary>
    public partial class SkillCatalog
    {
        /// <summary>
        /// Id Primary Skill
        /// </summary>
        public int IdSkillCatalog { get; set; }
        /// <summary>
        /// Description of the Primary Skill
        /// </summary>
        public string Description { get; set; } = null!;
        /// <summary>
        /// Comments of the primary skill
        /// </summary>
        public string? Comments { get; set; }
        /// <summary>
        /// Indicate if the row is active
        /// </summary>
        public bool? IsActive { get; set; }
        /// <summary>
        /// Id who create the row
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
        /// Date of the last updated day
        /// </summary>
        public DateTime? LastUpdatedDate { get; set; }
    }
}
