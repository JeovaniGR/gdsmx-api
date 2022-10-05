﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using gdsmx_back_netcoreAPI.Models;
using gdsmx_back_netcoreAPI.BL.Interfaces;
using gdsmx_back_netcoreAPI.DTO;

namespace gdsmx_back_netcoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IBLEmployee _bLEmployee;

        public EmployeeController(IBLEmployee bLEmployee)
        {
            _bLEmployee = bLEmployee;
        }

        [HttpPost]
        [HttpPost("GetAll")]
        public IActionResult GetEmployees(RequestEmployee requestEmployee)
        {
            var employees = _bLEmployee.Get(requestEmployee);

            if (employees == null)
            {
                return NotFound("No se encontró ningún empleado");
            }

            return Ok(employees);
        }

        

        [HttpPost("GetExport")]
        public ActionResult GetExport(RequestEmployee requestEmployee)
        {
            if(requestEmployee.FileType == 1)
             return File(_bLEmployee.GetExportFile(requestEmployee), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Employee"+DateTime.Now.ToString("yyyyMMdd_HHmm") + ".xlsx");
            else
             return File(_bLEmployee.GetExportFile(requestEmployee), "Text/CSV", "Employee" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".csv");

        }
    }
}
