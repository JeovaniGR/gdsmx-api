using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using gdsmx_back_netcoreAPI.Models;
using gdsmx_back_netcoreAPI.BL.Interfaces;
using gdsmx_back_netcoreAPI.DTO;
using System.Linq;

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
        public IActionResult GetEmployees(RequestEmployee requestEmployee)
        {
            var employees = _bLEmployee.Get(requestEmployee);

            if (employees == null)
            {
                return NotFound("No se encontró ningún empleado");
            }

            return Ok(employees);
        }
    }
}
