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
    public static class MockCustomRowRepository
    {
        public static List<CustomRow> CustomRows = new List<CustomRow>()
        {
            new CustomRow() { Id = 1, IdCustom = 1, IdProduct = 1, Price = 32899, Count = 1 },
            new CustomRow() { Id = 2, IdCustom = 1, IdProduct = 6, Price = 43499, Count = 1 },
            new CustomRow() { Id = 3, IdCustom = 2, IdProduct = 5, Price = 714999, Count = 1 },
            new CustomRow() { Id = 4, IdCustom = 3, IdProduct = 2, Price = 12399, Count = 10 },
            new CustomRow() { Id = 5, IdCustom = 4, IdProduct = 2, Price = 12399, Count = 1 },
            new CustomRow() { Id = 6, IdCustom = 4, IdProduct = 2, Price = 12399, Count = 1 },
            new CustomRow() { Id = 7, IdCustom = 4, IdProduct = 4, Price = 10099, Count = 1 },
            new CustomRow() { Id = 8, IdCustom = 4, IdProduct = 8, Price = 29999, Count = 1 },
            new CustomRow() { Id = 9, IdCustom = 4, IdProduct = 6, Price = 43499, Count = 2 },
            new CustomRow() { Id = 10, IdCustom = 5, IdProduct = 7, Price = 210999, Count = 1 }
        };

        public static Mock<IRepository<CustomRow>> GetMock()
        {
            var mock = new Mock<IRepository<CustomRow>>();

            mock.Setup(m => m.GetList()).Returns(() => CustomRows);
            mock.Setup(m => m.GetItem(It.IsAny<int>()))
                .Returns((int id) => CustomRows.FirstOrDefault(o => o.Id == id) ?? CustomRows[0]);
            mock.Setup(m => m.Create(It.IsAny<CustomRow>()))
                .Callback(() => { return; });
            mock.Setup(m => m.Update(It.IsAny<CustomRow>()))
               .Callback(() => { return; });
            mock.Setup(m => m.Delete(It.IsAny<int>()))
               .Callback(() => { return; });
            return mock;
        }
    }
}
