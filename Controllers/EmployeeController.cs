using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using gdsmx_back_netcoreAPI.Models;
using gdsmx_back_netcoreAPI.BL.Interfaces;
using gdsmx_back_netcoreAPI.DTO;

namespace gdsmx_back_netcoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IBLEmployee _bLEmployee;

        public EmployeeController(IBLEmployee bLEmployee)
        {
            _bLEmployee = bLEmployee;
        }

        [HttpPost]
        [HttpPost("GetAll")]
        public ActionResult<IEnumerable<DataEmployee>> GetEmployees(RequestEmployee requestEmployee)
        {
            var employees = _bLEmployee.Get(requestEmployee);
            return Ok(employees);
        }

        [HttpPost("GetAllFile")]
        public ActionResult GetEmployeesFile(RequestEmployee requestEmployee)
        {
            var ok = _bLEmployee.GetFile(requestEmployee);
            return Ok(ok);
        }
    }
}
