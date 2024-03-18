using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.DTO;

namespace Interfaces.Services
{
    public interface IProcurementService
    {
        bool IsContainInFillingProcurement(int IdProduct);

        ProcurementDto GetProcurementInFilling();

        List<ProcurementDto> GetAllProcurements();

        List<ProcurementRowDto> GetProcurementRows(int IdProcurement);

        List<CompanyDto> GetAllCompanies();

        List<SocketDto> GetAllSockets();

        List<TypeProductDto> GetAllTypesProducts();

        List<ProductDto> GetAllProducts();

        List<TypeMemoryDto> GetAllTypesMemory();

        List<FormFactorDto> GetAllFormFactors();

        void AddProcurement();

        void UpdateProcurement(ProcurementDto procurement);

        void AddProcurementRow(ProductDto pr, int count, int price);

        void DeleteProcurementRow(int Id);

        void UpdateProcurementRow(ProcurementRowDto pr);

        List<ProcurementDto> GetProcurementHistory();
    }
}
