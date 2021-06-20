using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
	public class CategoryDAO
	{
        NguyenThanhDatDBEntities db = null;
        public CategoryDAO()
        {
            db = new NguyenThanhDatDBEntities();
        }
        public long Insert(Category category)
        {
            db.Category.Add(category);
            db.SaveChanges();
            return category.ID;
        }
        public List<Category> ListAll()
        {
            return db.Category.ToList();
        }
        public Category ViewDetail(int? id)
        {
            return db.Category.Find(id);
        }

        public bool Delete(int? id)
        {
            try
            {
                var cat = db.Category.Find(id);
                db.Category.Remove(cat);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
