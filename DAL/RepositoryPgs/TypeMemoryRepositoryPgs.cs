using DAL.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.RepositoryPgs
{
    public class TypeMemoryRepositoryPgs : IRepository<TypeMemory>
    {
        private ComputerStoreContext db;
        public TypeMemoryRepositoryPgs(ComputerStoreContext db)
        {
            this.db = db;
        }
        public void Create(TypeMemory item)
        {
            db.TypeMemory.Add(item);
        }

        public void Delete(int id)
        {
            TypeMemory tm = db.TypeMemory.Find(id);
            if (tm != null)
            {
                db.TypeMemory.Remove(tm);
            }
        }

        public TypeMemory GetItem(int id)
        {
            return db.TypeMemory.Find(id);
        }

        public List<TypeMemory> GetList()
        {
            return db.TypeMemory.ToList();
        }

        public void Update(TypeMemory item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
