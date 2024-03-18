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
    public class ProcurementRepositoryPgs : IRepository<Procurement>
    {
        private ComputerStoreContext db;
        public ProcurementRepositoryPgs(ComputerStoreContext db)
        {
            this.db = db;
        }
        public void Create(Procurement item)
        {
            db.Procurement.Add(item);
        }

        public void Delete(int id)
        {
            Procurement p = db.Procurement.Find(id);
            if (p != null)
            {
                db.Procurement.Remove(p);
            }
        }

        public Procurement GetItem(int id)
        {
            return db.Procurement.Find(id);
        }

        public List<Procurement> GetList()
        {
            return db.Procurement.ToList();
        }

        public void Update(Procurement item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
