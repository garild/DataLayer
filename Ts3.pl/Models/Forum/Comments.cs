using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Ts3.pl.Models
{
    public class Comments
    {
        public int UserId { get; set; }
        public string BodyContent { get; set; }
        public int Likes { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreateDate { get; set; }
    }
}