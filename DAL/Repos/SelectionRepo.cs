using DAL.Interface;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{

    public class SelectionRepo : Repo, IRepo<Selection, int, bool>
    {
        public bool Create(Selection obj)
        {
            db.SelectionServices.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int Id)
        {
            var ex = GET(Id);
            db.SelectionServices.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Selection> GET()
        {
            return db.SelectionServices.ToList();
        }

        public Selection GET(int Id)
        {
            return db.SelectionServices.Find(Id);
        }

        public bool Update(Selection obj)
        {
            var ex = GET(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
