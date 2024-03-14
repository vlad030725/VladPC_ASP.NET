using DAL.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.RepositoryPgs
{
    public class TypeProductRepositoryPgs : IRepository<TypeProduct>
    {
        private ComputerStoreContext db;
        public TypeProductRepositoryPgs(ComputerStoreContext db)
        {
            this.db = db;
        }
        public void Create(TypeProduct item)
        {
            db.TypeProduct.Add(item);
        }

        public void Delete(int id)
        {
            TypeProduct tp = db.TypeProduct.Find(id);
            if (tp != null)
            {
                db.TypeProduct.Remove(tp);
            }
        }

        public TypeProduct GetItem(int id)
        {
            return db.TypeProduct.Find(id);
        }

        public List<TypeProduct> GetList()
        {
            return db.TypeProduct.ToList();
        }

        public void Update(TypeProduct item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
