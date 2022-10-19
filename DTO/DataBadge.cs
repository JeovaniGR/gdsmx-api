namespace gdsmx_back_netcoreAPI.DTO
{
    public class DataBadge
    {
        public string? Name { get; set; }
        public string? Level { get; set; }
        public DataBadge(string? name, string? level)
        {
            Name = name;
            Level = level;
        }
    }
}
