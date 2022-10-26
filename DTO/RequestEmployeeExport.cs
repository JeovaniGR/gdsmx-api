namespace gdsmx_back_netcoreAPI.DTO
{
    public class RequestEmployeeExport : RequestEmployee
    {
        public int FileType { get; set; } = 0;
    }
}
