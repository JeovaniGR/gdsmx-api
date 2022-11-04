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
        public ActionResult<IEnumerable<DataEmployeeEngagement>> GetEngagements(int idEmployee, string GPN, int StatusEmployee, int WeeksEnd, int PageNumber, int RowsOfPage, int IsActive, int IdStatus)
        {
            List<DataEmployeeEngagement> employeeEngagements = _context.Set<DataEmployeeEngagement>().
                FromSqlRaw("SP_GetEmployeeEngagement @IdEmployee, @GPN_GPN, @IdEmployeeStatus, @Weeks_before_end, @PageNumber, @RowsOfPage, @IsActive,@IdStatus",
                new SqlParameter("@IdEmployee", idEmployee),
                new SqlParameter("@GPN_GPN", GPN),
                new SqlParameter("@IdEmployeeStatus", StatusEmployee),
                new SqlParameter("@Weeks_before_end", WeeksEnd),
                new SqlParameter("@PageNumber", PageNumber),
                new SqlParameter("@RowsOfPage", RowsOfPage),
                new SqlParameter("@IsActive", IsActive),
                new SqlParameter("@IdStatus", IdStatus)).ToList();
            return employeeEngagements;
        }
    }
}
