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
    public class ProductService : IProductService
    {
        private IDbRepos db;

        public ProductService(IDbRepos db)
        {
            this.db = db;
        }

        public List<ProductDto> GetAllProducts()
        {
            return db.Product.GetList().Select(i => new ProductDto(i, GetAllCompanies(),
                GetAllTypesProducts(), GetAllSockets(),
                GetAllTypesMemory(), GetAllFormFactors())).ToList();
        }

        public ProductDto GetProduct(int Id)
        {
            return GetAllProducts().Single(i => i.Id == Id);
        }

        public List<ProductDto> GetAllProductsOneCustom(int Id)
        {
            List<CustomRow> CustomRows = db.CustomRow.GetList().Where(i => i.IdCustom == Id).ToList();
            List<int> idCustomRows = CustomRows.Select(i => i.Id).ToList();

            List<ProductDto> AllProducts = GetAllProducts();

            List<ProductDto> products = new List<ProductDto>();

            int j = -1;
            for (int i = 0; i < AllProducts.Count; i++)
            {
                if (idCustomRows.Contains(AllProducts[i].Id))
                {
                    products.Add(AllProducts[i]);
                    j++;
                    for (int k = 0; k < CustomRows.Count; k++)
                    {
                        if (CustomRows[k].IdProduct == products[j].Id)
                        {
                            products[j].Count = CustomRows[k].Count;
                            products[j].Price = CustomRows[k].Price;
                        }
                    }
                }
            }

            return products;
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

        public void CreateProduct(ProductDto product)
        {
            db.Product.Create(new Product()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Count = 0,
                IdCompany = product.IdCompany,
                IdTypeProduct = product.IdTypeProduct,
                CountCores = product.CountCores,
                CountStreams = product.CountStreams,
                Frequency = product.Frequency,
                IdSocket = product.IdSocket,
                CountMemory = product.CountMemory,
                IdTypeMemory = product.IdTypeMemory,
                IdFormFactor = product.IdFormFactor,
            });
            Save();
        }

        public void UpdateProduct(ProductDto product)
        {
            Product pr = db.Product.GetItem(product.Id);
            pr.Id = product.Id;
            pr.Name = product.Name;
            pr.Price = product.Price;
            pr.IdCompany = product.IdCompany;
            pr.CountCores = product.CountCores;
            pr.CountStreams = product.CountStreams;
            pr.Frequency = product.Frequency;
            pr.IdSocket = product.IdSocket;
            pr.CountMemory = product.CountMemory;
            pr.IdTypeMemory = product.IdTypeMemory;
            pr.IdFormFactor = product.IdFormFactor;
            Save();
        }

        public void DeleteProduct(int Id)
        {
            db.Product.Delete(Id);
            Save();
        }

        public TypeProductDto GetTypeProduct(int IdProduct)
        {
            return new TypeProductDto(db.TypeProduct.GetItem((int)GetAllProducts().Single(i => i.Id == IdProduct).IdTypeProduct));
        }

        public bool IsContainInCustomsOrProcurement(int Id)
        {
            return GetAllCustomRows().Select(i => i.IdProduct).Contains(Id) || GetAllProcurementRows().Select(i => i.IdProduct).Contains(Id);
        }

        private List<CustomRowDto> GetAllCustomRows()
        {
            return db.CustomRow.GetList().Select(i => new CustomRowDto(i, GetAllProducts())).ToList();
        }

        private List<ProcurementRowDto> GetAllProcurementRows()
        {
            return db.ProcurementRow.GetList().Select(i => new ProcurementRowDto(i, GetAllProducts())).ToList();
        }

        public bool Save()
        {
            if (db.Save() > 0) return true;
            return false;
        }
    }
}
