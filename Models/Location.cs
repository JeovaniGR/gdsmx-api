using System;
using System.Collections.Generic;

namespace gdsmx_back_netcoreAPI.Models
{
    /// <summary>
    /// Location
    /// </summary>
    public partial class Location
    {
        /// <summary>
        /// Id of the location of the office
        /// </summary>
        public int IdLocation { get; set; }
        /// <summary>
        /// Name of the office
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// Id of the country
        /// </summary>
        public int? IdCountry { get; set; }
        /// <summary>
        /// Location of the office
        /// </summary>
        public string? Location1 { get; set; }
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
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// Id of who updated the row
        /// </summary>
        public int? IdUpdated { get; set; }
        /// <summary>
        /// Last updated date
        /// </summary>
        public DateTime? LastUpdatedDate { get; set; }

        public virtual Country IdLocationNavigation { get; set; } = null!;
    }
}
