using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepo<TEntity, TKey, TResult>
    {
        TResult Create(TEntity entity);
        TEntity Read(TKey id);
        IEnumerable<TEntity> ReadAll();
        TResult Update(TEntity entity);
        TResult Delete(TKey id);
    }
}
