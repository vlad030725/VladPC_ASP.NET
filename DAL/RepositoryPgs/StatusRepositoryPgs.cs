using DAL.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.RepositoryPgs
{
    public class StatusRepositoryPgs : IRepository<Status>
    {
        private ComputerStoreContext db;
        public StatusRepositoryPgs(ComputerStoreContext db)
        {
            this.db = db;
        }
        public void Create(Status item)
        {
            db.Status.Add(item);
        }

        public void Delete(int id)
        {
            Status s = db.Status.Find(id);
            if (s != null)
            {
                db.Status.Remove(s);
            }
        }

        public Status GetItem(int id)
        {
            return db.Status.Find(id);
        }

        public List<Status> GetList()
        {
            return db.Status.ToList();
        }

        public void Update(Status item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
