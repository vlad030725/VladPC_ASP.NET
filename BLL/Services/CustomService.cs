using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.PortableExecutable;
using Interfaces.Services;
using Interfaces.DTO;
using Interfaces.Repository;
using DomainModel;

namespace BLL.Services
{
    public class CustomService : ICustomService
    {
        private IDbRepos db;

        public CustomService(IDbRepos db)
        {
            this.db = db;
        }

        public List<CustomDto> GetAllCustoms()
        {
            return db.Custom.GetList().Select(i => new CustomDto(i, GetCustomRowsOneCustom(i.Id))).ToList();
        }

        public CustomDto GetCustomInCart(int IdUser)
        {
            Custom customTmp;
            try
            {
                customTmp = db.Custom.GetList().Single(i => i.IdUser == IdUser && i.IdStatus == 1);
            }
            catch
            {
                CreateCustomInCart(IdUser);
                customTmp = db.Custom.GetList().Single(i => i.IdUser == IdUser && i.IdStatus == 1);
            }
            return new CustomDto(customTmp, GetCustomRowsOneCustom(customTmp.Id));
        }

        public CustomDto GetCustom(int IdCustom)
        {
            return new CustomDto(db.Custom.GetItem(IdCustom), GetCustomRowsOneCustom(IdCustom));
        }

        public List<CustomRowDto> GetCustomRowsOneCustom(int Id)
        {
            return db.CustomRow.GetList().Select(i => new CustomRowDto(i, GetAllProducts())).Where(i => i.IdCustom == Id).ToList();
        }

        public bool IsContainInCart(int IdUser, int IdProduct)
        {
            return GetCustomInCart(IdUser).CustomRows.Select(i => i.Product.Id).Contains(IdProduct);
        }

        public ProductDto GetProduct(int Id)
        {
            return new ProductDto(db.Product.GetItem(Id), GetAllCompanies(),
                GetAllTypesProducts(), GetAllSockets(),
                GetAllTypesMemory(), GetAllFormFactors());
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

        public List<ProductDto> GetAllProducts()
        {
            return db.Product.GetList().Select(i => new ProductDto(i, GetAllCompanies(),
                GetAllTypesProducts(), GetAllSockets(),
                GetAllTypesMemory(), GetAllFormFactors())).ToList();
        }

        public List<StatusDto> GetAllStatuses()
        {
            return db.Status.GetList().Select(i => new StatusDto(i)).ToList();
        }

        public List<TypeMemoryDto> GetAllTypesMemory()
        {
            return db.TypeMemory.GetList().Select(i => new TypeMemoryDto(i)).ToList();
        }

        public List<FormFactorDto> GetAllFormFactors()
        {
            return db.FormFactor.GetList().Select(i => new FormFactorDto(i)).ToList();
        }

        public List<CustomDto> GetCustomHistory(int IdUser)
        {
            return db.Custom.GetList().Where(i => i.IdUser == IdUser && i.IdStatus != 1).Select(i => new CustomDto(i, GetCustomRowsOneCustom(i.Id))).ToList();
        }

        public List<CustomDto> GetAllCustomsExcludeCart()
        {
            return db.Custom.GetList()
                .Select(i => new CustomDto(i, GetCustomRowsOneCustom(i.Id)))
                .Where(i => i.CreatedDate != null).ToList();
        }

        public void UpdateCustomRow(CustomRowDto row)
        {
            CustomRow cr = db.CustomRow.GetItem(row.Id);
            cr.Price = row.Price;
            cr.Count = row.Count;
            Save();
        }

        public void DeleteCustomRow(int Id)
        {
            CustomRow cr = db.CustomRow.GetItem(Id);
            if (cr != null)
            {
                db.CustomRow.Delete(cr.Id);
                Save();
            }
        }

        public void AddCustomRow(ProductDto pr, int IdUser)
        {
            db.CustomRow.Create(new CustomRow()
            {
                IdCustom = GetCustomInCart(IdUser).Id,
                IdProduct = pr.Id,
                Price = pr.Price,
                Count = 1
            });
            Save();
        }

        public void MakeCustom(int IdUser)
        {
            CustomDto custom = GetCustomInCart(IdUser);
            custom.IdStatus = 3;
            custom.CreatedDate = DateTime.Now;
            //custom.Sum = custom.CustomRows.Select(i => i.Price * i.Count).Sum();

            List<CustomRowDto> customRows = GetCustomRowsOneCustom(custom.Id);

            for (int i = 0; i < customRows.Count; i++)
            {
                Product p = db.Product.GetItem(customRows[i].Product.Id);
                p.Count -= customRows[i].Count;

                Save();
            }

            UpdateCustom(custom);

            CreateCustomInCart(IdUser);
        }

        public void CreateCustom(CustomDto custom)
        {
            db.Custom.Create(new Custom()
            {
                IdUser = custom.IdUser,
                IdStatus = custom.IdStatus,
                IdPromoCode = custom.IdPromoCode,
                CreatedDate = DateTime.Now,
                Sum = custom.Sum
            });
        }

        public void CreateCustomInCart(int IdUser)
        {
            db.Custom.Create(new Custom()
            {
                IdUser = IdUser,
                IdStatus = 1
            });
            Save();
        }

        public void UpdateCustom(CustomDto custom)
        {
            Custom c = db.Custom.GetItem(custom.Id);
            c.IdUser = custom.IdUser;
            c.IdStatus = custom.IdStatus;
            c.IdPromoCode = custom.IdPromoCode;
            c.CreatedDate = custom.CreatedDate;
            c.Sum = custom.Sum;
            Save();
        }

        public void DeleteCustom(int Id)
        {
            db.Custom.Delete(Id);
        }

        public PromoCodeDto Discount(string Code)
        {
            try
            {
                return db.PromoCode.GetList().Select(i => new PromoCodeDto(i)).Single(i => i.Code == Code);
            }
            catch
            {
                return null;
            }
        }

        public PromoCodeDto Discount(int? Id)
        {
            try
            {
                return db.PromoCode.GetList().Select(i => new PromoCodeDto(i)).Single(i => i.Id == Id);
            }
            catch
            {
                return null;
            }
        }

        public bool Save()
        {
            if (db.Save() > 0) return true;
            return false;
        }
    }
}
