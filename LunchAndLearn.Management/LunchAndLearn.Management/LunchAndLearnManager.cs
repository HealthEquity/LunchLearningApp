using LunchAndLearn.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LunchAndLearn.Management
{
  public class LunchAndLearnManager : BaseManager, ILunchAndLearnManager
  {
    Lazy<ClassManager> _classManager;
    Lazy<InstructorManager> _instructorManager;
    Lazy<RatingManager> _ratingManager;
    Lazy<TrackManager> _trackManager;
    Lazy<ScheduleManager> _scheduleManager;
    Lazy<RoomManager> _roomManager;

    public ClassManager ClassManager { get { return _classManager.Value; } }
    public InstructorManager InstructorManager { get { return _instructorManager.Value; } }
    public RatingManager RatingManager { get { return _ratingManager.Value; } }
    public TrackManager TrackManager { get { return _trackManager.Value; } }
    public ScheduleManager ScheduleManager { get { return _scheduleManager.Value; } }
    public RoomManager RoomManager { get { return _roomManager.Value; } }


    public LunchAndLearnManager()
        : this(new LunchAndLearnContext())
    { }

    public LunchAndLearnManager(bool lazyLoading)
        : this(new LunchAndLearnContext(lazyLoading, lazyLoading))
    { }


    public LunchAndLearnManager(LunchAndLearnContext context)
        : base(context)
    {
      _classManager = new Lazy<ClassManager>(() => new ClassManager(context));
      _instructorManager = new Lazy<InstructorManager>(() => new InstructorManager(context));
      _ratingManager = new Lazy<RatingManager>(() => new RatingManager(context));
      _trackManager = new Lazy<TrackManager>(() => new TrackManager(context));
      _scheduleManager = new Lazy<ScheduleManager>(() => new ScheduleManager(context));
      _roomManager = new Lazy<RoomManager>(() => new RoomManager(context));
    }

    public int SaveChanges()
    {
      return Context.SaveChanges();
    }

    public LunchAndLearnManager Resolve<T>(ref IQueryable<T> query, IEnumerable<string> paths) where T : class
    {
      if (paths == null)
        return this;

      foreach (var path in paths)
        query = query.Include(path);

      return this;
    }

    public LunchAndLearnManager Resolve<T, TProp>(ref IQueryable<T> query, Expression<Func<T, TProp>> path) where T : class
    {
      if (path != null)
        query = query.Include(path);

      return this;
    }
  }
}
