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
    public class FormFactorRepositoryPgs : IRepository<FormFactor>
    {
        private ComputerStoreContext db;
        public FormFactorRepositoryPgs(ComputerStoreContext db)
        {
            this.db = db;
        }
        public void Create(FormFactor item)
        {
            db.FormFactor.Add(item);
        }

        public void Delete(int id)
        {
            FormFactor ff = db.FormFactor.Find(id);
            if (ff != null)
            {
                db.FormFactor.Remove(ff);
            }
        }

        public FormFactor GetItem(int id)
        {
            return db.FormFactor.Find(id);
        }

        public List<FormFactor> GetList()
        {
            return db.FormFactor.ToList();
        }

        public void Update(FormFactor item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
