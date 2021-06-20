using MobilePhoneWord.Areas.Admin.Controllers;
using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestUngDung.Common;
using TestUngDung.Extensions;

namespace TestUngDung.Areas.Admin.Controllers
{
	public class EmployeeController : BaseController
	{
		NguyenThanhDatDBEntities db = null;
		// GET: Admin/Employee
		public ActionResult Index(string search, int? page)
		{
			db = new NguyenThanhDatDBEntities();
			var emp = db.UserAccount.Where(x => x.UserType == 0);
			if (search != null)
			{
				emp = emp.Where(x => x.UserName.Contains(search));
				return View(emp.ToList().ToPagedList(page ?? 1, 5));
			}
			else
			{
				return View(emp.ToList().ToPagedList(page ?? 1, 5));
			}
		}

		// GET: Admin/Employee/Create
		public ActionResult Create()
		{
			return View();
		}

		public bool IsNameExist(string name)
		{
			db = new NguyenThanhDatDBEntities();
			var result = db.UserAccount.Any(c => c.UserName == name);
			return result;
		}

		[HttpPost]
		public ActionResult Create(UserAccount model)
		{
			if (IsNameExist(model.UserName))
			{
				this.AddNotification("Tài khoản đã tồn tại", NotificationType.ERROR);
			}
			else
			{
				if (ModelState.IsValid)
				{
					db = new NguyenThanhDatDBEntities();
					string pass_MD5 = Encryptor.MD5Hash(model.Password); //Mã hóa mật khẩu về MD5 trước khi truyền vào

					model.Password = pass_MD5;

					db.UserAccount.Add(model);
					db.SaveChanges();
					this.AddNotification("Thêm tài khoản thành công", NotificationType.SUCCESS);
					return RedirectToAction("Index", "employee");
				}
				else
				{
					//this.AddNotification("Lỗi khi thêm tài khoản", NotificationType.ERROR);
					return View();
				}
			}
			return View();
		}
		public ActionResult Edit(int? id)
		{
			db = new NguyenThanhDatDBEntities();
			try
			{
				var emp = db.UserAccount.SingleOrDefault(x => x.ID == id && x.UserType == 0);
				if (emp == null)
				{
					return HttpNotFound();
				}

				return View(emp);
			}
			catch (Exception)
			{
				return View();
			}
		}

		[HttpPost]
		public ActionResult Edit(UserAccount model)
		{
			db = new NguyenThanhDatDBEntities();
			try
			{
				string pass_MD5 = Encryptor.MD5Hash(model.Password); //Mã hóa mật khẩu về MD5 trước khi truyền vào
				var emp = db.UserAccount.SingleOrDefault(x => x.ID == model.ID && x.UserType == 0);
				emp.Password = pass_MD5;
				emp.Status = model.Status;
				emp.UserType = model.UserType;
				db.SaveChanges();
				this.AddNotification("Cập nhật tài khoản thành công", NotificationType.SUCCESS);
				return RedirectToAction("Index", "employee");
			}
			catch (Exception)
			{
				return View();
			}
		}

		[HttpPost]
		public JsonResult Delete(int? id)
		{
			try
			{
				db = new NguyenThanhDatDBEntities();
				var emp = db.UserAccount.SingleOrDefault(x => x.ID == id && x.UserType == 0);
				db.UserAccount.Remove(emp);
				db.SaveChanges();
				this.AddNotification("Xóa thành công", NotificationType.SUCCESS);
				return this.Json(new { code = 200, msg = "Delete Success" }, JsonRequestBehavior.AllowGet);

			}
			catch (Exception e)
			{
				return this.Json(new { code = 500, msg = "Fail" + e }, JsonRequestBehavior.AllowGet);
			}
		}
	}
}