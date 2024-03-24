using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;

namespace Interfaces.DTO
{
    public class SocketDto
    {
        public SocketDto(Socket s)
        {
            Id = s.Id;
            Name = s.Name;
        }

        public SocketDto() { }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
