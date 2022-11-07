namespace gdsmx_back_netcoreAPI.BL.Resource
{
    public class EngagementFileWriter
    {
        private readonly List<string> header = new List<string>()
        {
            "GPN",
            "FirstName",
            "MiddleName",
            "SecondLastName",
            "EngagementId",
            "CustomerName",
            "ProyectName",
            "EngagementHours",
            "CancelationDate",
            "Comments",
            "StartDate",
            "EndDate",
            "ProjectManagerName",
            "ProjectManagerEmail",
            "Status",
            "Description"
        };
    }
}
