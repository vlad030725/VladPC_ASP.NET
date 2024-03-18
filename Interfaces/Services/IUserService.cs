using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.DTO;

namespace Interfaces.Services
{
    public interface IUserService
    {
        int? IdentificationUser(string login, string password);

        List<UserDto> GetUsers();

        UserDto GetUser(int id);

        void CreateUser(UserDto user);

        void UpdateUser(UserDto user);

        void DeleteUser(int id);
    }
}
