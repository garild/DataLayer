using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ts3.pl.Models;

namespace Ts3.pl.SharedModel
{
    public class ForumViewModel
    {
        public ForumViewModel()
        {
            Users = new Users();
            PostList = new List<Post>();
            MainTopics = new List<Topics>();
        }
        public Users Users { get; set; }
        public List<Post> PostList { get; set; }
        public List<Topics> MainTopics { get; set; }
    }
}