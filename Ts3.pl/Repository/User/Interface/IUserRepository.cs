using DataLayer.ResultType.Implementation;
using DataLayer.ResultType.Interface;
using DataLayer.ResultType.Repository;
using DataLayer.ResultType.Type;
using System.Collections.Generic;

namespace Ts3.pl.Models.Repository.User.Interface
{
    public interface IUserRepository
    {
        IDmlResult<DMLResultType> AddNewUser(Users user);
        List<Users> GetUserList();
    }
}
