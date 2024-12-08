using Interfaces.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VladPC_ASP.NET.Tests.Mocks
{
    public static class MockUowRepository
    {
        public static Mock<IDbRepos> GetMock()
        {
            var mock = new Mock<IDbRepos>();
            var CompanyRepoMock = MockCompanyRepository.GetMock();
            var CustomRepoMock = MockCustomRepository.GetMock();
            var CustomRowRepoMock = MockCustomRowRepository.GetMock();
            var FormFactorRepoMock = MockFormFactorRepository.GetMock();
            var ProductRepoMock = MockProductRepository.GetMock();
            var SocketRepoMock = MockSocketRepository.GetMock();
            var TypesMemoryRepoMock = MockTypeMemoryRepository.GetMock();
            var TypesProductRepoMock = MockTypeProductRepository.GetMock();
            var UserRepoMock = MockUserRepository.GetMock();

            mock.Setup(m => m.Company).Returns(() => CompanyRepoMock.Object);
            mock.Setup(m => m.Custom).Returns(() => CustomRepoMock.Object);
            mock.Setup(m => m.CustomRow).Returns(() => CustomRowRepoMock.Object);
            mock.Setup(m => m.FormFactor).Returns(() => FormFactorRepoMock.Object);
            mock.Setup(m => m.Product).Returns(() => ProductRepoMock.Object);
            mock.Setup(m => m.Socket).Returns(() => SocketRepoMock.Object);
            mock.Setup(m => m.TypeMemory).Returns(() => TypesMemoryRepoMock.Object);
            mock.Setup(m => m.TypeProduct).Returns(() => TypesProductRepoMock.Object);
            mock.Setup(m => m.User).Returns(() => UserRepoMock.Object);
            mock.Setup(m => m.Save()).Returns(() => { return 1; });
            return mock;
        }
    }
}
