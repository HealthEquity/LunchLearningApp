using System;
using LunchAndLearn.Data.Repositories;
using LunchAndLearn.Model.DB_Models;

namespace LunchAndLearn.Data.Interfaces
{
  public interface IUnitOfWork : IDisposable
  {
    IRepository<Class> ClassRepository { get; }
    IRepository<Instructor> InstructorRepository { get; }
    IRepository<Rating> RatingRepository { get; }
    IRepository<Room> RoomRepository { get; }
    IRepository<Schedule> ScheduleRepository { get; }
    IRepository<Track> TrackRepository { get; }
    void Commit();
  }
}