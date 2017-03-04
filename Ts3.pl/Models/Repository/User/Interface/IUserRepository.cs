using System.Collections.Generic;
using static BLL.DLL.Datalayers;

namespace Ts3.pl.Models.Repository.User.Interface
{
    public interface IUserRepository
    {
        DMLResult<Users> AddNewUser(Users user);
        List<Users> GetUserList();
    }
}
