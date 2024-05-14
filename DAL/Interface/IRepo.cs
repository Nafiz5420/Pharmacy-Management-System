using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IRepo<Type, Id, RET>
    {
        RET Create(Type obj);

        List<Type> GET();

        Type GET(Id id);

        RET Update(Type obj);

        bool Delete(Id id);

    }
}

