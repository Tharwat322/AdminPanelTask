using AdminPanelTask.Helpers;
using AdminPanelTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanelTask.Interfaces
{
    public interface ICompanyRepository 
    {
        DataTableResponse<Company> GetCompanies(DataTableParams tableParams);
        void AddCompany(Company company);
        IEnumerable<Company> GetCompanies();
    }
}
