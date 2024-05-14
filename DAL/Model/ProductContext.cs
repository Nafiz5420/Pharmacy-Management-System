using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class ProductContext : DbContext
    {
        public DbSet<Seller> SellerServices { get; set; }
        public DbSet<Product> ProductServices { get; set; }
        public DbSet<Selection> SelectionServices { get; set; }
    }
}
