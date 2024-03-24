using DomainModel;
using Interfaces.DTO;
using Interfaces.Repository;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SocketService : ISocketService
    {
        private IDbRepos db;

        public SocketService(IDbRepos db)
        {
            this.db = db;
        }

        public void CreateSocket(SocketDto socket)
        {
            db.Socket.Create(new Socket()
            {
                Name = socket.Name,
            });
            SaveChanges();
        }

        public void DeleteSocket(int id)
        {
            db.Socket.Delete(id);
            SaveChanges();
        }

        public List<SocketDto> GetSockets()
        {
            return db.Socket.GetList().Select(i => new SocketDto(i)).ToList();
        }

        public SocketDto GetSocket(int id)
        {
            return new SocketDto(db.Socket.GetItem(id));
        }

        public void UpdateSocket(SocketDto socket)
        {
            Socket s = db.Socket.GetItem(socket.Id);
            if (s == null)
            {
                return;
            }
            s.Name = socket.Name;
            SaveChanges();
        }

        public bool SaveChanges()
        {
            if (db.Save() > 0) return true;
            return false;
        }
    }
}
