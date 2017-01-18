using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LunchAndLearnMobile.Models;
using LunchAndLearnMobile.ViewModels;
using Xamarin.Forms;

namespace LunchAndLearnMobile.Pages
{
  public partial class ScheduleDetail
  {
    public ScheduleDetail()
    {
      InitializeComponent();
    }

    public ScheduleDetail(Schedule schedule) : this()
    {
      this.BindingContext = new ScheduleDetailViewModel(schedule, Navigation);
    }

    protected override void OnAppearing()
    {
      //base.OnAppearing;
      ((ScheduleDetailViewModel)BindingContext).Load();
    }

    protected void Schedule_Tapped(object sender, ItemTappedEventArgs e)
    {
      //Navigation.PushAsync(
      //    new PlaceBid((AuctionItem)e.Item));
    }
    
    protected void RateClass_Clicked(object sender, EventArgs e)
    {
      Button myButton = (Button) sender;
      var schedule = (Schedule)myButton.CommandParameter;
      Navigation.PushAsync(
        new SessionRating(schedule));
    }
  }
}
