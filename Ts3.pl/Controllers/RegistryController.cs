using DataLayer.WebCommon.Authorization;
using DataLayer.WebCommon.Security;
using System.Web.Mvc;
using System.Web.Security;
using Ts3.pl.Models;
using Ts3.pl.Models.Repository.User.Implementation;
using Ts3.pl.SharedModel;

namespace Ts3.pl.Controllers
{
    public class RegistryController : Controller
    {
        private static UsersRepository _userRepository = new UsersRepository();
     
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registry(Users user,string returnUrl)
        {
           
            if (ModelState.IsValid)
            {
                var data = _userRepository.AddNewUser(user);
                if (data.Succeed)
                {
                    ModelState.Clear();
                    ViewBag.SuccessMsg = "Konto zostało utworzone!";
                    SessionPresister.UserName = user?.Name;
                    SessionPresister.UserId = user.Id;
                    return new RedirectResult(returnUrl);
                }
                else
                    ViewBag.ErrorMsg = "Wystąpił błąd podczas utworzenia konta. Podany login bądź email już istnieje!";
            }
            return View("Index");
        }

        [HttpPost]
        public ActionResult Login(ForumViewModel data, string returnUrl)
        {
            if (!string.IsNullOrEmpty(data.Users?.DisplayName) && !string.IsNullOrEmpty(data.Users?.Password))
            {
                var userAcount = new AccountVM();
                var user = userAcount.FindUser(data.Users.DisplayName);
                var exists = Security.VerifyHashedPassword(user?.Password, data.Users.Password);
                if (exists && !string.IsNullOrEmpty(user?.Name))
                {
                    new Ts3Principal(user);
                    SessionPresister.UserName = user.Name;
                    SessionPresister.UserId = user.Id;
                    return new RedirectResult(returnUrl);
                }
                else
                    ViewBag.ErrorMsg = "Podany login lub hasło jest nieprawidłowe.";
            }
            return View("Index");
        }

        public ActionResult LogOut()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return View("Index");
        }
    }
}