using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IFormFactorService
    {
        List<FormFactorDto> GetFormFactors();

        FormFactorDto GetFormFactor(int id);

        void CreateFormFactor(FormFactorDto formFactor);

        void UpdateFormFactor(FormFactorDto formFactor);

        void DeleteFormFactor(int id);
    }
}
