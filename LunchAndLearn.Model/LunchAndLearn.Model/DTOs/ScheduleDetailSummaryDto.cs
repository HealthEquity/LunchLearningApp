using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchAndLearn.Model.DTOs
{
  public class ScheduleDetailSummaryDto
  {
    public ICollection<ScheduleDetailDto> ScheduleDetailCollection { get; set; } = new List<ScheduleDetailDto>();
  }
}
