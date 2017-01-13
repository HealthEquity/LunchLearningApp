using System.Linq;
using LunchAndLearn.Model.DB_Models;

namespace LunchAndLearn.Data.Interfaces
{
  public interface IRatingRepository : IBaseRepository<Rating>
  {
    new IQueryable<Rating> GetAll();
  }
}