using BLL.Services;
using Interfaces.Repository;
using Interfaces.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC_ASP.NET.Tests.Mocks;
using Xunit.Abstractions;

namespace VladPC_ASP.NET.Tests.Services
{
    public class ProductServiceTest
    {
        Mock<IDbRepos> uowMock;
        IProductService service;

        public ProductServiceTest()
        {
            uowMock = MockUowRepository.GetMock();
            service = new ProductService(uowMock.Object);
        }

        [Fact]
        public void GetAllProducts_Success()
        {
            var products = service.GetAllProducts();
            Assert.Equal(9, products.Count);

            foreach (var product in products)
            {
                Assert.NotNull(product.IdTypeProduct);
                if (product.IdTypeProduct == 1)
                {
                    Assert.NotNull(product.CountCores);
                    Assert.NotNull(product.CountStreams);
                    Assert.NotNull(product.IdSocket);
                    Assert.Null(product.CountMemory);
                    Assert.Null(product.IdTypeMemory);
                    Assert.Null(product.IdFormFactor);
                }
                else if (product.IdTypeProduct == 2)
                {
                    Assert.Null(product.CountCores);
                    Assert.Null(product.CountStreams);
                    Assert.Null(product.IdSocket);
                    Assert.NotNull(product.CountMemory);
                    Assert.NotNull(product.IdTypeMemory);
                    Assert.Null(product.IdFormFactor);
                }
            }
        }
    }
}
