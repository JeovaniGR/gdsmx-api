using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using gdsmx_back_netcoreAPI.Models;

namespace gdsmx_back_netcoreAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public readonly sdgmxdemosqldbContext _dbContext;

        public EmployeeController(sdgmxdemosqldbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        [HttpGet("GetAll")]
        public IActionResult GetEmployees()
        {
            IQueryable response = this._dbContext.Employees.AsQueryable();
            return Ok(response);
        }

        [HttpGet("GetById")]
        public IActionResult ObtenerPorID(int id)
        {
            
            var response = this._dbContext.Employees.Find(id);

            if (response == null)
            {
                return NotFound($"No se encontró el ID {id}");
            }

            return Ok(response);
        }
    }
}
