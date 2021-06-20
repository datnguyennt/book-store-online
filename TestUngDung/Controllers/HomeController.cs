using ModelEF.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			var productDao = new ProductDAO();
			ViewBag.Product = productDao.ListAll();
			ViewBag.Category = new CategoryDAO().ListAll();
			return View();
		}

		[ChildActionOnly]
		public ActionResult MainMenu()
		{
			var model = new MenuDAO().ListAll(); ;
			return PartialView(model);
		}

		[ChildActionOnly]
		public ActionResult Header()
		{
			var model = new CategoryDAO().ListAll(); ;
			return PartialView(model);
		}

		[ChildActionOnly]
		public ActionResult Footer()
		{
			var model = new CategoryDAO().ListAll(); ;
			return PartialView(model);
		}
	}
}