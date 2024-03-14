using DAL.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.RepositoryPgs
{
    public class ProductRepositoryPgs : IRepository<Product>
    {
        private ComputerStoreContext db;
        public ProductRepositoryPgs(ComputerStoreContext db)
        {
            this.db = db;
        }
        public void Create(Product item)
        {
            db.Product.Add(item);
        }

        public void Delete(int id)
        {
            Product pr = db.Product.Find(id);
            if (pr != null)
            {
                db.Product.Remove(pr);
            }
        }

        public Product GetItem(int id)
        {
            return db.Product.Find(id);
        }

        public List<Product> GetList()
        {
            return db.Product.ToList();
        }

        public void Update(Product item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
