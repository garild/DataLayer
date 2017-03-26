using DataLayer.WebCommon.Authorization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;
using Ts3.pl.Models;
using Ts3.pl.Repository.Forum.Implementation;
using Ts3.pl.SharedModel;

namespace Ts3.pl.Controllers
{
    [RoutePrefix("/Forum")]
    public class ForumController : Controller
    {
        private static readonly ForumRepository _forumRepository = new ForumRepository();

        [Ts3Authorize]
        public ViewResult Index()
        {
            var data = _forumRepository.GetTopTopics();
            DeserializeComents(data.valueList);
            var list = new ForumViewModel() { Topics = new List<Topics>(data.valueList) };
            return View(list);
        }

        private void DeserializeComents(List<Topics> valueList)
        {
            valueList?.ForEach(p =>
            {
                var serializer = new XmlSerializer(typeof(List<Comments>));
                using (var reader = new StringReader(p.XmlComments))
                {
                    p.Comments = (List<Comments>)serializer.Deserialize(reader);
                }

            });
        }

       
        [HttpPost]
      
        public ActionResult AddNewTopic(string title, string bodyContent)
        {
            if (SessionPresister.UserId > 0)
            {
                var dmlResult = _forumRepository.AddNewTopic(SessionPresister.UserId, title, bodyContent);
                if (dmlResult.Succeed)
                    return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ViewResult FindTopic(string search)
        {
            if (!string.IsNullOrEmpty(search))
            {
                var result = _forumRepository.FindTopics(search);
                if (result.success)
                {
                    var forumVM = new ForumViewModel() { Topics = result.valueList };
                    return View("Index", forumVM);
                }

            }
            return View("Index");
        }

        [Route("BlockPost/{Id}")]
        public ActionResult BlockPost(int Id)
        {
            var result = _forumRepository.BlockPost(Id); // TODO dodać obłsugę błędu
            return RedirectToAction("Index");
        }

        [Route("DeletePost/{Id}")]
        public ActionResult DeletePost(int Id)
        {
            var result = _forumRepository.DeletePost(Id); // TODO dodać obłsugę błędu
            return RedirectToAction("Index");
        }
    }
}