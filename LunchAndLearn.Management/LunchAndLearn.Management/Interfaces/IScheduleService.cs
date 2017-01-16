using System;
using System.Collections.Generic;
using LunchAndLearn.Model.DTOs;

namespace LunchAndLearn.Management.Interfaces
{
  public interface IScheduleService : IBaseService<ScheduleDto>
  {
    List<ScheduleDetailDto> GetScheduleDetailsForSpecificDate(DateTime searchStartDate);
    ScheduleDetailDto GetScheduleDetailsById(int scheduleId);
  }
}