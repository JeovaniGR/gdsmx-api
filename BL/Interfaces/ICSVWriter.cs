namespace gdsmx_back_netcoreAPI.BL.Interfaces
{
    public interface ICSVWriter<T>
    {
        public byte[] WriteToCSV(List<T> values);
    }
}
