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
using Interfaces.DTO;

namespace VladPC_ASP.NET.Tests.Services
{
    public class CustomServiceTest
    {
        Mock<IDbRepos> uowMock;
        ICustomService service;

        public CustomServiceTest()
        {
            uowMock = MockUowRepository.GetMock();
            service = new CustomService(uowMock.Object);
        }

        [Fact]
        public void GetAllCustoms_Success()
        {
            var customs = service.GetAllCustoms();
            Assert.Equal(6, customs.Count);
        }

        [Fact]
        public void GetCustomInCart_Success()
        {
            int id = service.GetCustomInCart(2).Id;
            Assert.Equal(6, service.GetCustomInCart(2).Id);
        }

        [Fact]
        public void GetCutomRowsOneCustom_Success()
        {
            var customRows = service.GetCustomRowsOneCustom(1);
            Assert.Equal(2, customRows.Count);
        }

        [Fact]
        public void IsContainInCart_Success()
        {
            Assert.True(service.IsContainInCart(1, 2));
        }

        [Fact]
        public void IsContainInCart_Fail()
        {
            Assert.False(service.IsContainInCart(1, 3));
        }

        [Fact]
        public void GetCustomHistory_Success()
        {
            var history = service.GetCustomHistory(2);
            Assert.Equal(3, history.Count);
        }

        [Fact]
        public void GetAllCustomsExcludeCart_Succes()
        {
            var customs = service.GetAllCustomsExcludeCart();
            Assert.Equal(4, customs.Count);
        }

        [Fact]
        public void SearchCustom_Success()
        {
            Assert.Equal(4, service.SearchCustom(5));
        }

        [Fact]
        public void MakeCustom_Success()
        {
            service.MakeCustom(1);
            var customs = service.GetAllCustomsExcludeCart();
            Assert.Equal(5, customs.Count);
            service.UpdateCustom(new CustomDto() { Id = 3, IdUser = 1, IdStatus = 1, IdPromoCode = null, CreatedDate = null, Sum = 0 });
        }
    }
}
