
using System.Linq;
using LunchAndLearn.Model.DB_Models;

namespace LunchAndLearn.Data.Interfaces
{
  public interface IRoomRepository : IBaseRepository<Room>
  {
    new IQueryable<Room> GetAll();
  }
}