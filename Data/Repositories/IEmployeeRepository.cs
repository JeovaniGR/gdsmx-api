using Microsoft.AspNetCore.Mvc;
using gdsmx_back_netcoreAPI.DTO;

namespace gdsmx_back_netcoreAPI.Data.Repositories
{
    public interface IEmployeeRepository
    {
        ActionResult<IEnumerable<DataEmployee>> Get(object competency, object level, object status, string GPN, int idEmployee, int page, int pageSize);
        List<DataEmployee> GetFile(object competency, object level, object status, string GPN, int idEmployee, int page, int pageSize);
        ActionResult<IEnumerable<DataEmployeeSkill>> GetSkills(int idEmployee, int option, object skill, object rank, int page, int pageSize);
        ActionResult<IEnumerable<DataEmployeeBadge>> GetBadges(int idEmployee, object level, object status, int page, int pageSize);
        ActionResult<IEnumerable<DataEmployeeCertification>> GetCertifications(int idEmployee, int option, DateTime? startDate, DateTime? endDate, 
                                                                                object certification, int page, int pageSize);
    }
}
