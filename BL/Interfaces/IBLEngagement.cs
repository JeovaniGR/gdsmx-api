using gdsmx_back_netcoreAPI.DTO;
using Microsoft.AspNetCore.Mvc;

namespace gdsmx_back_netcoreAPI.BL.Interfaces
{
    public interface IBLEngagement
    {
        int GetIdEmployeeByGPN(string gpn);
        ActionResult<int> CreateNewEngagement(int idEmployee, RequestEngagementCU requestEngagementCU);
        ActionResult<int> UpdateEngagement(int idEmployee, int idEngagement, RequestEngagementCU requestEngagementCU);
    }
}
