namespace gdsmx_back_netcoreAPI.BL.Interfaces
{
    public interface IExcelWriter<T>
    {
        public byte[] WriteToExcel(List<T> values);
    }
}
