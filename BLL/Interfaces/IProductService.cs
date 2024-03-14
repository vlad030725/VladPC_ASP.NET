using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IProductService
    {
        List<ProductDto> GetAllProducts();

        ProductDto GetProduct(int Id);

        List<ProductDto> GetAllProductsOneCustom(int Id);

        List<CompanyDto> GetAllCompanies();

        List<SocketDto> GetAllSockets();

        List<TypeProductDto> GetAllTypesProducts();

        List<TypeMemoryDto> GetAllTypesMemory();

        List<FormFactorDto> GetAllFormFactors();

        void CreateProduct(ProductDto product);

        void UpdateProduct(ProductDto product);

        void DeleteProduct(int Id);

        TypeProductDto GetTypeProduct(int IdProduct);

        bool IsContainInCustomsOrProcurement(int Id);
    }
}
