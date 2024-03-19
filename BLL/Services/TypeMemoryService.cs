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
    public class TypeMemoryService : ITypeMemoryService
    {
        private IDbRepos db;

        public TypeMemoryService(IDbRepos db)
        {
            this.db = db;
        }

        public void CreateTypeMemory(TypeMemoryDto typeMemory)
        {
            db.TypeMemory.Create(new TypeMemory()
            {
                Name = typeMemory.Name,
            });
            SaveChanges();
        }

        public void DeleteTypeMemory(int id)
        {
            db.TypeMemory.Delete(id);
            SaveChanges();
        }

        public TypeMemoryDto GetTypeMemory(int id)
        {
            return new TypeMemoryDto(db.TypeMemory.GetItem(id));
        }

        public List<TypeMemoryDto> GetTypesMemory()
        {
            return db.TypeMemory.GetList().Select(i => new TypeMemoryDto(i)).ToList();
        }

        public void UpdateTypeMemory(TypeMemoryDto typeMemory)
        {
            TypeMemory tm = db.TypeMemory.GetItem(typeMemory.Id);
            if (tm == null)
            {
                return;
            }
            tm.Name = typeMemory.Name;
            SaveChanges();
        }

        public bool SaveChanges()
        {
            if (db.Save() > 0) return true;
            return false;
        }
    }
}
