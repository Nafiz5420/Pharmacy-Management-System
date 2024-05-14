using DAL.Interface;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{

    public class SellerRepo : Repo, IRepo<Seller, int, bool>
    {
        public bool Create(Seller obj)
        {
            db.SellerServices.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int SellerId)
        {
            var ex = GET(SellerId);
            db.SellerServices.Remove(ex);
            return db.SaveChanges() > 0;
        }
        public List<Seller> GET()
        {
            return db.SellerServices.ToList();
        }

        public Seller GET(int SellerId)
        {
            return db.SellerServices.Find(SellerId);
        }

        public bool Update(Seller obj)
        {
            var ex = GET(obj.SellerId);
            db.Entry(ex).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }


    }
}


