using LunchAndLearn.Data;
using LunchAndLearn.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchAndLearn.Management
{
  public class TrackManager : BaseManager, ILunchAndLearnRepository<Track, int>
  {
    public TrackManager() { }

    public TrackManager(LunchAndLearnContext context)
        : base(context)
    {
    }


    // CRUD

    /// <summary>Create a new track</summary>
    public virtual Track Create(Track track)
    {
      ValidateModel(track);

      AddEntity(track);

      return track;
    }


    /// <summary>Get a track</summary>
    public virtual Track Get(int id)
    {
      return Context.Tracks.Where(al => al.TrackId == id).First();
    }

    public virtual List<Track> GetAll()
    {
      return Context.Tracks.ToList();
    }
    /// <summary>Update existing Track</summary>
    public virtual void Update(Track track)
    {
      ValidateModel(track);
      UpdateEntity(track);
    }

    /// <summary>Delete Track</summary>
    public virtual void Delete(int id)
    {
      DeleteEntity(new Track());
    }
  }
}
