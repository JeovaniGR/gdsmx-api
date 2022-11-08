using gdsmx_back_netcoreAPI.DTO;
using gdsmx_back_netcoreAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace gdsmx_back_netcoreAPI.Data.Repositories
{
    public interface IEngagementRepository
    {
        int GetIdEmployeeByGPN(string gpn);
        ActionResult<int> CreateEngagement(Engagement engagement);
        Engagement GetEngagement(int idEmployee, int idEngagement);
        ActionResult<int> UpdateEngagement(Engagement engagement);
        ActionResult<IEnumerable<DataEmployeeEngagement>> GetEngagements(int idEmployee, string GPN, string weeksBeforeEnd, int pageNumber, int rowsOfPage, bool isActive, object status, object employeeStatus, string employeeName);
        List<DataEmployeeEngagement> GetFile(int idEmployee, string GPN, int statusEmployee, int WeeksEnd, int pageNumber, int rowsOfPage, int isActive, int idStatus);
    }
}
