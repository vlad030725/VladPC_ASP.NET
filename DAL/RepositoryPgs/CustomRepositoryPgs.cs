using Interfaces.Repository;
using DomainModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.RepositoryPgs
{
    public class CustomRepositoryPgs : IRepository<Custom>
    {
        private ComputerStoreContext db;
        public CustomRepositoryPgs(ComputerStoreContext db)
        {
            this.db = db;
        }
        public void Create(Custom item)
        {
            db.Custom.Add(item);
        }

        public void Delete(int id)
        {
            Custom c = db.Custom.Find(id);
            if (c != null)
            {
                db.Custom.Remove(c);
            }
        }

        public Custom GetItem(int id)
        {
            return db.Custom.Find(id);
        }

        public List<Custom> GetList()
        {
            return db.Custom.ToList();
        }

        public void Update(Custom item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
