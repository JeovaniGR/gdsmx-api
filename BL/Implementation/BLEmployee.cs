using gdsmx_back_netcoreAPI.BL.Interfaces;
using gdsmx_back_netcoreAPI.BL.Resource;
using gdsmx_back_netcoreAPI.Data.Repositories;
using gdsmx_back_netcoreAPI.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
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

            //Temporary solution for engagement dummy info
            var employeeList = _employeeRepository.Get(competency, level, status, requestEmployee.GPN, requestEmployee.IdEmployee, requestEmployee.Page, requestEmployee.PageSize);
 
            foreach (var employee in employeeList.Value)
            {
                employee.Engagement = employee.Status == "Billable" ? "TalentOps Project" : "";
                
                Random rnd = new Random();
                int days = rnd.Next(7, 30);
                DateTime dateTime = DateTime.Now.AddDays(days);

                employee.EngagementEndDate = employee.Status == "Billable" ? dateTime.ToString("MMMM dd, yyyy") : "";
            }

            return employeeList;
            //Temporary solution for engagement dummy info

            //return _employeeRepository.Get(competency, level, status, requestEmployee.GPN, requestEmployee.IdEmployee, requestEmployee.Page, requestEmployee.PageSize);
        }

        public byte[] GetExportFile(RequestEmployeeExport requestEmployee)
        {
            var competency = requestEmployee.Competency ?? SqlString.Null;
            var level = requestEmployee.Level ?? SqlString.Null;
            var status = requestEmployee.Status ?? SqlString.Null;

            List<DataEmployee> employeesList =  _employeeRepository.GetFile(competency, level, status, requestEmployee.GPN, requestEmployee.IdEmployee, requestEmployee.Page, requestEmployee.PageSize);

            if (requestEmployee.FileType == 1)
            {
                IExcelWriter<DataEmployee> EmployeeExcelWriter = new EmployeeFileWriter();
                return EmployeeExcelWriter.WriteToExcel(employeesList);
            }
            else
            {
                ICSVWriter<DataEmployee> EmployeeCSVWriter = new EmployeeFileWriter();
                return EmployeeCSVWriter.WriteToCSV(employeesList);
            }
        }

        public ActionResult<IEnumerable<DataEmployeeSkill>> GetSkills(string gpn, RequestEmployeeSkill requestEmployeeSkill)
        {
            var skill = requestEmployeeSkill.Skill ?? SqlString.Null;
            var rank = requestEmployeeSkill.Rank ?? SqlString.Null;

            int idEmployee = _employeeRepository.GetEmployeeByGPN(gpn);

            if (idEmployee == 0)
            {
                return new List<DataEmployeeSkill>();
            }

            return _employeeRepository.GetSkills(idEmployee, requestEmployeeSkill.Option, skill, rank, requestEmployeeSkill.Page, requestEmployeeSkill.PageSize);
        }

        public ActionResult<IEnumerable<DataEmployeeBadge>> GetBadges(string gpn, RequestEmployeeBadge request)
        {
            var level = request.Level ?? SqlString.Null;
            var status = request.Status ?? SqlString.Null;

            int idEmployee = _employeeRepository.GetEmployeeByGPN(gpn);

            if (idEmployee == 0)
            {
                return new List<DataEmployeeBadge>();
            }

            return _employeeRepository.GetBadges(idEmployee, level, status, request.Page, request.PageSize);
        }

        public ActionResult<IEnumerable<DataEmployeeCertification>> GetCertifications(string gpn, RequestEmployeeCertification request)
        {
            var certification = request.Certification ?? SqlString.Null;

            int idEmployee = _employeeRepository.GetEmployeeByGPN(gpn);

            if (idEmployee == 0)
            {
                return new List<DataEmployeeCertification>();
            }

            return _employeeRepository.GetCertifications(idEmployee, request.Option, request.StartDate, request.EndDate, certification, request.Page, request.PageSize);
        }
    }
}
