using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace Ts3.pl.Models
{

    public class Post
    {
        public Post()
        {

        }
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TopicId { get; set; }
        public string Title { get; set; }
        public string BodyContent { get; set; }
        public bool Blocked { get; set; }
        public bool Deleted { get; set; }
        public int Likes { get; set; }
        public int Preview { get; set; }
        public DateTime CreateDate { get; set; }
        public string XmlComments { get; set; }
        public string ElapsedTime
        {
            get
            {
                var elapsedTime = "";
                var date = DateTime.Now.Subtract(CreateDate).Days;
                var time = DateTime.Now.Subtract(CreateDate).Minutes.ToString();
                if (date > 0)
                    elapsedTime += string.Format("{0}dni", date);
                if (!string.IsNullOrEmpty(time))
                    elapsedTime += string.Format(" {0}min temu", time);
                return elapsedTime;
            }
        }

        public List<Comments> Comments { get; set; }
       
    }
}