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
  public class ScheduleViewModel : ViewModelBase, INotifyPropertyChanged
  {
    public ScheduleViewModel(INavigation navigation) : base(navigation)
    {
    }

    private ObservableCollection<Schedule> _schedules;
    public ObservableCollection<Schedule> Schedules
    {
      get { return _schedules; }
      set
      {
        _schedules = value;
        NotifyPropertyChanged("Schedules");
      }
    }
    public void Load(DateTime date)
    {
      IsLoading = true;
      ScheduleService.GetSchedulesByDate(date).ContinueWith(c =>
      {
        if (c.Exception == null)
        {
          var scheduleResults = c.Result;
          Schedules = new ObservableCollection<Schedule>(scheduleResults);
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
