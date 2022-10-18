using Microsoft.AspNetCore.Mvc;
using gdsmx_back_netcoreAPI.BL.Interfaces;
using gdsmx_back_netcoreAPI.DTO;

namespace gdsmx_back_netcoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IBLEmployee _bLEmployee;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IBLEmployee bLEmployee, ILogger<EmployeeController> logger)
        {
            _bLEmployee = bLEmployee;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public IActionResult GetEmployees([FromQuery]RequestEmployee requestEmployee)
        {
            try
            {
                var employees = _bLEmployee.Get(requestEmployee);

                if (!employees.Value.Any())
                {
                    return NotFound("Employee information not found.");
                }

                return Ok(employees);
            }
            catch(Exception ex)
            {
                string message = $"Error in GetEmployees, error message: {ex.Message}, HResult: {ex.HResult}";
                _logger.LogError(message);
                return BadRequest(message);
            }
            
        }

        [HttpGet("Export")]
        public IActionResult GetExport([FromQuery]RequestEmployeeExport requestEmployee)
        {
            try
            {
                if (requestEmployee.FileType == 1)
                    return File(_bLEmployee.GetExportFile(requestEmployee), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Employee_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".xlsx");
                else
                    return File(_bLEmployee.GetExportFile(requestEmployee), "Text/CSV", "Employee_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".csv");
            }
            catch(Exception ex)
            {
                string message = $"Error in GetExport, error message: {ex.Message}, HResult: {ex.HResult}";
                _logger.LogError(message);
                return BadRequest(message);
            }
        }

        [HttpGet("Skills")]
        public IActionResult GetSkills([FromQuery] RequestEmployeeSkill requestEmployeeSkill)
        {
            try
            {
                var employeeSkills = _bLEmployee.GetSkills(requestEmployeeSkill);

                if (!employeeSkills.Value.Any())
                {
                    return NotFound("Employee's skills information not found.");
                }

                return Ok(employeeSkills);
            }
            catch (Exception ex)
            {
                string message = $"Error in GetSkills, error message: {ex.Message}, HResult: {ex.HResult}";
                _logger.LogError(message);
                return BadRequest(message);
            }

        }
    }
}
