namespace gdsmx_back_netcoreAPI.DTO
{
	public class DataEmployee
	{
		public int IdEmployee { get; set; }
		public string? GPN { get; set; }
		public string? FirstName {get ; set; }
		public string? MiddleName {get ; set; }
		public string? LastName {get ; set; }
		public string? SecondLastName {get ; set; }
		public string? Birthdate {get ; set; }
		public DateTime JoinedDate {get ; set; }
		public string? Email {get ; set; }
		public string? Counselor {get ; set; }
        public string? Location {get ; set; }
        public string? PersonSegment {get ; set; }
        public string? Competency {get ; set; }
        public string? Status {get ; set; }
		public int Rank {get ; set; }
		public string? Level { get ; set; }		
        public string? Grade {get ; set; }
		public string? Notes {get ; set; }
    }
}
