﻿using Microsoft.AspNetCore.Mvc;
using gdsmx_back_netcoreAPI.DTO;

namespace gdsmx_back_netcoreAPI.Data.Repositories
{
    public interface IEmployeeRepository
    {
        ActionResult<IEnumerable<DataEmployee>> Get(object competency, object level, object status, string GPN, int idEmployee, int page, int pageSize);
    }
}