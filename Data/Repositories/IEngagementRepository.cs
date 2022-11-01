using gdsmx_back_netcoreAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace gdsmx_back_netcoreAPI.Data.Repositories
{
    public interface IEngagementRepository
    {
        int GetIdEmployeeByGPN(string gpn);

        ActionResult<int> CreateNewEngagement(Engagement engagement);

        Engagement GetEngagement(int idEmployee, int idEngagement);
        ActionResult<int> UpdateEngagement(Engagement engagement);
    }
}
