using System;
using System.Collections.Generic;

namespace gdsmx_back_netcoreAPI.Models
{
    /// <summary>
    /// Country
    /// </summary>
    public partial class Country
    {
        /// <summary>
        /// Id of the country
        /// </summary>
        public int IdCountry { get; set; }
        /// <summary>
        /// Name of the country
        /// </summary>
        public string Country1 { get; set; } = null!;
        /// <summary>
        /// Acronym of the country
        /// </summary>
        public string? Acronym { get; set; }
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

        public virtual Location Location { get; set; } = null!;
    }
}
