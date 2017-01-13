using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchAndLearnMobile.ViewModels;
using Xamarin.Forms;

namespace LunchAndLearnMobile
{
  public partial class Schedules
  {
    public Schedules()
    {
      InitializeComponent();
      this.BindingContext = new ScheduleViewModel(this.Navigation);
    }

    protected override void OnAppearing()
    {
      //base.OnAppearing;
      ((ScheduleViewModel)BindingContext).Load();
    }

    //protected void Class_Tapped(object sender, ItemTappedEventArgs e)
    //{
    //  DbClass dbClass =
    //  e.Item as DbClass;
    //  Navigation.PuchAsync(new Classes(dbClass));
    //}
  }
}
