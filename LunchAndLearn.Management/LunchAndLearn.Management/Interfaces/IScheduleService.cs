using System;
using System.Collections.Generic;
using LunchAndLearn.Model.DTOs;

namespace LunchAndLearn.Management.Interfaces
{
  public interface IScheduleService : IBaseService<ScheduleDto>
  {
    List<ScheduleDetailDto> GetDetailedSchedulesForSpecificDate(DateTime searchStartDate);
    ScheduleDetailDto GetDetailedScheduleById(int scheduleId);
  }
}