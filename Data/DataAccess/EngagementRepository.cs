using gdsmx_back_netcoreAPI.Data.Repositories;
using gdsmx_back_netcoreAPI.DTO;
using gdsmx_back_netcoreAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace gdsmx_back_netcoreAPI.Data.DataAccess
{
    public class EngagementRepository : IEngagementRepository
    {
        private sdgmxdemosqldbContext _context;
        public EngagementRepository(sdgmxdemosqldbContext context)
        {
            _context = context;
        }
        public int GetIdEmployeeByGPN(string gpn)
        {
            var employee = _context.Employees.Where(x => x.Gpn == gpn).FirstOrDefault();

            return employee == null ? 0 : employee.IdEmployee;
        }

        public ActionResult<int> CreateEngagement(Engagement engagement)
        {
            _context.Engagements.Add(engagement);
            _context.SaveChanges();

            return engagement.IdEngagement;
        }
        public Engagement GetEngagement(int idEmployee, int idEngagement)
        {
            return _context.Engagements.Where(x => x.IdEmployee == idEmployee && x.IdEngagement == idEngagement).FirstOrDefault();
        }
        public ActionResult<int> UpdateEngagement(Engagement engagement)
        {
            _context.Engagements.Update(engagement);
            _context.SaveChanges();

            return engagement.IdEngagement;
        }
        public ActionResult<IEnumerable<DataEmployeeEngagement>> GetEngagements(int idEmployee, string GPN, string weeksBeforeEnd, int pageNumber, int rowsOfPage, bool isActive, object status, object employeeStatus, string employeeName)
        {
            List<DataEmployeeEngagement> employeeEngagements = _context.Set<DataEmployeeEngagement>().
                FromSqlRaw("SP_GetEmployeeEngagement @IdEmployee, @GPN_GPN, @Weeks_before_end, @PageNumber, @RowsOfPage, @IsActive, @filterStatus, @filterEmployeeStatus, @searchEmployee",
                new SqlParameter("@IdEmployee", idEmployee),
                new SqlParameter("@GPN_GPN", GPN),
                new SqlParameter("@Weeks_before_end", weeksBeforeEnd),
                new SqlParameter("@PageNumber", pageNumber),
                new SqlParameter("@RowsOfPage", rowsOfPage),
                new SqlParameter("@IsActive", isActive),
                new SqlParameter("@filterStatus", status),
                new SqlParameter("@filterEmployeeStatus", employeeStatus),
                new SqlParameter("@searchEmployee", employeeName)).ToList();
            return employeeEngagements;
        }

        public List<DataEmployeeEngagement> GetFile(int idEmployee, string GPN, string weeksBeforeEnd, int pageNumber, int rowsOfPage, bool isActive, object status, object employeeStatus, string employeeName)
        {
            List<DataEmployeeEngagement> engagementsList = _context.Set<DataEmployeeEngagement>().
                FromSqlRaw("SP_GetEmployeeEngagement @IdEmployee, @GPN_GPN, @Weeks_before_end, @PageNumber, @RowsOfPage, @IsActive, @filterStatus, @filterEmployeeStatus, @searchEmployee",
                new SqlParameter("@IdEmployee", idEmployee),
                new SqlParameter("@GPN_GPN", GPN),
                new SqlParameter("@Weeks_before_end", weeksBeforeEnd),
                new SqlParameter("@PageNumber", pageNumber),
                new SqlParameter("@RowsOfPage", rowsOfPage),
                new SqlParameter("@IsActive", isActive),
                new SqlParameter("@filterStatus", status),
                new SqlParameter("@filterEmployeeStatus", employeeStatus),
                new SqlParameter("@searchEmployee", employeeName)).ToList();
            return engagementsList;
        }
    }
}
