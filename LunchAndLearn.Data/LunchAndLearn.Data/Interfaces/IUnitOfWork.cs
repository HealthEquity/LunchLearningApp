using System;
using LunchAndLearn.Data.Repositories;
using LunchAndLearn.Model.DB_Models;

namespace LunchAndLearn.Data.Interfaces
{
  public interface IUnitOfWork : IDisposable
  {
    IGenericRepository<Class> ClassRepository { get; }
    IGenericRepository<Instructor> InstructorRepository { get; }
    IGenericRepository<Rating> RatingRepository { get; }
    IGenericRepository<Room> RoomRepository { get; }
    IGenericRepository<Schedule> ScheduleRepository { get; }
    IGenericRepository<Track> TrackRepository { get; }
    void Commit();
  }
}