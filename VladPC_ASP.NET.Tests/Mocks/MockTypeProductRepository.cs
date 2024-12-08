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
    public static class MockTypeProductRepository
    {
        public static List<TypeProduct> TypesProduct = new List<TypeProduct>()
        {
            new TypeProduct() { Id = 1, Name = "Процессор" },
            new TypeProduct() { Id = 2, Name = "Видеокарта" }
        };

        public static Mock<IRepository<TypeProduct>> GetMock()
        {
            var mock = new Mock<IRepository<TypeProduct>>();

            mock.Setup(m => m.GetList()).Returns(() => TypesProduct);
            mock.Setup(m => m.GetItem(It.IsAny<int>()))
                .Returns((int id) => TypesProduct.FirstOrDefault(o => o.Id == id) ?? TypesProduct[0]);
            mock.Setup(m => m.Create(It.IsAny<TypeProduct>()))
                .Callback(() => { return; });
            mock.Setup(m => m.Update(It.IsAny<TypeProduct>()))
               .Callback(() => { return; });
            mock.Setup(m => m.Delete(It.IsAny<int>()))
               .Callback(() => { return; });
            return mock;
        }
    }
}
