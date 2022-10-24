namespace gdsmx_back_netcoreAPI.DTO
{
    public class DataEmployeeSkill : IDataEmployee
    {
        public int IdEmployee { get ; set ; }
        public string? GPN { get; set; }
        public string? FirstName { get ; set ; }
        public string? MiddleName { get ; set ; }
        public string? LastName { get ; set ; }
        public string? SecondLastName { get ; set ; }
        public string? DescriptionSkill { get; set; }
        public bool IsPrimarySkill { get; set; }
        public string? DescriptionRank { get; set; }       
    }
}
