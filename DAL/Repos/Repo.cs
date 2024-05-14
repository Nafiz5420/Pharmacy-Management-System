using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;

namespace DAL.Repos
{
    public class Repo
    {
        public ProductContext db;

        internal Repo()
        {
            db = new ProductContext();
        }
    }


}
