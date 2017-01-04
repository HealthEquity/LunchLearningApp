using LunchAndLearn.Data;
using LunchAndLearn.Model;
using System.Collections.Generic;
using System.Linq;

namespace LunchAndLearn.Management
{
  public class RoomManager : BaseManager, ILunchAndLearnRepository<Room, int>
  {
    public RoomManager() { }

    public RoomManager(LunchAndLearnContext context)
        : base(context)
    {
    }


    // CRUD

    /// <summary>Create a new room</summary>
    public virtual void Create(Room room)
    {
      ValidateModel(room);

      AddEntity(room);
    }


    /// <summary>Get a room</summary>
    public virtual Room Get(int id)
    {
      return Context.Rooms.Where(al => al.RoomId == id).First();
    }

    public virtual List<Room> GetAll()
    {
      return Context.Rooms.ToList();
    }
    /// <summary>Update existing room</summary>
    public virtual void Update(Room room)
    {
      ValidateModel(room);
      UpdateEntity(room);
    }

    /// <summary>Delete room</summary>
    public virtual void Delete(int id)
    {
      DeleteEntity(new Room());
    }
  }
}