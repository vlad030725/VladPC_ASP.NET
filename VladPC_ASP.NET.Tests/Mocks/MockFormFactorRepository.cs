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
    public static class MockFormFactorRepository
    {
        public static List<FormFactor> FormFactors = new List<FormFactor>()
        {
            new FormFactor() { Id = 1, Name = "Standart-ATX" },
            new FormFactor() { Id = 2, Name = "mini-ATX" },
            new FormFactor() { Id = 3, Name = "micro-ATX" },
        };

        public static Mock<IRepository<FormFactor>> GetMock()
        {
            var mock = new Mock<IRepository<FormFactor>>();

            mock.Setup(m => m.GetList()).Returns(() => FormFactors);
            mock.Setup(m => m.GetItem(It.IsAny<int>()))
                .Returns((int id) => FormFactors.FirstOrDefault(o => o.Id == id) ?? FormFactors[0]);
            mock.Setup(m => m.Create(It.IsAny<FormFactor>()))
                .Callback(() => { return; });
            mock.Setup(m => m.Update(It.IsAny<FormFactor>()))
               .Callback(() => { return; });
            mock.Setup(m => m.Delete(It.IsAny<int>()))
               .Callback(() => { return; });
            return mock;
        }
    }
}
