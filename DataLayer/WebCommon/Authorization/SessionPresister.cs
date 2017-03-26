using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DataLayer.WebCommon.Authorization
{
    public static class SessionPresister
    {
        static string SessionUserName = "UserName";
        static string SessionUserId = "UserId";

        public static string UserName
        {
            get
            {
                if (HttpContext.Current == null)
                    return string.Empty;
                var sessionVar = HttpContext.Current.Session[SessionUserName];
                if (sessionVar != null)
                    return sessionVar as string;
                return null;
            }
            set
            {
                HttpContext.Current.Session[SessionUserName] = value;
            }
        }

        public static int UserId
        {
            get
            {
                if (HttpContext.Current == null)
                    return default(int);
                var sessionVar = HttpContext.Current.Session[SessionUserId];
                if (sessionVar != null)
                    return (int)sessionVar;
                return default(int);
            }
            set
            {
                HttpContext.Current.Session[SessionUserId] = value;
            }
        }
    }
}
