using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;

namespace Interfaces.DTO
{
    public class UserDto
    {
        public UserDto(User user)
        {
            Id = user.Id;
            Name = user.Name;
            UserName = user.UserName;
            Password = user.PasswordHash;
        }

        public UserDto() { }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
