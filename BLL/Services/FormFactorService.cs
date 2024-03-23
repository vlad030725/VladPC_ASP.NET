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
    public class FormFactorService : IFormFactorService
    {
        private IDbRepos db;

        public FormFactorService(IDbRepos db)
        {
            this.db = db;
        }

        public void CreateFormFactor(FormFactorDto formFactor)
        {
            db.FormFactor.Create(new FormFactor()
            {
                Name = formFactor.Name,
            });
            SaveChanges();
        }

        public void DeleteFormFactor(int id)
        {
            db.FormFactor.Delete(id);
            SaveChanges();
        }

        public FormFactorDto GetFormFactor(int id)
        {
            return new FormFactorDto(db.FormFactor.GetItem(id));
        }

        public List<FormFactorDto> GetFormFactors()
        {
            return db.FormFactor.GetList().Select(i => new FormFactorDto(i)).ToList();
        }

        public void UpdateFormFactor(FormFactorDto formFactor)
        {
            FormFactor ff = db.FormFactor.GetItem(formFactor.Id);
            if (ff == null)
            {
                return;
            }
            ff.Name = formFactor.Name;
            SaveChanges();
        }

        public bool SaveChanges()
        {
            if (db.Save() > 0) return true;
            return false;
        }
    }
}
