using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ts3.pl.Models
{
    public class Forum
    {
        public List<Topics> Topics { get; set; }
        public List<Category> Categories { get; set; }
    }
}