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
    public static class MockSocketRepository
    {
        public static List<Socket> Sockets = new List<Socket>()
        {
            new Socket() { Id = 1, Name = "LGA1700" },
            new Socket() { Id = 2, Name = "LGA1200" },
            new Socket() { Id = 3, Name = "AM5" },
            new Socket() { Id = 4, Name = "AM3+" },
            new Socket() { Id = 5, Name = "LGA 1151-v2" },
            new Socket() { Id = 6, Name = "LGA 1151" },
            new Socket() { Id = 7, Name = "LGA 2066" },
            new Socket() { Id = 8, Name = "sWRX8" },
            new Socket() { Id = 9, Name = "AM4" },
        };

        public static Mock<IRepository<Socket>> GetMock()
        {
            var mock = new Mock<IRepository<Socket>>();

            mock.Setup(m => m.GetList()).Returns(() => Sockets);
            mock.Setup(m => m.GetItem(It.IsAny<int>()))
                .Returns((int id) => Sockets.FirstOrDefault(o => o.Id == id) ?? Sockets[0]);
            mock.Setup(m => m.Create(It.IsAny<Socket>()))
                .Callback(() => { return; });
            mock.Setup(m => m.Update(It.IsAny<Socket>()))
               .Callback(() => { return; });
            mock.Setup(m => m.Delete(It.IsAny<int>()))
               .Callback(() => { return; });
            return mock;
        }
    }
}
