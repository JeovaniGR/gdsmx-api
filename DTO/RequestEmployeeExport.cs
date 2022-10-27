namespace gdsmx_back_netcoreAPI.DTO
{
    /// <summary>
    ///  DTO class for employees data export
    /// </summary>
    public class RequestEmployeeExport : RequestEmployee
    {
        /// <summary>
        /// File type to export, 0 for CSV file and 1 for Excel file. Default value: 0
        /// </summary>
        public int FileType { get; set; } = 0;
    }
}
