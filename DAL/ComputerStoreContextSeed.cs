using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ComputerStoreContextSeed
    {
        public static async Task SeedAsync(ComputerStoreContext context)
        {
            try
            {
                if (context.Company.Any())
                {
                    return;
                }

                IEnumerable<Company> CompanyData = new List<Company>
                {
                    new Company() { Name = "Intel" },
                    new Company() { Name = "AMD" },
                    new Company() { Name = "NVidia" }
                };

                context.AddRange(CompanyData);

                IList<TypeProduct> TypeProductData = new List<TypeProduct>
                {
                    new TypeProduct() { Name = "Процессор" },
                    new TypeProduct() { Name = "Видеокарта" }
                };

                context.AddRange(TypeProductData);

                IList<Socket> SocketData = new List<Socket>
                {
                    new Socket() { Name = "LGA1700" },
                    new Socket() { Name = "LGA1200" },
                    new Socket() { Name = "AM5" },
                    new Socket() { Name = "AM3+" },
                    new Socket() { Name = "LGA 1151-v2" },
                    new Socket() { Name = "LGA 1151" },
                    new Socket() { Name = "LGA 2066" },
                    new Socket() { Name = "sWRX8" },
                    new Socket() { Name = "AM4" },
                };

                context.AddRange(SocketData);

                IList<Status> StatusData = new List<Status>
                {
                    new Status() { Name = "В корзине" },
                    new Status() { Name = "В пути" },
                    new Status() { Name = "Готов к выдачи" },
                    new Status() { Name = "Получен" }
                };

                context.AddRange(StatusData);

                IList<TypeMemory> TypeMemoryData = new List<TypeMemory>()
                {
                    new TypeMemory() { Name = "GDDR5" },
                    new TypeMemory() { Name = "GDDR6" },
                    new TypeMemory() { Name = "GDDR6X" },
                    new TypeMemory() { Name = "DDR5" },
                    new TypeMemory() { Name = "DDR4" },
                    new TypeMemory() { Name = "DDR3" },
                };

                context.AddRange(TypeMemoryData);

                IList<FormFactor> FormFactorData = new List<FormFactor>()
                {
                    new FormFactor() { Name = "Standart-ATX" },
                    new FormFactor() { Name = "mini-ATX" },
                    new FormFactor() { Name = "micro-ATX" },
                };

                context.AddRange(FormFactorData);

                IList<PromoCode> PromoCodeData = new List<PromoCode>()
                {
                    new PromoCode() { Code = "POLTOS", Discount = 0.05 }
                };

                context.AddRange(PromoCodeData);

                context.SaveChanges();

                IList<Product> ProductData = new List<Product>()
                {
                    new Product() { Name = "i7-11700F", Price = 30899, Count = 3, IdCompany = 1, IdTypeProduct = 1, CountCores = 8, CountStreams = 16, Frequency = 2500, IdSocket = 2, CountMemory = null, IdTypeMemory = null, IdFormFactor = null },
                    new Product() { Name = "i3-13100F", Price = 12399, Count = 3, IdCompany = 1, IdTypeProduct = 1, CountCores = 4, CountStreams = 8, Frequency = 3400, IdSocket = 1, CountMemory = null, IdTypeMemory = null, IdFormFactor = null },
                    new Product() { Name = "Ryzen 7 5800X3D", Price = 36799, Count = 2, IdCompany = 2, IdTypeProduct = 1, CountCores = 8, CountStreams = 16, Frequency = 3400, IdSocket = 3, CountMemory = null, IdTypeMemory = null, IdFormFactor = null },
                    new Product() { Name = "Ryzen 3 3200G", Price = 9099, Count = 2, IdCompany = 2, IdTypeProduct = 1, CountCores = 4, CountStreams = 4, Frequency = 3600, IdSocket = 3, CountMemory = null, IdTypeMemory = null, IdFormFactor = null },
                    new Product() { Name = "Ryzen Threadripper PRO 5995WX", Price = 714999, Count = 1, IdCompany = 2, IdTypeProduct = 1, CountCores = 64, CountStreams = 64, Frequency = 2700, IdSocket = 8, CountMemory = null, IdTypeMemory = null, IdFormFactor = null },
                    new Product() { Name = "GeForce RTX 4060 Ti", Price = 43499, Count = 4, IdCompany = 3, IdTypeProduct = 2, CountCores = null, CountStreams = null, Frequency = 2310, IdSocket = null, CountMemory = 8, IdTypeMemory = 2, IdFormFactor = null },
                    new Product() { Name = "GeForce RTX 4090", Price = 199999, Count = 2, IdCompany = 3, IdTypeProduct = 2, CountCores = null, CountStreams = null, Frequency = 2230, IdSocket = null, CountMemory = 24, IdTypeMemory = 3, IdFormFactor = null },
                    new Product() { Name = "Arc A770", Price = 30999, Count = 4, IdCompany = 1, IdTypeProduct = 2, CountCores = null, CountStreams = null, Frequency = 2100, IdSocket = null, CountMemory = 8, IdTypeMemory = 2, IdFormFactor = null },
                    new Product() { Name = "Radeon RX 7800 XT", Price = 65999, Count = 1, IdCompany = 2, IdTypeProduct = 2, CountCores = null, CountStreams = null, Frequency = 2430, IdSocket = null, CountMemory = 16, IdTypeMemory = 2, IdFormFactor = null },
                };

                context.AddRange(ProductData);

                IList<Custom> CustomData = new List<Custom>()
                {
                    new Custom() { IdUser = 1, IdStatus = 3, IdPromoCode = null, CreatedDate = DateTime.Now.AddDays(-3), Sum = 0 },
                    new Custom() { IdUser = 2, IdStatus = 3, IdPromoCode = null, CreatedDate = DateTime.Now.AddDays(-5), Sum = 0 },
                    new Custom() { IdUser = 1, IdStatus = 3, IdPromoCode = null, CreatedDate = DateTime.Now.AddDays(-6), Sum = 0 },
                    new Custom() { IdUser = 2, IdStatus = 3, IdPromoCode = null, CreatedDate = DateTime.Now.AddDays(-7), Sum = 0 },
                    new Custom() { IdUser = 2, IdStatus = 3, IdPromoCode = null, CreatedDate = DateTime.Now.AddDays(-9), Sum = 0 }
                };

                context.AddRange(CustomData);
                context.SaveChanges();

                IList<CustomRow> CustomRowData = new List<CustomRow>()
                {
                    new CustomRow() { IdCustom = 1, IdProduct = 1, Price = 32899, Count = 1 },
                    new CustomRow() { IdCustom = 1, IdProduct = 6, Price = 43499, Count = 1 },
                    new CustomRow() { IdCustom = 2, IdProduct = 5, Price = 714999, Count = 1 },
                    new CustomRow() { IdCustom = 3, IdProduct = 2, Price = 12399, Count = 10 },
                    new CustomRow() { IdCustom = 4, IdProduct = 2, Price = 12399, Count = 1 },
                    new CustomRow() { IdCustom = 4, IdProduct = 2, Price = 12399, Count = 1 },
                    new CustomRow() { IdCustom = 4, IdProduct = 4, Price = 10099, Count = 1 },
                    new CustomRow() { IdCustom = 4, IdProduct = 8, Price = 29999, Count = 1 },
                    new CustomRow() { IdCustom = 4, IdProduct = 6, Price = 43499, Count = 2 },
                    new CustomRow() { IdCustom = 5, IdProduct = 7, Price = 210999, Count = 1 }
                };

                foreach (var item in CustomRowData)
                {
                    context.Add(item);
                }

                context.SaveChanges();

                IList<Procurement> ProcurementData = new List<Procurement>()
                {
                    new Procurement() { CreatedDate = DateTime.Now.AddDays(-4), Sum = 0 },
                    new Procurement() { CreatedDate = DateTime.Now.AddDays(-6), Sum = 0 },
                    new Procurement() { CreatedDate = DateTime.Now.AddDays(-7), Sum = 0 },
                    new Procurement() { CreatedDate = DateTime.Now.AddDays(-8), Sum = 0 },
                    new Procurement() { CreatedDate = DateTime.Now.AddDays(-9), Sum = 0 },
                };

                context.AddRange(ProcurementData);
                context.SaveChanges();

                IList<ProcurementRow> ProcurementRowData = new List<ProcurementRow>()
                {
                    new ProcurementRow() { IdProcurement = 1, IdProduct = 1, Price = 30899, Count = 1 },
                    new ProcurementRow() { IdProcurement = 1, IdProduct = 6, Price = 40499, Count = 1 },
                    new ProcurementRow() { IdProcurement = 2, IdProduct = 5, Price = 690999, Count = 1 },
                    new ProcurementRow() { IdProcurement = 3, IdProduct = 2, Price = 9399, Count = 10 },
                    new ProcurementRow() { IdProcurement = 3, IdProduct = 2, Price = 9499, Count = 1 },
                    new ProcurementRow() { IdProcurement = 3, IdProduct = 2, Price = 11399, Count = 1 },
                    new ProcurementRow() { IdProcurement = 4, IdProduct = 4, Price = 8099, Count = 1 },
                    new ProcurementRow() { IdProcurement = 5, IdProduct = 8, Price = 32999, Count = 1 },
                    new ProcurementRow() { IdProcurement = 5, IdProduct = 6, Price = 41499, Count = 2 },
                    new ProcurementRow() { IdProcurement = 5, IdProduct = 7, Price = 200999, Count = 1 }
                };



                foreach (var item in ProcurementRowData)
                {
                    context.Add(item);
                }


                context.AddRange(ProcurementRowData);

                context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
