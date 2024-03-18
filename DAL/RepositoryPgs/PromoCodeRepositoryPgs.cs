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
    public class PromoCodeRepositoryPgs : IRepository<PromoCode>
    {
        private ComputerStoreContext db;
        public PromoCodeRepositoryPgs(ComputerStoreContext db)
        {
            this.db = db;
        }
        public void Create(PromoCode item)
        {
            db.PromoCode.Add(item);
        }

        public void Delete(int id)
        {
            PromoCode s = db.PromoCode.Find(id);
            if (s != null)
            {
                db.PromoCode.Remove(s);
            }
        }

        public PromoCode GetItem(int id)
        {
            return db.PromoCode.Find(id);
        }

        public List<PromoCode> GetList()
        {
            return db.PromoCode.ToList();
        }

        public void Update(PromoCode item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
