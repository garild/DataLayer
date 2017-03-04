using BLL.DLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using Ts3.pl.Models.Repository.User.Interface;

namespace Ts3.pl.Models.Repository.User.Implementation
{
    public class UsersRepository : Datalayers, IUserRepository
    {
        private readonly string BaseConnection = ConfigurationManager.ConnectionStrings["BaseConnection"].ConnectionString;
        public DMLResult<Users> AddNewUser(Users user)
        {
            return DMLData<Users>(BaseConnection, "AddNewUser", new
            {
                DisplayName = user.DisplayName,
                Name = user.Name,
                Vorname = user.Vorname,
                Email = user.Email,
                Password = user.Password,
            });
        }

        public List<Users> GetUserList()
        {
            throw new NotImplementedException();
        }
    }
}
