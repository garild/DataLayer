using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace DataLayer.WebCommon.Authorization
{
    public class Ts3Authorize : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (string.IsNullOrEmpty(SessionPresister.UserName) && string.IsNullOrEmpty(SessionPresister.Password))
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Registry", action = "Index" }));
            else
            {
                AccountVM _acctontVm = new AccountVM();
                Ts3Principal t3Princ = new Ts3Principal(_acctontVm.FindUser(SessionPresister.UserName, SessionPresister.Password));
                if (!t3Princ.IsInRole(Roles))
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "AccessDenny", action = "Index" }));
            }
        }
    }
}
