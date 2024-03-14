using DAL.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.RepositoryPgs
{
    public class SocketRepositoryPgs : IRepository<Socket>
    {
        private ComputerStoreContext db;
        public SocketRepositoryPgs(ComputerStoreContext db)
        {
            this.db = db;
        }
        public void Create(Socket item)
        {
            db.Socket.Add(item);
        }

        public void Delete(int id)
        {
            Socket s = db.Socket.Find(id);
            if (s != null)
            {
                db.Socket.Remove(s);
            }
        }

        public Socket GetItem(int id)
        {
            return db.Socket.Find(id);
        }

        public List<Socket> GetList()
        {
            return db.Socket.ToList();
        }

        public void Update(Socket item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
