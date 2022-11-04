using Microsoft.AspNetCore.Mvc;
using gdsmx_back_netcoreAPI.BL.Interfaces;
using gdsmx_back_netcoreAPI.DTO;
using DocumentFormat.OpenXml.Spreadsheet;


namespace gdsmx_back_netcoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IBLEmployee _bLEmployee;
        private readonly ILogger<EmployeeController> _logger;

        /// <summary>
        /// EmployeeController constructor
        /// </summary>
        /// <param name="bLEmployee">Business logic interface</param>
        /// <param name="logger">Log interface</param>
        /// <exception cref="ArgumentNullException"></exception>
        public EmployeeController(IBLEmployee bLEmployee, ILogger<EmployeeController> logger)
        {
            _bLEmployee = bLEmployee;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Get list of employee's data.        
        /// </summary>
        /// <remarks>
        /// Examples: /api/Employee?GPN=XE264109159; /api/Employee?Page=1&amp;PageSize=30
        /// </remarks>
        /// <param name="requestEmployee">Filters to search employees data. Page and PageSize default value is 1.</param>
        /// <returns>List of employees data.</returns>
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

        /// <summary>
        /// Get an Excel or CSV file which contains employees data.
        /// </summary>
        /// <remarks>
        /// Examples: /api/Employee/Export?Page=1&amp;PageSize=30&amp;FileType=0
        /// </remarks>
        /// <param name="requestEmployeeExport">Filters to search employees data. Page and PageSize default value is 1. FileType parameter default value is
        /// 0; 0 for CSV and 1 for Excel type.</param>
        /// <returns>Excel or CSV file with employees data.</returns>
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

        /// <summary>
        /// Get list of employee's skills.
        /// </summary>
        /// <remarks>
        /// Examples: /api/Employee/XE264109159/Skills
        /// </remarks>
        /// <param name="gpn">Employee's EY ID</param>
        /// <param name="requestEmployeeSkill">Filters for searching. Page and PageSize default value is 1.</param>
        /// <returns>List of employee's skills</returns>
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

        /// <summary>
        /// Get list of employee's badges.
        /// </summary>
        /// <remarks>
        /// Examples: /api/Employee/XE264109159/Badges
        /// </remarks>
        /// <param name="gpn">Employee's EY ID</param>
        /// <param name="requestEmployeeBadge">Filters for searching. Page and PageSize default value is 1.</param>
        /// <returns>List of employee's badges</returns>
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

        /// <summary>
        /// Get list of employee's certifications.
        /// </summary>
        /// <remarks>
        /// Examples: /api/Employee/XE264109159/Certifications
        /// </remarks>
        /// <param name="gpn">Employee's EY ID</param>
        /// <param name="requestEmployeeCertification">Filters for searching. Page and PageSize default value is 1.</param>
        /// <returns>List of employee's certifications</returns>
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

        

        /// <summary>
        /// Get dummy data of badges
        /// </summary>
        /// <remarks>
        /// Examples: /api/Employee/XE264109159/badges/test
        /// </remarks>
        /// <param name="gpn">Employee's EY ID</param>
        /// <returns>Dummy data of badges</returns>
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

        /// <summary>
        /// Get dummy data of certifications
        /// </summary>
        /// <remarks>
        /// Examples: /api/Employee/XE264109159/certifications/test
        /// </remarks>
        /// <param name="gpn">Employee's EY ID</param>
        /// <returns>Dummy data of certifications</returns>
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
