using gdsmx_back_netcoreAPI.Interfaces;
using gdsmx_back_netcoreAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace gdsmx_back_netcoreAPI.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private sdgmxdemosqldbContext _context;
        public EmployeeRepository(sdgmxdemosqldbContext context)
        {
            _context = context;
        }

        public ActionResult<IEnumerable<Employee>> Get()
        {
            var employees = _context.Employees.ToList();
            return employees;
        }
    }
}
