using Microsoft.AspNetCore.Mvc;
using gdsmx_back_netcoreAPI.Models;

namespace gdsmx_back_netcoreAPI.Interfaces
{
    public interface IEmployeeRepository
    {
        ActionResult<IEnumerable<Employee>> Get();
    }
}
