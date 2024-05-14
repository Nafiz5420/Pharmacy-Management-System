using DAL.Interface;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class ProductRepo : Repo, IRepo<Product, int, bool>
    {
        public bool Create(Product obj)
        {
            db.ProductServices.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int ProductId)
        {
            var ex = GET(ProductId);
            db.ProductServices.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Product> GET()
        {
            return db.ProductServices.ToList();
        }

        public Product GET(int ProductId)
        {
            return db.ProductServices.Find(ProductId);
        }

        public bool Update(Product obj)
        {
            var ex = GET(obj.ProductId);
            db.Entry(ex).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
