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
  public class ClassesViewModel : ViewModelBase, INotifyPropertyChanged
  {
    public ClassesViewModel(INavigation navigation) : base(navigation)
    {
    }

    private ObservableCollection<DbClass> _classes;

    public ObservableCollection<DbClass> Classes
    {
      get { return _classes; }
      set
      {
        _classes = value;
        NotifyPropertyChanged("Classes");
      }
    }
    public void Load()
    {
      if (Classes != null)
      {
        return;
      }
      IsLoading = true;
      ClassService.GetClasses().ContinueWith(c =>
      {
        if (c.Exception == null)
        {
          var classResults = c.Result;
          Classes = new ObservableCollection<DbClass>(classResults);
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
