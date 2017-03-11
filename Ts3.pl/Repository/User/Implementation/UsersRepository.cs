using DataLayer;
using DataLayer.ResultType.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using Ts3.pl.Models.Repository.User.Interface;
using DataLayer.WebCommon.Security;

namespace Ts3.pl.Models.Repository.User.Implementation
{
    public class UsersRepository : Datalayers, IUserRepository
    {
       

        public DMLResult<Users> AddNewUser(Users user)
        {
            return DMLData<Users>("Ts3pl_User_AddNewUser", new
            {
                DisplayName = user.DisplayName,
                Name = user.Name,
                Vorname = user.Vorname,
                Email = user.Email,
                Password = Security.HashPassword(user.Password)
            });
        }

        public List<Users> GetUserList()
        {
            throw new NotImplementedException();
        }
    }
}
