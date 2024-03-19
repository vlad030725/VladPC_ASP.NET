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
    public class TypeProductService : ITypeProductService
    {
        private IDbRepos db;

        public TypeProductService(IDbRepos db)
        {
            this.db = db;
        }

        public void CreateTypeProduct(TypeProductDto typeProduct)
        {
            db.TypeProduct.Create(new TypeProduct()
            {
                Name = typeProduct.Name,
            });
            SaveChanges();
        }

        public void DeleteTypeProduct(int id)
        {
            db.TypeProduct.Delete(id);
            SaveChanges();
        }

        public TypeProductDto GetTypeProduct(int id)
        {
            return new TypeProductDto(db.TypeProduct.GetItem(id));
        }

        public List<TypeProductDto> GetTypesProduct()
        {
            return db.TypeProduct.GetList().Select(i => new TypeProductDto(i)).ToList();
        }

        public void UpdateTypeProduct(TypeProductDto typeProduct)
        {
            TypeProduct tp = db.TypeProduct.GetItem(typeProduct.Id);
            if (tp == null)
            {
                return;
            }
            tp.Name = typeProduct.Name;
            SaveChanges();
        }

        public bool SaveChanges()
        {
            if (db.Save() > 0) return true;
            return false;
        }
    }
}
