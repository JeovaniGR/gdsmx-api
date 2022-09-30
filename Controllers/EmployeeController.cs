using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using gdsmx_back_netcoreAPI.Models;
using gdsmx_back_netcoreAPI.Interfaces;
using gdsmx_back_netcoreAPI.DTO;

namespace gdsmx_back_netcoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeController(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [HttpPost("GetAll")]
        public ActionResult<IEnumerable<Employee>> GetEmployees(RequestEmployee requestEmployee)
        {
            var employees = _repository.Get();
            return Ok(employees);
        }

        //[HttpGet("GetById")]
        //public IActionResult ObtenerPorID(int id)
        //{
            
        //    var response = this._dbContext.Employees.Find(id);

        //    if (response == null)
        //    {
        //        return NotFound($"No se encontró el ID {id}");
        //    }

        //    return Ok(response);
        //}
    }
}
