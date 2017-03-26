using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace DataLayer.WebCommon.Authorization
{
    public class Ts3Principal : IPrincipal
    {
        private BaseUser _user;
        private AccountVM _accountVm = new AccountVM();
        private List<Claim> claims = new List<Claim>();
        public Ts3Principal(BaseUser user)
        {
            this._user = user;
            if (!string.IsNullOrEmpty(_user?.Name))
                Identity = new GenericIdentity(_user.Name);
        }

        public IIdentity Identity
        {
            get; set;
        }

        public bool IsInRole(string role)
        {
            if (_user?.Id > 0)
            {
                var claimsUser = _accountVm.GetUserRoles(_user.Id);
                if (claimsUser.success)
                {
                    _user.Roles = claimsUser.valueList;
                    HttpContext.Current.User = this;
                    return role.Any(p => _user.Roles.Contains(role));
                }
            }
            return false;
        }
    }
}
