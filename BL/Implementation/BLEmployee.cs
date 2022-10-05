using gdsmx_back_netcoreAPI.BL.Interfaces;
using gdsmx_back_netcoreAPI.BL.Resource;
using gdsmx_back_netcoreAPI.Data.Repositories;
using gdsmx_back_netcoreAPI.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace gdsmx_back_netcoreAPI.BL.Implementation
{
    public class BLEmployee : IBLEmployee
    {
        readonly IEmployeeRepository _employeeRepository;

        public BLEmployee(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public ActionResult<IEnumerable<DataEmployee>> Get(RequestEmployee requestEmployee)
        {
            var competency = requestEmployee.Competency ?? SqlString.Null;
            var level = requestEmployee.Level ?? SqlString.Null;
            var status = requestEmployee.Status ?? SqlString.Null;

            return _employeeRepository.Get(competency, level, status, requestEmployee.GPN, requestEmployee.IdEmployee, requestEmployee.Page, requestEmployee.PageSize);
        }

        public  byte[] GetExportFile(RequestEmployee requestEmployee)
        {
            var competency = requestEmployee.Competency ?? SqlString.Null;
            var level = requestEmployee.Level ?? SqlString.Null;
            var status = requestEmployee.Status ?? SqlString.Null;

            List<DataEmployee> employeesList =  _employeeRepository.GetFile(competency, level, status, requestEmployee.GPN, requestEmployee.IdEmployee, requestEmployee.Page, requestEmployee.PageSize);

            generalFile file = new generalFile();

            if (requestEmployee.FileType == 1)
              return  file.WirteFileExcel(employeesList);
            else
            return file.WirteFileCSV(employeesList);
        }

       
    }
}
