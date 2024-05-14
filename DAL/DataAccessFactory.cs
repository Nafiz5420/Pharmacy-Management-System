using DAL.Interface;
using DAL.Model;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class DataAccessFactory
    {
        public static IRepo<Seller, int, bool> SellerData()
        {
            return new SellerRepo();
        }
        public static IRepo<Product, int, bool> ProductData()
        {
            return new ProductRepo();
        }
        public static IRepo<Selection, int, bool> SelectionData()
        {
            return new SelectionRepo();
        }
    }
}
