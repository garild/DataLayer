using DataLayer.WebCommon.Authorization;
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
    }
}