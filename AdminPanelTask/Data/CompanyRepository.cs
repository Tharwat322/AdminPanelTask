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
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DataContext _context;
        public CompanyRepository(DataContext context)
        {
            _context = context;
        }

        public void AddCompany(Company company)
        {
            _context.Add(company);
        }

        public DataTableResponse<Company> GetCompanies(DataTableParams tableParams)
        {
            var companies = _context.Companies.AsQueryable();

            var totalCount = companies.Count();

            // searching 

            if (!(string.IsNullOrEmpty(tableParams.Search.Value)))
            {
                companies = companies.Where(c => c.Name.Contains(tableParams.Search.Value)
                || c.WebSite.Contains(tableParams.Search.Value)
                || c.Address.Contains(tableParams.Search.Value));
            }

            //paging

            companies = companies.Skip(tableParams.Start).Take(tableParams.Length);

            return new DataTableResponse<Company> {

                Draw = tableParams.Draw,
                RecordsTotal = totalCount,
                RecordsFiltered = totalCount,
                Data = companies.ToArray(),
               
                
            };


        }

        public IEnumerable<Company> GetCompanies()
        {
            return _context.Companies.ToList();
        }
    }
}
