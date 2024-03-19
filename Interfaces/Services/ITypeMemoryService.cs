using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface ITypeMemoryService
    {
        List<TypeMemoryDto> GetTypesMemory();

        TypeMemoryDto GetTypeMemory(int id);

        void CreateTypeMemory(TypeMemoryDto typeMemory);

        void UpdateTypeMemory(TypeMemoryDto typeMemory);

        void DeleteTypeMemory(int id);
    }
}
