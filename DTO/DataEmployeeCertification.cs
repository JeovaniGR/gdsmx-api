namespace gdsmx_back_netcoreAPI.DTO
{
    public class DataEmployeeCertification : IDataEmployee
    {
        public int IdEmployee { get; set; }
        public string? GPN { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? SecondLastName { get; set; }
        public string? Description { get; set; }
        public DateTime? ObtainedDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}
