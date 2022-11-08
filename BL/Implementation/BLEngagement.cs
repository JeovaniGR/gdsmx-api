using gdsmx_back_netcoreAPI.BL.Interfaces;
using gdsmx_back_netcoreAPI.BL.Resource;
using gdsmx_back_netcoreAPI.Data.Repositories;
using gdsmx_back_netcoreAPI.DTO;
using gdsmx_back_netcoreAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlTypes;
using System.Net;
using System.Net.NetworkInformation;

namespace gdsmx_back_netcoreAPI.BL.Implementation
{
    public class BLEngagement : IBLEngagement
    {
        readonly IEngagementRepository _engagementRepository;

        public BLEngagement(IEngagementRepository engagementRepository)
        {
            _engagementRepository = engagementRepository;
        }

        public int GetIdEmployeeByGPN(string gpn)
        {
            return _engagementRepository.GetIdEmployeeByGPN(gpn);
        }

        public ActionResult<int> CreateEngagement(int idEmployee, RequestEngagementCU requestEngagementCU)
        {
            Engagement engagement = new Engagement
            {
                IdEmployee = idEmployee,
                Description = requestEngagementCU.Description,
                IdParent = requestEngagementCU.IdParent,
                CustomerName = requestEngagementCU.CustomerName,
                ProjectName = requestEngagementCU.ProjectName,
                EngagementId = requestEngagementCU.EngagementId,
                ProjectManagerName = requestEngagementCU.ProjectManagerName,
                ProjectManagerEmail = requestEngagementCU.ProjectManagerEmail,
                StartDate = requestEngagementCU.StartDate,
                EndDate = requestEngagementCU.EndDate,
                IsActive = requestEngagementCU.IsActive,
                Status = requestEngagementCU.Status,
                EngagementHours = requestEngagementCU.EngagementHours,
                CancelationDate = requestEngagementCU.CancelationDate,
                Comments = requestEngagementCU.Comments,
                CreateDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now
            };

            var idNewEngagement = _engagementRepository.CreateEngagement(engagement);

            return idNewEngagement;
        }

        public ActionResult<int> UpdateEngagement(int idEmployee, int idEngagement, RequestEngagementCU requestEngagementCU)
        {
            var engagement = _engagementRepository.GetEngagement(idEmployee, idEngagement);

            if (engagement == null)
            {
                return 0;
            }

            engagement.Description = requestEngagementCU.Description;
            engagement.IdParent = requestEngagementCU.IdParent;
            engagement.CustomerName = requestEngagementCU.CustomerName;
            engagement.ProjectName = requestEngagementCU.ProjectName;
            engagement.EngagementId = requestEngagementCU.EngagementId;
            engagement.ProjectManagerName = requestEngagementCU.ProjectManagerName;
            engagement.ProjectManagerEmail = requestEngagementCU.ProjectManagerEmail;
            engagement.StartDate = requestEngagementCU.StartDate;
            engagement.EndDate = requestEngagementCU.EndDate;
            engagement.IsActive = requestEngagementCU.IsActive;
            engagement.Status = requestEngagementCU.Status;
            engagement.EngagementHours = requestEngagementCU.EngagementHours;
            engagement.CancelationDate = requestEngagementCU.CancelationDate;
            engagement.Comments = requestEngagementCU.Comments;
            engagement.LastUpdatedDate = DateTime.Now;

            var updatedEngagement = _engagementRepository.UpdateEngagement(engagement);

            return updatedEngagement;
        }

        public ActionResult<IEnumerable<DataEmployeeEngagement>> GetEngagements(RequestEmployeeEngagement request)
        {
            var status = request.Status ?? SqlString.Null;
            var employeeStatus = request.EmployeeStatus ?? SqlString.Null;

            return _engagementRepository.GetEngagements(0, request.GPN, request.WeeksBeforeEnd, request.Page, request.PageSize, request.IsActive, status, employeeStatus, request.SearchEmployee);
        }

        public byte[] GetExportFile(RequestEmployeeEngagementExport request)
        {
            var status = request.Status ?? SqlString.Null;
            var employeeStatus = request.EmployeeStatus ?? SqlString.Null;

            List<DataEmployeeEngagement> engagementsList = _engagementRepository.GetFile(0, request.GPN, request.WeeksBeforeEnd, request.Page, request.PageSize, request.IsActive, status, employeeStatus, request.SearchEmployee);

            if(request.FileType == 1)
            {
                IExcelWriter<DataEmployeeEngagement> EngagementExcelWriter = new EngagementFileWriter();
                return EngagementExcelWriter.WriteToExcel(engagementsList);
            }
            else
            {
                ICSVWriter<DataEmployeeEngagement> EngagementCSVWriter = new EngagementFileWriter();
                return EngagementCSVWriter.WriteToCSV(engagementsList);
            }
        }
    }
}
