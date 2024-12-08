using DomainModel;
using Interfaces.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VladPC_ASP.NET.Tests.Mocks
{
    public static class MockProductRepository
    {
        public static List<Product> Products = new List<Product>()
        {
            new Product() { Id = 1, Name = "i7-11700F", Price = 30899, Count = 3, IdCompany = 1, IdTypeProduct = 1, CountCores = 8, CountStreams = 16, Frequency = 2500, IdSocket = 2, CountMemory = null, IdTypeMemory = null, IdFormFactor = null },
            new Product() { Id = 2, Name = "i3-13100F", Price = 12399, Count = 3, IdCompany = 1, IdTypeProduct = 1, CountCores = 4, CountStreams = 8, Frequency = 3400, IdSocket = 1, CountMemory = null, IdTypeMemory = null, IdFormFactor = null },
            new Product() { Id = 3, Name = "Ryzen 7 5800X3D", Price = 36799, Count = 2, IdCompany = 2, IdTypeProduct = 1, CountCores = 8, CountStreams = 16, Frequency = 3400, IdSocket = 3, CountMemory = null, IdTypeMemory = null, IdFormFactor = null },
            new Product() { Id = 4, Name = "Ryzen 3 3200G", Price = 9099, Count = 2, IdCompany = 2, IdTypeProduct = 1, CountCores = 4, CountStreams = 4, Frequency = 3600, IdSocket = 3, CountMemory = null, IdTypeMemory = null, IdFormFactor = null },
            new Product() { Id = 5, Name = "Ryzen Threadripper PRO 5995WX", Price = 714999, Count = 1, IdCompany = 2, IdTypeProduct = 1, CountCores = 64, CountStreams = 64, Frequency = 2700, IdSocket = 8, CountMemory = null, IdTypeMemory = null, IdFormFactor = null },
            new Product() { Id = 6, Name = "GeForce RTX 4060 Ti", Price = 43499, Count = 4, IdCompany = 3, IdTypeProduct = 2, CountCores = null, CountStreams = null, Frequency = 2310, IdSocket = null, CountMemory = 8, IdTypeMemory = 2, IdFormFactor = null },
            new Product() { Id = 7, Name = "GeForce RTX 4090", Price = 199999, Count = 2, IdCompany = 3, IdTypeProduct = 2, CountCores = null, CountStreams = null, Frequency = 2230, IdSocket = null, CountMemory = 24, IdTypeMemory = 3, IdFormFactor = null },
            new Product() { Id = 8, Name = "Arc A770", Price = 30999, Count = 4, IdCompany = 1, IdTypeProduct = 2, CountCores = null, CountStreams = null, Frequency = 2100, IdSocket = null, CountMemory = 8, IdTypeMemory = 2, IdFormFactor = null },
            new Product() { Id = 9, Name = "Radeon RX 7800 XT", Price = 65999, Count = 1, IdCompany = 2, IdTypeProduct = 2, CountCores = null, CountStreams = null, Frequency = 2430, IdSocket = null, CountMemory = 16, IdTypeMemory = 2, IdFormFactor = null },
        };

        public static Mock<IRepository<Product>> GetMock()
        {
            var mock = new Mock<IRepository<Product>>();

            mock.Setup(m => m.GetList()).Returns(() => Products);
            mock.Setup(m => m.GetItem(It.IsAny<int>()))
                .Returns((int id) => Products.FirstOrDefault(o => o.Id == id) ?? Products[0]);
            mock.Setup(m => m.Create(It.IsAny<Product>()))
                .Callback(() => { return; });
            mock.Setup(m => m.Update(It.IsAny<Product>()))
               .Callback(() => { return; });
            mock.Setup(m => m.Delete(It.IsAny<int>()))
               .Callback(() => { return; });
            return mock;
        }
    }
}
