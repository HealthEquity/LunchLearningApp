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
    public void Create(Schedule schedule)
    {
      ValidateModel(schedule);

      AddEntity(schedule);
    }


    /// <summary>Get a schedule</summary>
    public Schedule Get(int id)
    {
      return Context.Schedules.Where(al => al.ScheduleId == id).First();
    }

    public List<Schedule> GetAll()
    {
      return Context.Schedules.ToList();
    }
    /// <summary>Update existing schedule</summary>
    public void Update(Schedule schedule)
    {
      ValidateModel(schedule);
      UpdateEntity(schedule);
    }
    /// <summary>Delete schedule</summary>
    public void Delete(int id)
    {
      //DeleteEntity(new Schedule());
    }
    // Getters


  }
}