using BLL.DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ts3.pl.Models;
using Ts3.pl.Models.Repository.User.Implementation;
using static Ts3.pl.Models.Repository.User.Implementation.UsersRepository;

namespace Ts3.pl.Controllers
{
    public class LogInController : Controller
    {
        private UsersRepository _userRepository;
        public LogInController()
        {
            _userRepository = new UsersRepository();
        }
        // GET: LogIn
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ViewResult SingIn(Users user)
        {
            if (ModelState.IsValid)
            {
                var result = _userRepository.AddNewUser(user);
                if (result.Succeed)
                    return View("");
            }
            return View();
        }
    }
}