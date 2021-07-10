using AdminPanelTask.Data;
using AdminPanelTask.Interfaces;
using AdminPanelTask.Models;
using AdminPanelTask.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanelTask.Controllers
{
    public class EmployeesController : Controller
    {

        private readonly IEmployeeRepository _employeeRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly DataContext _context;

        public EmployeesController( IEmployeeRepository employeeRepository,
            ICompanyRepository companyRepository, DataContext context)
        {
            _employeeRepository = employeeRepository;
            _companyRepository = companyRepository;
            _context = context;
        }
        public IActionResult Index()
        {
            return View("List");
        }

        public IActionResult New()
        {
            var companies = _companyRepository.GetCompanies();

            var viewModel = new EmployeeFormViewModel() {

                Companies = companies
            };

            return View("EmployeeForm", viewModel);
        }

        [HttpPost]
        public IActionResult CreateEmployee(EmployeeFormViewModel employeeFormViewModel)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = _companyRepository.GetCompanies();
                return View("EmployeForm", viewModel);
            }

            var employee = new Employee()
            {  
                Id = employeeFormViewModel.Id,          
                Name = employeeFormViewModel.Name,
                Email = employeeFormViewModel.Email,
                CompanyId = employeeFormViewModel.CompanyId
            };

            _employeeRepository.AddEmployee(employee);
            _context.SaveChanges();
            
            return RedirectToAction("Index", "Employees");        
        }

    }
}
