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
    }
}
