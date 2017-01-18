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
  public partial class SessionRating
  {
    public SessionRating()
    {
      InitializeComponent();
    }

    public SessionRating(Schedule schedule) : this()
    {
      this.BindingContext = new SessionRatingViewModel(schedule, Navigation);
    }

    protected override void OnAppearing()
    {
      //base.OnAppearing;
      ((SessionRatingViewModel)BindingContext).Load();
    }

    //protected void SubmitRating_Clicked(object sender, EventArgs e)
    //{
    //  Button myButton = (Button)sender;
    //  var rating = (Rating)myButton.CommandParameter;
    //}
  }
}
