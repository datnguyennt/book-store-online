using ModelEF.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detail(int? id)
        {
            var product = new ProductDAO().ViewDetail(id);
            ViewBag.Category = new CategoryDAO().ViewDetail(product.CategoryID);
            ViewBag.RelatedProducts = new ProductDAO().ListRelatedProducts(id);
            return View(product);
        }

        [ChildActionOnly]
        public PartialViewResult ProductCategory()
        {
            var model = new CategoryDAO().ListAll();
            return PartialView(model);
        }

    }
}