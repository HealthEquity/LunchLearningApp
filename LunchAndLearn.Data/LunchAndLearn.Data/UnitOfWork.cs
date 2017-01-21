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


    private GenericRepository<Class> _classRepository;
    private GenericRepository<Instructor> _instructorRepository;
    private GenericRepository<Rating> _ratingRepository;
    private GenericRepository<Room> _roomRepository;
    private GenericRepository<Schedule> _scheduleRepository;
    private GenericRepository<Track> _trackRepository;

    public GenericRepository<Class> ClassRepository => _classRepository ?? (_classRepository = new GenericRepository<Class>(_context));

    public GenericRepository<Instructor> InstructorRepository => _instructorRepository ?? (_instructorRepository = new GenericRepository<Instructor>(_context));

    public GenericRepository<Rating> RatingRepository => _ratingRepository ?? (_ratingRepository = new GenericRepository<Rating>(_context));

    public GenericRepository<Room> RoomRepository => _roomRepository ?? (_roomRepository = new GenericRepository<Room>(_context));

    public GenericRepository<Schedule> ScheduleRepository => _scheduleRepository ?? (_scheduleRepository = new GenericRepository<Schedule>(_context));

    public GenericRepository<Track> TrackRepository => _trackRepository ?? (_trackRepository = new GenericRepository<Track>(_context));

    public void Save()
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
