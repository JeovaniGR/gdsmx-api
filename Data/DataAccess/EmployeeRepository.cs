using gdsmx_back_netcoreAPI.DTO;
using gdsmx_back_netcoreAPI.Data.Repositories;
using gdsmx_back_netcoreAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace gdsmx_back_netcoreAPI.Data.DataAccess
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private sdgmxdemosqldbContext _context;
        public EmployeeRepository(sdgmxdemosqldbContext context)
        {
            _context = context;
        }

        public ActionResult<IEnumerable<DataEmployee>> Get(object competency, object level, object status, string GPN, int idEmployee, int page, int pageSize)
        {
            List<DataEmployee> employeesList = _context.Set<DataEmployee>().FromSqlRaw("SP_GetEmployee @filterCompetency, @filterRank, @filterStatus, @IdEmployee, @GPN, @PageNumber, @RowsOfPage",
                                new SqlParameter("@filterCompetency", competency),
                                new SqlParameter("@filterRank", level),
                                new SqlParameter("@filterStatus", status),
                                new SqlParameter("@IdEmployee", idEmployee),
                                new SqlParameter("@GPN", GPN),
                                new SqlParameter("@PageNumber", page),
                                new SqlParameter("@RowsOfPage", pageSize)).ToList();
            return employeesList;
        }

        public List<DataEmployee> GetFile(object competency, object level, object status, string GPN, int idEmployee, int page, int pageSize)
        {
            List<DataEmployee> employeesList = _context.Set<DataEmployee>().FromSqlRaw("SP_GetEmployee @filterCompetency, @filterRank, @filterStatus, @IdEmployee, @GPN, @PageNumber, @RowsOfPage",
                                new SqlParameter("@filterCompetency", competency),
                                new SqlParameter("@filterRank", level),
                                new SqlParameter("@filterStatus", status),
                                new SqlParameter("@IdEmployee", idEmployee),
                                new SqlParameter("@GPN", GPN),
                                new SqlParameter("@PageNumber", page),
                                new SqlParameter("@RowsOfPage", pageSize)).ToList();
            return employeesList;
        }

        public int GetEmployeeByGPN(string gpn)
        {
            var employee = _context.Employees.Where(x => x.Gpn == gpn).FirstOrDefault();

            return employee == null ? 0 : employee.IdEmployee;
        }
        public ActionResult<IEnumerable<DataEmployeeSkill>> GetSkills(int idEmployee, int option, object skill, object rank, int page, int pageSize)
        {
            List<DataEmployeeSkill> employeeSkillList = _context.Set<DataEmployeeSkill>().FromSqlRaw("SP_GetEmployeeSkill @IdEmployee, @Option, @filterSkill, @filterRank, @PageNumber, @RowsOfPage",
                                new SqlParameter("@IdEmployee", idEmployee),
                                new SqlParameter("@Option", option),
                                new SqlParameter("@filterSkill", skill),
                                new SqlParameter("@filterRank", rank),
                                new SqlParameter("@PageNumber", page),
                                new SqlParameter("@RowsOfPage", pageSize)).ToList();
            return employeeSkillList;
        }

        public ActionResult<IEnumerable<DataEmployeeBadge>> GetBadges(int idEmployee, object level, object status, int page, int pageSize)
        {
            List<DataEmployeeBadge> employeeBadgeList = _context.Set<DataEmployeeBadge>().FromSqlRaw("SP_GetEmployeeBadge @IdEmployee, @filterLevel, @filterStatus, @PageNumber, @RowsOfPage",
                new SqlParameter("@IdEmployee", idEmployee),
                new SqlParameter("@filterLevel", level),
                new SqlParameter("@filterStatus", status),
                new SqlParameter("@PageNumber", page),
                new SqlParameter("@RowsOfPage", pageSize)).ToList();
            return employeeBadgeList;
        }

        public ActionResult<IEnumerable<DataEmployeeCertification>> GetCertifications(int idEmployee, int option, DateTime? startDate, DateTime? endDate, object certification, int page, int pageSize)
        {
            List<DataEmployeeCertification> employeeCertificationList = _context.Set<DataEmployeeCertification>().
                FromSqlRaw("SP_GetEmployeeCertification @IdEmployee, @Option, @StartDate, @EndDate, @filterCertification, @PageNumber, @RowsOfPage",
                new SqlParameter("@IdEmployee", idEmployee),
                new SqlParameter("@Option", option),
                new SqlParameter("@StartDate", startDate),
                new SqlParameter("@EndDate", endDate),
                new SqlParameter("@filterCertification", certification),
                new SqlParameter("@PageNumber", page),
                new SqlParameter("@RowsOfPage", pageSize)).ToList();
            return employeeCertificationList;
        }

    }
}
