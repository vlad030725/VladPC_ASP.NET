using DomainModel;
using Interfaces.DTO;
using Interfaces.Repository;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CompanyService : ICompanyService
    {
        private IDbRepos db;

        public CompanyService(IDbRepos db)
        {
            this.db = db;
        }

        public void CreateCompany(CompanyDto company)
        {
            db.Company.Create(new Company(){
                Name = company.Name,
            });
            SaveChanges();
        }

        public void DeleteCompany(int id)
        {
            db.Company.Delete(id);
            SaveChanges();
        }

        public List<CompanyDto> GetCompanies()
        {
            return db.Company.GetList().Select(i => new CompanyDto(i)).ToList();
        }

        public CompanyDto GetCompany(int id)
        {
            return new CompanyDto(db.Company.GetItem(id));
        }

        public void UpdateCompany(CompanyDto company)
        {
            Company c = db.Company.GetItem(company.Id);
            if (c == null)
            {
                return;
            }
            c.Name = company.Name;
            SaveChanges();
        }

        public bool SaveChanges()
        {
            if (db.Save() > 0) return true;
            return false;
        }
    }
}
