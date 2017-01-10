using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LunchAndLearnMobile.ViewModels
{
  public class ViewModelBase : INotifyPropertyChanged
  {
    private INavigation nav;

    public ViewModelBase(INavigation navigation)
    {
      nav = navigation;
    }


    private bool _loading;

    public bool IsLoading
    {
      get { return _loading; }
      set
      {
        _loading = value;
        NotifyPropertyChanged("IsLoading");
      }
    }

    protected void NotifyPropertyChanged(string propertyName)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    public event PropertyChangedEventHandler PropertyChanged;

    public INavigation Navigation { get { return nav; } }
  }
}
