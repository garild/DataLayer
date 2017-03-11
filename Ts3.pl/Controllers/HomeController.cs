using DataLayer.WebCommon.Authorization;
using System.Web.Mvc;

namespace Ts3.pl.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [Ts3Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}