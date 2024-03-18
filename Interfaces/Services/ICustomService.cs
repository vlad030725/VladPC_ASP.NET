using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.DTO;

namespace Interfaces.Services
{
    public interface ICustomService
    {
        List<CustomDto> GetAllCustoms();

        CustomDto GetCustomInCart(int IdUser);

        CustomDto GetCustom(int IdCustom);

        List<CustomRowDto> GetCustomRowsOneCustom(int Id);

        bool IsContainInCart(int IdUser, int IdProduct);

        ProductDto GetProduct(int Id);

        List<CompanyDto> GetAllCompanies();

        List<SocketDto> GetAllSockets();

        List<TypeProductDto> GetAllTypesProducts();

        List<ProductDto> GetAllProducts();

        List<StatusDto> GetAllStatuses();

        List<TypeMemoryDto> GetAllTypesMemory();

        List<FormFactorDto> GetAllFormFactors();

        List<CustomDto> GetCustomHistory(int IdUser);

        List<CustomDto> GetAllCustomsExcludeCart();

        void UpdateCustomRow(CustomRowDto row);

        void DeleteCustomRow(int Id);

        void AddCustomRow(ProductDto row, int IdUser);

        void UpdateCustom(CustomDto custom);

        void DeleteCustom(int Id);

        void MakeCustom(int IdUser);

        void CreateCustom(CustomDto custom);

        PromoCodeDto Discount(string Code);

        PromoCodeDto Discount(int? Id);
    }
}
