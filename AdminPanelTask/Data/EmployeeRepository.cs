using AdminPanelTask.Helpers;
using AdminPanelTask.Interfaces;
using AdminPanelTask.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanelTask.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        
        private readonly DataContext _context;

        public EmployeeRepository(DataContext context)
        {
            _context = context;  
        }

        public void AddEmployee(Employee employee)
        {
            _context.Add(employee);
        }

        public DataTableResponse<Employee> GetEmployees(DataTableParams tableParams)
        {
            var employees = from c in _context.Companies
                            join e in _context.Employees
                            on c.Id equals e.CompanyId
                            select e ;
                            
                           

            var totalCount = employees.Count();

            // searching 

            if (!(string.IsNullOrEmpty(tableParams.Search.Value)))
            {
                employees = employees.Where(e => e.Name.Contains(tableParams.Search.Value)
                || e.Email.Contains(tableParams.Search.Value)
                || e.Company.Name.Contains(tableParams.Search.Value));
            }

            //paging

            employees = employees.Skip(tableParams.Start).Take(tableParams.Length);

            return new DataTableResponse<Employee>
            {

                Draw = tableParams.Draw,
                RecordsTotal = totalCount,
                RecordsFiltered = totalCount,
                Data = employees.ToArray(),
                

            };
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _context.Employees.ToList();
        }
    }
}
