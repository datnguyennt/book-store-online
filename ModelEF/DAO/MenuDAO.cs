using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
	public class MenuDAO
	{
		NguyenThanhDatDBEntities db = null;
		public MenuDAO()
		{
			db = new NguyenThanhDatDBEntities();
		}

		public List<Menu> ListAll()
		{
			return db.Menu.ToList();
		}
	}
}
