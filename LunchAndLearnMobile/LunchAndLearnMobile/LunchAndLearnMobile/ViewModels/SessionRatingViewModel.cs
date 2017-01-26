using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Storage.Pickers;
using LunchAndLearnMobile.Models;
using LunchAndLearnMobile.Services;
using Xamarin.Forms;

namespace LunchAndLearnMobile.ViewModels
{
  public class SessionRatingViewModel : ViewModelBase, INotifyPropertyChanged
  {
    private Schedule schedule;
    public SessionRatingViewModel(Schedule selectedSchedule, INavigation navigation) : base(navigation)
    {
      schedule = selectedSchedule;
      SubmitRatingCommand = new DelegateCommand(ExecuteSubmitRating, CanExecuteSubmitRating);
    }

    public bool CanExecuteSubmitRating(object parameter)
    {
      return true;
    }

    private Rating _rating;
    private Schedule _schedule;

    public Rating Rating
    {
      get { return _rating; }
      set
      {
        _rating = value;
        NotifyPropertyChanged("Rating");
      }
    }


    public Schedule Schedule
    {
      get { return _schedule; }
      set
      {
        _schedule = value;
        NotifyPropertyChanged("Schedule");
      }
    }

    public ICommand SubmitRatingCommand { get; set; }
    public async void ExecuteSubmitRating(object parameter)
    {
      var newRating = await RatingService.SubmitRating(Rating);
      if (newRating != null && newRating.RatingId > 0)
      {
        await Navigation.PopAsync();
      }     
    }

    public void SetComment(string text)
    {
      if (Rating == null)
      {
        return;
      }

      Rating.Comment = text;
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
          if (Schedule != null)
          {
            Rating = new Rating()
            {
              ClassId = Schedule.ClassId,
              InstructorId = Schedule.InstructorId
            };
          }
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
