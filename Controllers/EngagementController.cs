using gdsmx_back_netcoreAPI.BL.Implementation;
using gdsmx_back_netcoreAPI.BL.Interfaces;
using gdsmx_back_netcoreAPI.DTO;
using gdsmx_back_netcoreAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace gdsmx_back_netcoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EngagementController : ControllerBase
    {
        private readonly IBLEngagement _blEngagement;
        private readonly ILogger<EngagementController> _logger;

        public EngagementController(IBLEngagement bLEngagement, ILogger<EngagementController> logger)
        {
            _blEngagement = bLEngagement;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Create a new engagement for employee.
        /// </summary>
        /// <remarks>
        /// Examples: /api/Engagement/XE264109159
        /// {
        ///      "description": "Talent management app",
        ///      "idParent": null,
        ///      "customerName": "Rohit Selvaraj",
        ///      "projectName": "Talent Ops",
        ///      "engagementId": "I-123456",
        ///      "projectManagerName": "Heber Solorio",
        ///      "projectManagerEmail": "heber.solorio@gds.ey.com",
        ///      "startDate": "2022-10-31",
        ///      "endDate": "2022-11-30",
        ///      "isActive": true,
        ///      "status": 2,
        ///      "engagementHours": 40,
        ///      "cancelationDate": null,
        ///      "comments": "Internal engagement"
        ///}
        /// </remarks>
        /// <param name="gpn">Employee's EY ID</param>
        /// <param name="requestEngagementCU">Data to create a new engagement for an employee</param>
        /// <returns>ID of new engagement</returns>
        [HttpPost("{gpn}")]
        public IActionResult CreateEngagement(string gpn, RequestEngagementCU requestEngagementCU)
        {
            try
            {
                int idEmployee = _blEngagement.GetIdEmployeeByGPN(gpn);

                if (idEmployee == 0)
                {
                    return NotFound("Error creating a new engagement. Employee with GPN " + gpn + " not found.");
                }

                var idNewEngagement = _blEngagement.CreateEngagement(idEmployee, requestEngagementCU);

                if (idNewEngagement.Value == 0)
                {
                    return BadRequest("Error creating a new engagement");
                }

                return Ok(idNewEngagement);
            }
            catch (Exception ex)
            {
                string message = $"Error in CreateNewEngagement, error message: {ex.Message}, HResult: {ex.HResult}";
                _logger.LogError(message);
                return BadRequest(message);
            }
        }

        /// <summary>
        /// Update engagement data for employee.
        /// </summary>
        /// <remarks>
        /// Examples: /api/Engagement/XE264109159/1/
        /// {
        ///      "description": "Talent management app",
        ///      "idParent": null,
        ///      "customerName": "Rohit Selvaraj",
        ///      "projectName": "Talent Ops",
        ///      "engagementId": "I-123456",
        ///      "projectManagerName": "Heber Solorio",
        ///      "projectManagerEmail": "heber.solorio@gds.ey.com",
        ///      "startDate": "2022-10-31",
        ///      "endDate": "2022-11-30",
        ///      "isActive": true,
        ///      "status": 4,
        ///      "engagementHours": 40,
        ///      "cancelationDate": null,
        ///      "comments": "Internal engagement"
        ///}
        /// </remarks>
        /// <param name="gpn">Employee's EY ID</param>
        /// <param name="idEngagement">Engagement database ID</param>
        /// <param name="requestEngagementCU">Data to update engagement data for an employee</param>
        /// <returns>IdEngagement of the updated engagement</returns>
        [HttpPut("{gpn}/{idEngagement}")]
        public IActionResult UpdateEngagement(string gpn, int idEngagement, RequestEngagementCU requestEngagementCU)
        {
            try
            {
                int idEmployee = _blEngagement.GetIdEmployeeByGPN(gpn);

                if (idEmployee == 0)
                {
                    return NotFound("Error updating engagement data. Employee with GPN " + gpn + " not found.");
                }

                var updatedIdEngagement = _blEngagement.UpdateEngagement(idEmployee, idEngagement, requestEngagementCU);

                if (updatedIdEngagement.Value == 0)
                {
                    return NotFound("Error updating engagement data. Engagement with Id " + requestEngagementCU.EngagementId + " not found.");
                }

                return Ok(updatedIdEngagement);
            }
            catch (Exception ex)
            {
                string message = $"Error in UpdateEngagement, error message: {ex.Message}, HResult: {ex.HResult}";
                _logger.LogError(message);
                return BadRequest(message);
            }
        }

        /// <summary>
        /// Get list of employee's Engagements.
        /// </summary>
        /// <remarks>
        /// Examples: api/Engagement?GPN=XE264109159&amp;Page=1&amp;PageSize=10
        /// </remarks>
        /// <param name="requestEmployeeEngagement">Filters for searching. Page and PageSize default value is 1.</param>
        /// <returns>List of employee's certifications</returns>
        [HttpGet]
        public IActionResult GetEngagement([FromQuery] RequestEmployeeEngagement requestEmployeeEngagement)
        {
            try
            {
                var employeeEngagements = _blEngagement.GetEngagements(requestEmployeeEngagement);

                if (!employeeEngagements.Value.Any())
                {
                    return NotFound("Employee's engagements information not found.");
                }

                return Ok(employeeEngagements);
            }
            catch (Exception ex)
            {
                string message = $"Error in GetEngagement, error message: {ex.Message}, HResult: {ex.HResult}";
                _logger.LogError(message);
                return BadRequest(message);
            }
        }

        /// <summary>
        /// Get an Excel or CSV file wich contains the employees engagements data.
        /// </summary>
        /// <remarks>
        /// Examples: api/Engagement?GPN=XE264109159&amp;Page=1&amp;PageSize=10&amp;FileType=0&amp;IsActive=1
        /// </remarks>
        /// <param name="requestEmployeeEngagementExport">Filters to search engagements data. Page and PageSize default value is 1. FileType parameter default value is 
        /// 0; 0 for CSV and 1 for Excel file type.</param>
        /// <returns>Excel or CSV file with employees engagement data.</returns>
        [HttpGet("Export")]
        public IActionResult GetExport([FromQuery]RequestEmployeeEngagementExport requestEmployeeEngagementExport)
        {
            try
            {
                if (requestEmployeeEngagementExport.FileType == 1)
                    return File(_blEngagement.GetExportFile(requestEmployeeEngagementExport), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Engagements_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".xlsx");
                else
                    return File(_blEngagement.GetExportFile(requestEmployeeEngagementExport), "Text/CSV", "Engagements_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".csv");
            }
            catch(Exception ex)
            {
                string message = $"Error in GetExport, error message: {ex.Message}, HResult: {ex.HResult}";
                _logger.LogError(message);
                return BadRequest(message);
            }
        }
    }
}
