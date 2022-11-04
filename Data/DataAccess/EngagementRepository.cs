using gdsmx_back_netcoreAPI.Data.Repositories;
using gdsmx_back_netcoreAPI.Models;
using Microsoft.AspNetCore.Mvc;

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
        
    }
}
