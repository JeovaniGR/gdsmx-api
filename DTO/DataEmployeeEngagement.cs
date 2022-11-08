namespace gdsmx_back_netcoreAPI.DTO
{
    public class DataEmployeeEngagement
    {
        public int IdEmployee { get; set; }
        public string GPN { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? SecondLastName { get; set; }
        public int? IdEngagement { get; set; }
        public string? EngagementId { get; set; }
        public string? CustomerName { get; set; }
        public string? ProjectName { get; set; }
        public int? EngagementHours { get; set; }
        public DateTime CancelationDate { get; set; }
        public string? Comments { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? ProjectManagerName { get; set; }
        public string? ProjectManagerEmail { get; set; }
        public int? Status { get; set; }
        public string? StatusDescription { get; set; }
        public int? DaysBeforeEnd { get; set; }
        public int? WeeksBeforeEnd { get; set; }        
    }
}
