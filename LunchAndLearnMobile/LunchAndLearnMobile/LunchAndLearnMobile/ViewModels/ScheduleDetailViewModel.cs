using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchAndLearnMobile.Models;
using LunchAndLearnMobile.Services;
using Xamarin.Forms;

namespace LunchAndLearnMobile.ViewModels
{
  public class ScheduleDetailViewModel : ViewModelBase, INotifyPropertyChanged
  {
    private Schedule schedule;
    public ScheduleDetailViewModel(Schedule selectedSchedule, INavigation navigation) : base(navigation)
    {
      schedule = selectedSchedule;
    }

    private Schedule _schedule;

    public Schedule Schedule
    {
      get { return _schedule; }
      set
      {
        _schedule = value;
        NotifyPropertyChanged("Schedule");
      }
    }

    public void Load()
    {
      if (Schedule != null)
      {
        return;
      }
      IsLoading = true;
      ScheduleService.GetScheduleDetailsById(schedule.ScheduleId).ContinueWith(c =>
      {
        if (c.Exception == null)
        {
          var scheduleResult = c.Result;
          Schedule = scheduleResult;
        }
        else
        {
          //Alert to exception
        }
        IsLoading = false;
      });
    }
  }
}
