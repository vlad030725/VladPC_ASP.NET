using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;

namespace Interfaces.DTO
{
    public class FormFactorDto
    {
        public FormFactorDto(FormFactor ff)
        {
            Id = ff.Id;
            Name = ff.Name;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
