using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchAndLearn.Data.Interfaces;
using LunchAndLearn.Model.DB_Models;

namespace LunchAndLearn.Data.Repositories
{
  public class RoomRepository : BaseRepository<Room>, IRoomRepository
  {
    //public new IQueryable<Room> GetAll()
    //{
    //  DbContext.Configuration.LazyLoadingEnabled = false;

    //  return DbContext.Rooms
    //    .Include(x => x.Schedules);
    //}
    public override bool Exists(int roomId)
    {
      return base.DbContext.Rooms.Any(x => x.RoomId == roomId);
    }
  }
}
