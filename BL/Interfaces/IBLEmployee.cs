using Microsoft.AspNetCore.Mvc;
using gdsmx_back_netcoreAPI.DTO;

namespace gdsmx_back_netcoreAPI.BL.Interfaces
{
    public interface IBLEmployee
    {
        ActionResult<IEnumerable<DataEmployee>> Get(RequestEmployee resquestEmployee);
        byte[] GetExportFile(RequestEmployeeExport resquestEmployee);
    }
}
