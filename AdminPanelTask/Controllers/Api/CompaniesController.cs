using AdminPanelTask.Data;
using AdminPanelTask.Helpers;
using AdminPanelTask.Interfaces;
using AdminPanelTask.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanelTask.Controllers.Api
{
    public class CompaniesController : BaseApiController
    {
       
        private readonly ICompanyRepository _companyRepository;

        public CompaniesController(DataContext context, ICompanyRepository companyRepository)
        {
            
            _companyRepository = companyRepository;
        }

        [HttpGet]
        public IActionResult GetCompanies(DataTableParams tableParams)
        {
            var companies = _companyRepository.GetCompanies(tableParams);

            return Ok(new { 
                draw = companies.Draw,
                recordsFiltered = companies.RecordsFiltered,
                recordedTotal = companies.RecordsTotal,
                data = companies.Data,
                
                });        
        }
    }
}
