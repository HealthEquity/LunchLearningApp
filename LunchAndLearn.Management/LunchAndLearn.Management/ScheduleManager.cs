using LunchAndLearn.Data;
using LunchAndLearn.Model;
using System.Collections.Generic;
using System.Linq;

namespace LunchAndLearn.Management
{
  public class ScheduleManager : BaseManager, ILunchAndLearnRepository<Schedule, int>
  {
    public ScheduleManager() { }

    public ScheduleManager(LunchAndLearnContext context)
        : base(context)
    {
    }


    // CRUD

    /// <summary>Create a new schedule</summary>
    public virtual void Create(Schedule schedule)
    {
      ValidateModel(schedule);

      AddEntity(schedule);
    }


    /// <summary>Get a schedule</summary>
    public virtual Schedule Get(int id)
    {
      return Context.Schedules.Where(al => al.ScheduleId == id).First();
    }

    public virtual List<Schedule> GetAll()
    {
      return Context.Schedules.ToList();
    }
    /// <summary>Update existing schedule</summary>
    public virtual void Update(Schedule schedule)
    {
      ValidateModel(schedule);
      UpdateEntity(schedule);
    }
    /// <summary>Delete schedule</summary>
    public virtual void Delete(int id)
    {
      DeleteEntity(new Schedule());
    }
  }
}