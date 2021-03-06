﻿using DataLayer.WebCommon.Authorization;
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
    public class ForumController : Controller
    {
        private static readonly ForumRepository _forumRepository = new ForumRepository();

        [Ts3Authorize]
        public ViewResult Index()
        {
            var data = _forumRepository.GetMainTopic();

            var list = new ForumViewModel() { MainTopics = new List<Topics>(data.valueList) };
            return View(list);
        }


        //[Ts3Authorize]
        //public ViewResult Index()
        //{
        //    var data = _forumRepository.GetTopPost();
        //    DeserializeComents(data.valueList);
        //    var list = new ForumViewModel() { Topics = new List<Post>(data.valueList) };
        //    return View(list);
        //}

        private void DeserializeComents(List<Post> valueList)
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

        [Ts3Authorize]
        [HttpPost]
        [Route("Posts/AddNewPost")]
        public ActionResult AddNewPost(int Id, string title, string bodyContent,string returnUrl)
        {
            if (SessionPresister.UserId > 0 && Id > 0)
            {
                
                var dmlResult = _forumRepository.AddNewTopic(Id, SessionPresister.UserId, title, bodyContent);
                if (dmlResult.Succeed)
                    return new RedirectResult(returnUrl);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult FindTopic(string search)
        {
            if (!string.IsNullOrEmpty(search))
            {
                var result = _forumRepository.FindTopics(search);
                if (result.success)
                {
                    var forumVM = new ForumViewModel() { PostList = result.valueList };
                    return View("Index", forumVM);
                }

            }
            return RedirectToAction("Index");
        }

        [Route("blockPost/{Id}")]
        public ActionResult BlockPost(int Id)
        {
            var result = _forumRepository.BlockPost(Id); // TODO dodać obłsugę błędu
            return RedirectToAction("Index");
        }

        [Route("deletePost/{Id}")]
        public ActionResult DeletePost(int Id)
        {
            var result = _forumRepository.DeletePost(Id); // TODO dodać obłsugę błędu
            return RedirectToAction("Index");
        }

        public ActionResult Posts(int? Id)
        {
            var list = new ForumViewModel();
            if (Id > 0)
            {
                var result = _forumRepository.GetPostListForTopic(Id); // TODO dodać obłsugę błędu
                list = new ForumViewModel() { PostList = new List<Post>(result.valueList) };
                return View(list);
            }
            return View(list);
        }
    }
}