namespace gdsmx_back_netcoreAPI.DTO
{
    public class RequestEmployeeEngagementExport : RequestEmployeeEngagement
    {
        /// <summary>
        /// File type to export, 0 for CSV file and 1 for Excel file. Default value: 0
        /// </summary>
        public int FileType { get; set; } = 0;
    }
}
