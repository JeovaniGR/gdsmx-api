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
        public IActionResult GetExport([FromQuery]RequestEmployeeExport requestEmployeeExport)
        {
            try
            {
                if (requestEmployeeExport.FileType == 1)
                    return File(_bLEmployee.GetExportFile(requestEmployeeExport), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Employee_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".xlsx");
                else
                    return File(_bLEmployee.GetExportFile(requestEmployeeExport), "Text/CSV", "Employee_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".csv");
            }
            catch(Exception ex)
            {
                string message = $"Error in GetExport, error message: {ex.Message}, HResult: {ex.HResult}";
                _logger.LogError(message);
                return BadRequest(message);
            }
        }

        [HttpGet("{gpn}/Skills")]
        public IActionResult GetSkills(string gpn, [FromQuery] RequestEmployeeSkill requestEmployeeSkill)
        {
            try
            {
                var employeeSkills = _bLEmployee.GetSkills(gpn, requestEmployeeSkill);

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

        [HttpGet("{gpn}/Badges")]
        public IActionResult GetBadges(string gpn, [FromQuery] RequestEmployeeBadge requestEmployeeBadge)
        {
            try
            {
                var employeeBadges = _bLEmployee.GetBadges(gpn, requestEmployeeBadge);

                if (!employeeBadges.Value.Any())
                {
                    return NotFound("Employee's badges information not found.");
                }

                return Ok(employeeBadges);
            }
            catch (Exception ex)
            {
                string message = $"Error in GetBadges, error message: {ex.Message}, HResult: {ex.HResult}";
                _logger.LogError(message);
                return BadRequest(message);
            }
        }

        [HttpGet("{gpn}/Certifications")]
        public IActionResult GetCertifications(string gpn, [FromQuery] RequestEmployeeCertification requestEmployeeCertification)
        {
            try
            {
                var employeeCertifications = _bLEmployee.GetCertifications(gpn, requestEmployeeCertification);

                if (!employeeCertifications.Value.Any())
                {
                    return NotFound("Employee's certifications information not found.");
                }

                return Ok(employeeCertifications);
            }
            catch (Exception ex)
            {
                string message = $"Error in GetCertifications, error message: {ex.Message}, HResult: {ex.HResult}";
                _logger.LogError(message);
                return BadRequest(message);
            }
        }

        private DataEmployeeBadges GetRandomEmployeeBadges(string gpn)
        {
            var random = new Random();
            var option = random.Next(1, 4);
            var employeeBadges = new DataEmployeeBadges();
            employeeBadges.GPN = gpn;
            switch (option)
            {
                case 1:
                    employeeBadges.Badges = new List<DataBadge>
                    {
                        new DataBadge("Azure", "Bronze"),
                        new DataBadge("Cloud", "Bronze"),
                        new DataBadge("Blockchain", "Bronze")
                    };
                    break;
                case 2:
                    employeeBadges.Badges = new List<DataBadge>();
                    break;
                case 3:
                    employeeBadges.Badges = new List<DataBadge>
                    {
                        new DataBadge("Data Integration", "Bronze")
                    };
                    break;
            }
            return employeeBadges;

        }

        [HttpGet("{gpn}/badges/test")]
        public IActionResult GetBadges(string gpn)
        {
            try
            {
                var employeeBadges = GetRandomEmployeeBadges(gpn);
                return Ok(employeeBadges);
            }
            catch (Exception ex)
            {
                string message = $"Error in GetBadges, error message: {ex.Message}, HResult: {ex.HResult}";
                _logger.LogError(message);
                return BadRequest(message);
            }
        }

        [HttpGet("{gpn}/certifications/test")]
        public IActionResult GetCertifications(string gpn)
        {
            try
            {
                var employeeCertifications = GetRandomEmployeeCertifications(gpn);                
                return Ok(employeeCertifications);
            }
            catch (Exception ex)
            {
                string message = $"Error in GetCertifications, error message: {ex.Message}, HResult: {ex.HResult}";
                _logger.LogError(message);
                return BadRequest(message);
            }
        }

        private DataEmployeeCertifications GetRandomEmployeeCertifications(string gpn)
        {
            var random = new Random();
            var option = random.Next(1, 4);
            var employeeCertifications = new DataEmployeeCertifications();
            employeeCertifications.GPN = gpn;
            switch (option)
            {
                case 1:
                    employeeCertifications.Certifications = new List<DataCertification>
                    {
                        new DataCertification("Azure", "Microsoft"),
                        new DataCertification("Cloud", "Amazon"),
                        new DataCertification("Blockchain", "Google")
                    };
                    break;
                case 2:
                    employeeCertifications.Certifications = new List<DataCertification>();
                    break;
                case 3:
                    employeeCertifications.Certifications = new List<DataCertification>
                    {
                        new DataCertification("Blockchain", "Google")
                    };
                    break;
            }
            return employeeCertifications;

        }
    }
}
