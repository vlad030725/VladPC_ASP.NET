using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.DTO
{
    public class SocketDto
    {
        public SocketDto(Socket s)
        {
            Id = s.Id;
            Name = s.Name;
        }
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
