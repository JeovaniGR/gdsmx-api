using gdsmx_back_netcoreAPI.BL.Interfaces;
using gdsmx_back_netcoreAPI.Data.DataAccess;
using gdsmx_back_netcoreAPI.Data.Repositories;
using gdsmx_back_netcoreAPI.DTO;
using gdsmx_back_netcoreAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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

        public ActionResult<int> CreateNewEngagement(int idEmployee, RequestEngagementCU requestEngagementCU)
        {
            Engagement engagement = new Engagement
            {
                IdEmployee = idEmployee,
                Description = requestEngagementCU.Description,
                CustomerName = requestEngagementCU.CustomerName,
                ProjectName = requestEngagementCU.ProjectName,
                EngagementId = requestEngagementCU.EngagementId,
                ProjectManagerName = requestEngagementCU.ProjectManagerName,
                ProjectManagerEmail = requestEngagementCU.ProjectManagerEmail,
                StartDate = requestEngagementCU.StartDate,
                EndDate = requestEngagementCU.EndDate,
                IsActive = requestEngagementCU.IsActive,
                CreateDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now
            };

            var idNewEngagement = _engagementRepository.CreateNewEngagement(engagement);

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
            engagement.CustomerName = requestEngagementCU.CustomerName;
            engagement.ProjectName = requestEngagementCU.ProjectName;
            engagement.EngagementId = requestEngagementCU.EngagementId;
            engagement.ProjectManagerName = requestEngagementCU.ProjectManagerName;
            engagement.ProjectManagerEmail = requestEngagementCU.ProjectManagerEmail;
            engagement.StartDate = requestEngagementCU.StartDate;
            engagement.EndDate = requestEngagementCU.EndDate;
            engagement.IsActive = requestEngagementCU.IsActive;
            engagement.LastUpdatedDate = DateTime.Now;

            var updatedEngagement = _engagementRepository.UpdateEngagement(engagement);

            return updatedEngagement;
        }
    }
}
