using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.WebCommon.Authorization
{
    public class Ts3Principal : IPrincipal
    {
        public string _userName { get; set; }
        public string _password { get; set; }
        private BaseUser _user;
        private AccountVM _accountVm = new AccountVM();

        public Ts3Principal(BaseUser user)
        {
            this._user  = user;
            Identity = new GenericIdentity(_user.Name);
        }
        public IIdentity Identity
        {
            get; set;
        }

        public bool IsInRole(string role)
        {
            var data = _accountVm.FindUser(_userName, _password);
            if (data.Id > 0)
            {
                data.Roles = _accountVm.GetUserRoles(data.Id);
                return role.Any(p => data.Roles.Contains(role.ToLower()));
            }
            return false;
        }
    }
}
