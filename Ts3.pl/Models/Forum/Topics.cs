using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ts3.pl.Utilities;

namespace Ts3.pl.Models
{
    public class Topics
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string NavigateUrl
        {
            get
            {
                return $"/{nameof(Forum)}/Posts/{Name.FriendlURL(Id)}";;
            }
        }
    }
}