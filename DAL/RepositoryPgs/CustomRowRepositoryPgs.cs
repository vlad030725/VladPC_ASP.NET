using DAL.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.RepositoryPgs
{
    public class CustomRowRepositoryPgs : IRepository<CustomRow>
    {
        private ComputerStoreContext db;
        public CustomRowRepositoryPgs(ComputerStoreContext db)
        {
            this.db = db;
        }
        public void Create(CustomRow item)
        {
            db.CustomRow.Add(item);
        }

        public void Delete(int id)
        {
            CustomRow c = db.CustomRow.Find(id);
            if (c != null)
            {
                db.CustomRow.Remove(c);
            }
        }

        public CustomRow GetItem(int id)
        {
            return db.CustomRow.Find(id);
        }

        public List<CustomRow> GetList()
        {
            return db.CustomRow.ToList();
        }

        public void Update(CustomRow item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
