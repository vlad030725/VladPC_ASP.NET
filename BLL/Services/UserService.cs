using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Services;
using Interfaces.DTO;
using Interfaces.Repository;
using DomainModel;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private IDbRepos db;

        public UserService(IDbRepos db)
        {
            this.db = db;
        }

        public bool RegistationUser(RegisterViewDto model)
        {
            db.User.Create(new User { UserName = model.Login, PasswordHash = model.Password });

            return true;
        }

        public int? IdentificationUser(string login, string password)
        {
            try
            {
                return db.User.GetList().Select(i => new UserDto(i)).Single(i => i.Login == login && i.Password == password).Id;
            }
            catch
            {
                return null;
            }
        }

        public List<UserDto> GetUsers()
        {
            return db.User.GetList().Select(i => new UserDto(i)).ToList();
        }

        public UserDto GetUser(int id)
        {
            return new UserDto(db.User.GetItem(id));
        }

        public void CreateUser(UserDto user)
        {
            db.User.Create(new User(){
                Name = user.Name,
                UserName = user.Login,
                PasswordHash = user.Password
            });
            SaveChanges();
        }

        public void UpdateUser(UserDto user)
        {
            User u = db.User.GetItem(user.Id);
            if (u == null)
            {
                return;
            }
            u.Name = user.Name;
            u.UserName = user.Login;
            u.PasswordHash = user.Password;
            SaveChanges();
        }

        public void DeleteUser(int id)
        {
            db.User.Delete(id);
            SaveChanges();
        }

        public bool SaveChanges()
        {
            if (db.Save() > 0) return true;
            return false;
        }
    }
}
