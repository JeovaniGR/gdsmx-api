﻿using gdsmx_back_netcoreAPI.BL.Interfaces;
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

            FileWriter file = new FileWriter();

            if (requestEmployee.FileType == 1)
                return  file.WriteFileExcel(employeesList);
            else
                return file.WriteFileCSV(employeesList);
        }

        public ActionResult<IEnumerable<DataEmployeeSkill>> GetSkills(RequestEmployeeSkill requestEmployeeSkill)
        {
            var skill = requestEmployeeSkill.Skill ?? SqlString.Null;
            var rank = requestEmployeeSkill.Rank ?? SqlString.Null;

            return _employeeRepository.GetSkills(requestEmployeeSkill.IdEmployee, requestEmployeeSkill.Option, skill, rank, requestEmployeeSkill.Page, requestEmployeeSkill.PageSize);
        }
    }
}
