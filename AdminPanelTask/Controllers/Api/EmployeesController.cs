using AdminPanelTask.Data;
using AdminPanelTask.Helpers;
using AdminPanelTask.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanelTask.Controllers.Api
{
    public class EmployeesController : BaseApiController
    {
        private readonly IEmployeeRepository _repository;
        private readonly DataContext _context;
        public EmployeesController( IEmployeeRepository repository, DataContext context)
        {
            _repository = repository;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetEmployees(DataTableParams tableParams)
        {
            var employees = _repository.GetEmployees(tableParams);

            return Ok(new
            {
                draw = employees.Draw,
                recordsFiltered = employees.RecordsFiltered,
                recordedTotal = employees.RecordsTotal,
                data = employees.Data,
               
            }) ;
        }
    }
}
