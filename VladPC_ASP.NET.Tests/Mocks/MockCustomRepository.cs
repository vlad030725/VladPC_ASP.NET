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
    public static class MockCustomRepository
    {
        public static List<Custom> Customs = new List<Custom>()
        {
            new Custom() { Id = 1, IdUser = 1, IdStatus = 3, IdPromoCode = null, CreatedDate = DateTime.Now.AddDays(-3), Sum = 0 },
            new Custom() { Id = 2, IdUser = 2, IdStatus = 3, IdPromoCode = null, CreatedDate = DateTime.Now.AddDays(-5), Sum = 0 },
            new Custom() { Id = 3, IdUser = 1, IdStatus = 1, IdPromoCode = null, CreatedDate = null, Sum = 0 },
            new Custom() { Id = 4, IdUser = 2, IdStatus = 3, IdPromoCode = null, CreatedDate = DateTime.Now.AddDays(-7), Sum = 0 },
            new Custom() { Id = 5, IdUser = 2, IdStatus = 3, IdPromoCode = null, CreatedDate = DateTime.Now.AddDays(-9), Sum = 0 },
            new Custom() { Id = 6, IdUser = 2, IdStatus = 1, IdPromoCode = null, CreatedDate = null, Sum = 0 },
        };

        public static Mock<IRepository<Custom>> GetMock()
        {
            var mock = new Mock<IRepository<Custom>>();

            mock.Setup(m => m.GetList()).Returns(() => Customs);
            mock.Setup(m => m.GetItem(It.IsAny<int>()))
                .Returns((int id) => Customs.FirstOrDefault(o => o.Id == id) ?? Customs[0]);
            mock.Setup(m => m.Create(It.IsAny<Custom>()))
                .Callback(() => { return; });
            mock.Setup(m => m.Update(It.IsAny<Custom>()))
               .Callback(() => { return; });
            mock.Setup(m => m.Delete(It.IsAny<int>()))
               .Callback(() => { return; });
            return mock;
        }
    }
}
