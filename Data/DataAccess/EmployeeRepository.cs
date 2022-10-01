using gdsmx_back_netcoreAPI.DTO;
using gdsmx_back_netcoreAPI.Data.Repositories;
using gdsmx_back_netcoreAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlTypes;

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
    }
}
