using DataLayer.ResultType.Repository;
using System.Collections.Generic;

namespace Ts3.pl.Models.Repository.User.Interface
{
    public interface IUserRepository
    {
        DMLResult<Users> AddNewUser(Users user);
        List<Users> GetUserList();
    }
}
