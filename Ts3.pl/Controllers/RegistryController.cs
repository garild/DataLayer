using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ts3.pl.Models;
using Ts3.pl.Models.Repository.User.Implementation;
using BLL.DLL;
using ClassLibrary1.WebCommon.Authorization;

namespace Ts3.pl.Controllers
{
    public class RegistryController : Controller
    {
        private static UsersRepository _userRepository = new UsersRepository();

        public ActionResult Index()
        {
            return View();
        }

        [Ts3Authorize]
        [HttpPost]
        public ActionResult Registry(Users user)
        {
            if (ModelState.IsValid)
            {
                var data = _userRepository.AddNewUser(user);
                if (data.Succeed)
                {
                    ModelState.Clear();
                    return View("Index");
                }
                   
            }
            return View();
        }
    }
}