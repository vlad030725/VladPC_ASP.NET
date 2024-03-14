using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class ProductDto
    {

        public ProductDto(Product p, List<CompanyDto> companies,
            List<TypeProductDto> typeProducts, List<SocketDto> sockets,
            List<TypeMemoryDto> typesMemory, List<FormFactorDto> formFactors)
        {
            Id = p.Id;
            CompanyList = companies;
            Name = p.Name;
            Price = p.Price;
            Count = p.Count;
            IdCompany = p.IdCompany;
            Company = companies.Single(i => i.Id == IdCompany).Name;
            IdTypeProduct = p.IdTypeProduct;
            TypeProduct = typeProducts.Single(i => i.Id == IdTypeProduct).Name;
            CountCores = p.CountCores;
            CountStreams = p.CountStreams;
            Frequency = p.Frequency;
            IdSocket = p.IdSocket;
            CountMemory = p.CountMemory;
            IdTypeMemory = p.IdTypeMemory;
            IdFormFactor = p.IdFormFactor;

            CatalogString = $"[Производитель: {Company}; ";
            if (CountCores != null)
            {
                CatalogString += $"Ядра/потоки: {CountCores}/{CountStreams}; ";
            }
            if (Frequency != null)
            {
                CatalogString += $"Частота: {Frequency}; ";
            }
            if (IdSocket != null)
            {
                CatalogString += $"Сокет: {sockets.Single(i => i.Id == IdSocket).Name}; ";
            }
            if (CountMemory != null)
            {
                CatalogString += $"Объём памяти: {CountMemory} Гб; ";
            }
            if (IdTypeMemory != null)
            {
                CatalogString += $"Тип памяти: {typesMemory.Single(i => i.Id == IdTypeMemory).Name}; ";
            }
            if (IdFormFactor != null)
            {
                CatalogString += $"Форм-фактор: {formFactors.Single(i => i.Id == IdFormFactor).Name}; ";
            }
            CatalogString += "]";
        }

        public ProductDto() { }

        public int Id { get; set; }

        public string Name { get; set; }

        public int? Price { get; set; }

        public int? Count { get; set; }

        public int? IdCompany { get; set; }
        public string Company { get; set; }

        public int? IdTypeProduct { get; set; }
        //public string TypeProduct { get; set; }
        public string TypeProduct { get; set; }

        public int? CountCores { get; set; }

        public int? CountStreams { get; set; }

        public int? Frequency { get; set; }

        public int? IdSocket { get; set; }

        public int? CountMemory { get; set; }

        public int? IdTypeMemory { get; set; } //Доделать названия и посылать в конструктор сервисы

        public int? IdFormFactor { get; set; }

        public List<CompanyDto> CompanyList { get; set; }
        public List<TypeProduct> TypeProductsList { get; set; }

        public string CatalogString { get; set; }
    }
}
