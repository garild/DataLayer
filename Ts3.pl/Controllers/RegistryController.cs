using DataLayer.WebCommon.Authorization;
using DataLayer.WebCommon.Security;
using System.Web.Mvc;
using Ts3.pl.Models;
using Ts3.pl.Models.Repository.User.Implementation;


namespace Ts3.pl.Controllers
{
    [RoutePrefix("")]
    public class RegistryController : Controller
    {
        private static UsersRepository _userRepository = new UsersRepository();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registry(Users user)
        {
            if (ModelState.IsValid)
            {
                var data = _userRepository.AddNewUser(user);
                if (data.Succeed)
                {
                    ModelState.Clear();
                    ViewBag.SuccessMsg = "Konto zostało utworzone!";
                    return RedirectToAction("Index", "Home");
                }
                else
                    ViewBag.ErrorMsg = "Wystąpił błąd podczas utworzenia konta. Podany login bądź email już istnieje!";
            }
            return View("Index");
        }

        [HttpPost]
        public ActionResult Login(Users data)
        {
            if(!string.IsNullOrEmpty(data?.DisplayName) && !string.IsNullOrEmpty(data?.Password))
            {
                var userAcount = new AccountVM();
                var user = userAcount.FindUser(data.DisplayName);
                var exists = Security.VerifyHashedPassword(user?.Password, data.Password);
                if(exists && !string.IsNullOrEmpty(user?.Name))
                {
                    SessionPresister.UserName = user?.Name;
                    return RedirectToAction("Index", "Home");
                }
                else
                    ViewBag.ErrorMsg = "Podany login lub hasło jest nieprawidłowe.";
            }
            return View("Index");
        }
    }
}