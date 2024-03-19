using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface ICompanyService
    {
        List<CompanyDto> GetCompanies();

        CompanyDto GetCompany(int id);

        void CreateCompany(CompanyDto company);

        void UpdateCompany(CompanyDto company);

        void DeleteCompany(int id);
    }
}
