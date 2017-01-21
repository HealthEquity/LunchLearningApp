using System;
using LunchAndLearn.Data.Repositories;
using LunchAndLearn.Model.DB_Models;

namespace LunchAndLearn.Data.Interfaces
{
  public interface IUnitOfWork : IDisposable
  {
    GenericRepository<Class> ClassRepository { get; }
    GenericRepository<Instructor> InstructorRepository { get; }
    GenericRepository<Rating> RatingRepository { get; }
    GenericRepository<Room> RoomRepository { get; }
    GenericRepository<Schedule> ScheduleRepository { get; }
    GenericRepository<Track> TrackRepository { get; }
    void Save();
  }
}