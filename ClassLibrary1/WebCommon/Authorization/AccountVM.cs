using BLL.DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DLL;
using System.Configuration;

namespace ClassLibrary1.WebCommon.Authorization
{
    public class AccountVM : Datalayers
    {
        private readonly string BaseConnection = ConfigurationManager.ConnectionStrings["BaseConnection"].ConnectionString;
        public BaseUser User { get; set; }

        public BaseUser FindUser(string UserName, string Password)
        {
            User = QueryData<BaseUser>(BaseConnection, "GetUser", new { UserName = UserName, Password = Password });
            return User;
        }

        public List<string> GetUserRoles(int id)
        {
            User.Roles = QueryMultiData<List<string>>(BaseConnection, "GetUserRoles", new { UserId = id }) as List<string>;
            return User.Roles;
        }
    }
}
