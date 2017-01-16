using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchAndLearnMobile.Models;
using LunchAndLearnMobile.ViewModels;
using Xamarin.Forms;

namespace LunchAndLearnMobile.Pages
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
      var date = ScheduleDatePicker.Date;
      ((ScheduleViewModel)BindingContext).Load(date);
    }

    protected void Schedule_Tapped(object sender, ItemTappedEventArgs e)
    {
      Schedule schedule = e.Item as Schedule;
      Navigation.PushAsync(
        new ScheduleDetail(schedule));
    }

    protected void DatePicker_SelectedDateChanged(object sender, DateChangedEventArgs e)
    {
      DateTime? date = e.NewDate;
      if (date != null)
      {
        ((ScheduleViewModel)BindingContext).Load(date.Value);
      }
    }

  }
}
