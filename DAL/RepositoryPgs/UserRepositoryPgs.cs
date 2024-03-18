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
    public class UserRepositoryPgs : IRepository<User>
    {
        private ComputerStoreContext db;
        public UserRepositoryPgs(ComputerStoreContext db)
        {
            this.db = db;
        }
        public void Create(User item)
        {
            db.User.Add(item);
        }

        public void Delete(int id)
        {
            User u = db.User.Find(id);
            if (u != null)
            {
                db.User.Remove(u);
            }
        }

        public User GetItem(int id)
        {
            return db.User.Find(id);
        }

        public List<User> GetList()
        {
            return db.User.ToList();
        }

        public void Update(User item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
