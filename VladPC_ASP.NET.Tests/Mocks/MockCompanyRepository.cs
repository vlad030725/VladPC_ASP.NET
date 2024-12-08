using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;
using Moq;
using Interfaces.Repository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace VladPC_ASP.NET.Tests.Mocks
{
    public static class MockCompanyRepository
    {
        public static List<Company> Companies = new List<Company>()
        {
            new Company() { Id = 1, Name = "Intel" },
            new Company() { Id = 2, Name = "AMD" },
            new Company() { Id = 3, Name = "NVidia" }
        };

        public static Mock<IRepository<Company>> GetMock()
        {
            var mock = new Mock<IRepository<Company>>();

            mock.Setup(m => m.GetList()).Returns(() => Companies);
            mock.Setup(m => m.GetItem(It.IsAny<int>()))
                .Returns((int id) => Companies.FirstOrDefault(o => o.Id == id) ?? Companies[0]);
            mock.Setup(m => m.Create(It.IsAny<Company>()))
                .Callback(() => { return; });
            mock.Setup(m => m.Update(It.IsAny<Company>()))
               .Callback(() => { return; });
            mock.Setup(m => m.Delete(It.IsAny<int>()))
               .Callback(() => { return; });

            return mock;
        }
    }
}
