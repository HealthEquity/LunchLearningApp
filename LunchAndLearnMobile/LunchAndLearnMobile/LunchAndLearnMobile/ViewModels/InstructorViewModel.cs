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
  public class InstructorViewModel : ViewModelBase, INotifyPropertyChanged
  {
    public InstructorViewModel(INavigation navigation) : base(navigation)
    {
    }

    private ObservableCollection<Instructor> _instructors;

    public ObservableCollection<Instructor> Instructors
    {
      get { return _instructors; }
      set
      {
        _instructors = value;
        NotifyPropertyChanged("Instructors");
      }
    }
    public void Load()
    {
      if (Instructors != null)
      {
        return;
      }
      IsLoading = true;
      InstructorService.GetInstructors().ContinueWith(i =>
      {
        if (i.Exception == null)
        {
          var instructorResults = i.Result;
          Instructors = new ObservableCollection<Instructor>(instructorResults);
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
