using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DataLayer.ResultType.Interface;

namespace DataLayer.WebCommon.Authorization
{
    public class AccountVM : Datalayers
    {
        private readonly string BaseConnection = ConfigurationManager.ConnectionStrings["BaseConnection"].ConnectionString;

        public BaseUser User { get; set; }

        public BaseUser FindUser(string UserName)
        {
            User = QueryData<BaseUser>("Ts3pl_User_FindUser", new { Login = UserName});
            return User;
        }

        public IDataResult<string> GetUserRoles(int id)
        {
          return FillObject<string>("Ts3_pl_User_GetUserRole", new { UserId = id });
        }
    }
}
