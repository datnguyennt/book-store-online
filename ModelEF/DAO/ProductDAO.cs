using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
	public class ProductDAO
	{
        NguyenThanhDatDBEntities db = null;
        public ProductDAO()
        {
            db = new NguyenThanhDatDBEntities();
        }
        public long Insert(Product product)
        {
            db.Product.Add(product);
            db.SaveChanges();
            return product.ID;
        }
        public List<Product> ListAll()
        {
            return db.Product.ToList();
        }
        public Product ViewDetail(int? id)
        {
            var result = (from p in db.Product
                          join c in db.Category on p.CategoryID equals c.ID
                          where p.ID == id
                          select new
                          {

                          }).FirstOrDefault();
            return db.Product.Find(id);
        }

        public List<Product> ListRelatedProducts(int? id)
        {
            var product = db.Product.Find(id);
            return db.Product.Where(x => x.ID != id && x.CategoryID == product.CategoryID).ToList();
        }
    }
}
