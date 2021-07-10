using AdminPanelTask.Helpers;
using AdminPanelTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanelTask.Interfaces
{
    public interface IEmployeeRepository 
    {
        DataTableResponse<Employee> GetEmployees(DataTableParams tableParams);
        IEnumerable<Employee> GetEmployees();
        void AddEmployee(Employee employee);
    }
}
