using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface ITypeProductService
    {
        List<TypeProductDto> GetTypesProduct();

        TypeProductDto GetTypeProduct(int id);

        void CreateTypeProduct(TypeProductDto typeProduct);

        void UpdateTypeProduct(TypeProductDto typeProduct);

        void DeleteTypeProduct(int id);
    }
}
