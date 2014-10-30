using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace Web.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			if (WebSecurity.IsAuthenticated)
				return RedirectToAction("Index", "Filme");

			return View();
		}

		public ActionResult About()
		{
			return View();
		}

		public ActionResult Contact()
		{
			return View();
		}
	}
}