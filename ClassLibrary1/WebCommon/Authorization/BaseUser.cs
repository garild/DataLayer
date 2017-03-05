using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.WebCommon.Authorization
{
    public class BaseUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public List<string> Roles { get; set; }
    }

}
