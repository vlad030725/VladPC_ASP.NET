using DAL.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.RepositoryPgs
{
    public class CompanyRepositoryPgs : IRepository<Company>
    {
        private ComputerStoreContext db;
        public CompanyRepositoryPgs(ComputerStoreContext db)
        {
            this.db = db;
        }
        public void Create(Company item)
        {
            db.Company.Add(item);
        }

        public void Delete(int id)
        {
            Company c = db.Company.Find(id);
            if (c != null)
            {
                db.Company.Remove(c);
            }
        }

        public Company GetItem(int id)
        {
            return db.Company.Find(id);
        }

        public List<Company> GetList()
        {
            return db.Company.ToList();
        }

        public void Update(Company item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
