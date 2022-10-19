namespace gdsmx_back_netcoreAPI.DTO
{
    public class DataCertification
    {
        public string? Name { get; set; }
        public string? Issuer { get; set; }
        public DataCertification(string? name, string? issuer)
        {
            Name = name;
            Issuer = issuer;
        }
    }
}
