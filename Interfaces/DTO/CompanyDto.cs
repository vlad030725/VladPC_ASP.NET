using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;

namespace Interfaces.DTO
{
    public class CompanyDto
    {
        public CompanyDto(Company c)
        {
            Id = c.Id;
            Name = c.Name;
        }

        public CompanyDto() { }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
