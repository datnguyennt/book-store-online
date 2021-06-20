using MobilePhoneWord.Areas.Admin.Controllers;
using ModelEF.DAO;
using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {

        NguyenThanhDatDBEntities db = null;

        // GET: Admin/Category
        public ActionResult Index()
        {
            var dao = new CategoryDAO();
            return View(dao.ListAll());
        }

        // GET: Admin/Category/Details/5
        public ActionResult Details(int id)
        {
            var dao = new CategoryDAO();
            var category = dao.ViewDetail(id);

            return View(category);
        }

        // GET: Admin/Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Category/Create
        [HttpPost]
        public ActionResult Create(Category model)
        {
            if (ModelState.IsValid)
            {
                db = new NguyenThanhDatDBEntities();
                db.Category.Add(model);
                db.SaveChanges();
                return RedirectToAction("index", "category");
            }
			else
			{
                return View();
			}
        }

        // GET: Admin/Category/Edit/5
        public ActionResult Edit(int? id)
        {
            var dao = new CategoryDAO();
            var category = dao.ViewDetail(id);

            return View(category);
        }

        // POST: Admin/Category/Edit/5
        [HttpPost]
        public ActionResult Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                db = new NguyenThanhDatDBEntities();

                var old = db.Category.Find(model.ID);
                
                old.Name = model.Name;
                old.Metatitle = model.Metatitle;
                old.Description = model.Description;
                
                db.SaveChanges();

                return RedirectToAction("index");
            }
            else
            {
                return View();
            }
        }

        // POST: Admin/Category/Delete/5
        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                var dao = new CategoryDAO();
                dao.Delete(id);
                return this.Json(new { code = 200, msg = "Delete Success" }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception e)
            {
                return this.Json(new { code = 500, msg = "Fail" + e }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
