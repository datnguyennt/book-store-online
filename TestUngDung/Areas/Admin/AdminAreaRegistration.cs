using System.Web.Mvc;

namespace TestUngDung.Areas.Admin
{
	public class AdminAreaRegistration : AreaRegistration
	{
		public override string AreaName
		{
			get
			{
				return "Admin";
			}
		}

		public override void RegisterArea(AreaRegistrationContext context)
		{

			context.MapRoute(
			   name: "Admin area",
			   url: "trangquantri",
			   defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
		   );

			context.MapRoute(
			   name: "Book List",
			   url: "sach",
			   defaults: new { controller = "Product", action = "Index", id = UrlParameter.Optional }
		   );

			context.MapRoute(
			   name: "Book Add",
			   url: "sach/them",
			   defaults: new { controller = "Product", action = "Create", id = UrlParameter.Optional }
		   );

			context.MapRoute(
			   name: "Book Edit",
			   url: "sach/sua/{id}",
			   defaults: new { controller = "Product", action = "Edit", id = UrlParameter.Optional }
		   );

			context.MapRoute(
			   name: "Employee",
			   url: "taikhoan",
			   defaults: new { controller = "Employee", action = "Index", id = UrlParameter.Optional }
		   );

			context.MapRoute(
			   name: "Employee details",
			   url: "taikhoan/chitiet/{id}",
			   defaults: new { controller = "Employee", action = "Details", id = UrlParameter.Optional }
		   );

			context.MapRoute(
			   name: "Employee add",
			   url: "taikhoan/them",
			   defaults: new { controller = "Employee", action = "Create", id = UrlParameter.Optional }
		   );

			context.MapRoute(
			   name: "Employee List",
			   url: "taikhoan/sua/{id}",
			   defaults: new { controller = "Employee", action = "Edit", id = UrlParameter.Optional }
		   );

			context.MapRoute(
			   name: "Product Details",
			   url: "sach/chitiet/{id}",
			   defaults: new { controller = "Product", action = "Details", id = UrlParameter.Optional }
		   );

			context.MapRoute(
			   name: "Category Add",
			   url: "theloaisach/them",
			   defaults: new { controller = "Category", action = "Create", id = UrlParameter.Optional }
		   );

			context.MapRoute(
			   name: "Category",
			   url: "theloaisach",
			   defaults: new { controller = "Category", action = "Index", id = UrlParameter.Optional }
		   );

			context.MapRoute(
			   name: "Category Edit",
			   url: "theloaisach/sua/{id}",
			   defaults: new { controller = "Category", action = "Edit", id = UrlParameter.Optional }
		   );
			context.MapRoute(
			   name: "Category Detail",
			   url: "theloaisach/chitiet/{id}",
			   defaults: new { controller = "Category", action = "Details", id = UrlParameter.Optional }
		   );

			context.MapRoute(
			   name: "Login",
			   url: "dangnhap",
			   defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
		   );

			context.MapRoute(
				"Admin_default",
				"Admin/{controller}/{action}/{id}",
				new { action = "Index", id = UrlParameter.Optional }
			);
		}
	}
}