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
        ActionResult<IEnumerable<DataEmployeeEngagement>> GetEngagements(int idEmployee, string GPN, int StatusEmployee, int WeeksEnd, int PageNumber, int RowsOfPage, int IsActive, int IdStatus);
        
    }
}
