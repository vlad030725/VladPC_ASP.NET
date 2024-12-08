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
    public static class MockTypeMemoryRepository
    {
        public static List<TypeMemory> TypesMemory = new List<TypeMemory>()
        {
            new TypeMemory() { Id = 1, Name = "GDDR6" },
            new TypeMemory() { Id = 2, Name = "GDDR5" },
            new TypeMemory() { Id = 3, Name = "GDDR6X" },
            new TypeMemory() { Id = 4, Name = "DDR5" },
            new TypeMemory() { Id = 5, Name = "DDR4" },
            new TypeMemory() { Id = 6, Name = "DDR3" },
        };

        public static Mock<IRepository<TypeMemory>> GetMock()
        {
            var mock = new Mock<IRepository<TypeMemory>>();

            mock.Setup(m => m.GetList()).Returns(() => TypesMemory);
            mock.Setup(m => m.GetItem(It.IsAny<int>()))
                .Returns((int id) => TypesMemory.FirstOrDefault(o => o.Id == id) ?? TypesMemory[0]);
            mock.Setup(m => m.Create(It.IsAny<TypeMemory>()))
                .Callback(() => { return; });
            mock.Setup(m => m.Update(It.IsAny<TypeMemory>()))
               .Callback(() => { return; });
            mock.Setup(m => m.Delete(It.IsAny<int>()))
               .Callback(() => { return; });
            return mock;
        }
    }
}
