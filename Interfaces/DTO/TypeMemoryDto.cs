using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;

namespace Interfaces.DTO
{
    public class TypeMemoryDto
    {

        public TypeMemoryDto(TypeMemory typeMemory)
        {
            Id = typeMemory.Id;
            Name = typeMemory.Name;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
