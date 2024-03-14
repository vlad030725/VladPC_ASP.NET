using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class UserDto
    {
        public UserDto(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Login = user.Login;
            Password = user.Password;
        }

        public UserDto() { }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }
    }
}
