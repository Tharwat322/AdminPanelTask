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
    public class CompaniesController : Controller
    {
        private readonly ICompanyRepository _companyRepository;
        private DataContext _context;
        public CompaniesController(ICompanyRepository companyRepository, DataContext context)
        {
            _companyRepository = companyRepository;
            _context = context;
        }
        public IActionResult Index()
        {
            return View("List");
        }


        public IActionResult New()
        {
            return View("CompanyForm");
        }

        [HttpPost]
        public IActionResult CreateCompany(CompanyFormViewModel viewModel)
        {

            if (!ModelState.IsValid)
            {
                return View("CompanyForm", viewModel);
            }

            var company = new Company()
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                WebSite = viewModel.WebSite,
                Address = viewModel.Address
            };

            _companyRepository.AddCompany(company);
            _context.SaveChanges();

            return RedirectToAction("Index","Companies");
        }
    }
}
