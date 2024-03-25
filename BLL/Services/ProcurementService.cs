using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Services;
using Interfaces.DTO;
using Interfaces.Repository;
using DomainModel;

namespace BLL.Services
{
    public class ProcurementService : IProcurementService
    {
        private IDbRepos db;

        public ProcurementService(IDbRepos db)
        {
            this.db = db;
        }

        public bool IsContainInFillingProcurement(int IdProduct)
        {
            return GetProcurementInFilling().ProcurementRows.Select(i => i.IdProduct).Contains(IdProduct);
        }

        public ProcurementDto GetProcurementInFilling()
        {
            try
            {
                return GetAllProcurements().Single(i => i.CreatedDate == null);
            }
            catch
            {
                db.Procurement.Create(new Procurement());
                Save();
                return GetAllProcurements().Single(i => i.CreatedDate == null);
            }

        }

        public List<ProcurementDto> GetAllProcurements()
        {
            return db.Procurement.GetList().Select(i => new ProcurementDto(i, GetProcurementRows(i.Id))).ToList();
        }

        public ProcurementDto GetProcurement(int Id)
        {
            return new ProcurementDto(db.Procurement.GetItem(Id), GetProcurementRows(Id));
        }

        public void CreateProcurement(ProcurementDto procurement)
        {
            db.Procurement.Create(new Procurement()
            {
                Sum = procurement.Sum,
                CreatedDate = DateTime.Now,
            });
            Save();
        }

        public List<ProcurementRowDto> GetProcurementRows(int IdProcurement)
        {
            return db.ProcurementRow.GetList().Select(i => new ProcurementRowDto(i, GetAllProducts())).Where(i => i.IdProcurement == IdProcurement).ToList();
        }

        public List<ProductDto> GetAllProducts()
        {
            return db.Product.GetList().Select(i => new ProductDto(i, GetAllCompanies(),
                GetAllTypesProducts(), GetAllSockets(),
                GetAllTypesMemory(), GetAllFormFactors())).ToList();
        }

        public List<CompanyDto> GetAllCompanies()
        {
            return db.Company.GetList().Select(i => new CompanyDto(i)).ToList();
        }

        public List<SocketDto> GetAllSockets()
        {
            return db.Socket.GetList().Select(i => new SocketDto(i)).ToList();
        }

        public List<TypeProductDto> GetAllTypesProducts()
        {
            return db.TypeProduct.GetList().Select(i => new TypeProductDto(i)).ToList();
        }

        public List<TypeMemoryDto> GetAllTypesMemory()
        {
            return db.TypeMemory.GetList().Select(i => new TypeMemoryDto(i)).ToList();
        }

        public List<FormFactorDto> GetAllFormFactors()
        {
            return db.FormFactor.GetList().Select(i => new FormFactorDto(i)).ToList();
        }

        public void AddProcurement()
        {
            ProcurementDto pr = GetProcurementInFilling();
            pr.CreatedDate = DateTime.Now;
            pr.Sum = GetProcurementRows(pr.Id).Select(i => i.Count * i.Price).Sum();

            List<ProcurementRowDto> procurementRows = GetProcurementRows(pr.Id);

            for (int i = 0; i < procurementRows.Count; i++)
            {
                Product p = db.Product.GetItem(procurementRows[i].Product.Id);
                p.Count += procurementRows[i].Count;

                Save();
            }

            UpdateProcurement(pr);

            Save();
        }

        public void UpdateProcurement(ProcurementDto procurement)
        {
            Procurement pr = db.Procurement.GetItem(procurement.Id);
            pr.CreatedDate = procurement.CreatedDate;
            pr.Sum = procurement.Sum;
            Save();
        }

        public void DeleteProcurement(int Id)
        {
            db.Procurement.Delete(Id);
            Save();
        }

        public void AddProcurementRow(ProductDto pr, int count, int price)
        {
            db.ProcurementRow.Create(new ProcurementRow()
            {
                IdProcurement = GetProcurementInFilling().Id,
                IdProduct = pr.Id,
                Price = price,
                Count = count
            });
            Save();
        }

        public void DeleteProcurementRow(int Id)
        {
            ProcurementRow pr = db.ProcurementRow.GetItem(Id);
            if (pr != null)
            {
                db.ProcurementRow.Delete(pr.Id);
                Save();
            }
        }

        public void UpdateProcurementRow(ProcurementRowDto pr)
        {
            ProcurementRow cr = db.ProcurementRow.GetItem(pr.Id);
            cr.Price = pr.Price;
            cr.Count = pr.Count;
            Save();
        }

        public List<ProcurementDto> GetProcurementHistory()
        {
            return db.Procurement.GetList().Where(i => i.CreatedDate != null).Select(i => new ProcurementDto(i, GetProcurementRows(i.Id))).ToList();
        }

        public bool Save()
        {
            if (db.Save() > 0) return true;
            return false;
        }
    }
}
