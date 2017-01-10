using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchAndLearn.Management
{
  internal interface ILunchAndLearnRepository<TEntity, TKey>
  {
    TEntity Create(TEntity entity);
    TEntity Get(TKey key);
    void Update(TEntity entity);
    void Delete(TKey key);
  }
}
