using System;
using System.Diagnostics;
using LunchAndLearn.Data.Interfaces;
using LunchAndLearn.Data.Repositories;
using LunchAndLearn.Model.DB_Models;

namespace LunchAndLearn.Data
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly LunchAndLearnContext _context;

    public UnitOfWork()
    {
      _context = new LunchAndLearnContext();
#if DEBUG
      _context.Database.Log = s => Debug.Write(s);
#endif
    }


    private IRepository<Class> _classRepository;
    private IRepository<Instructor> _instructorRepository;
    private IRepository<Rating> _ratingRepository;
    private IRepository<Room> _roomRepository;
    private IRepository<Schedule> _scheduleRepository;
    private IRepository<Track> _trackRepository;

    public IRepository<Class> ClassRepository => _classRepository ?? (_classRepository = new Repository<Class>(_context));

    public IRepository<Instructor> InstructorRepository => _instructorRepository ?? (_instructorRepository = new Repository<Instructor>(_context));

    public IRepository<Rating> RatingRepository => _ratingRepository ?? (_ratingRepository = new Repository<Rating>(_context));

    public IRepository<Room> RoomRepository => _roomRepository ?? (_roomRepository = new Repository<Room>(_context));

    public IRepository<Schedule> ScheduleRepository => _scheduleRepository ?? (_scheduleRepository = new Repository<Schedule>(_context));

    public IRepository<Track> TrackRepository => _trackRepository ?? (_trackRepository = new Repository<Track>(_context));

    public void Commit()
    {
      _context.SaveChanges();
    }


    #region Dispose
    private bool _disposed = false;

    protected virtual void Dispose(bool disposing)
    {
      if (!this._disposed)
      {
        if (disposing)
        {
          _context.Dispose();
#if DEBUG
          Debug.WriteLine("DbContext has been DISPOSED!!");
#endif
        }
      }
      this._disposed = true;
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }
    #endregion
  }
}
