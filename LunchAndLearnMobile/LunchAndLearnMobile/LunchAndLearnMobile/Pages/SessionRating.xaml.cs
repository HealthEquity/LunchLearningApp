using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
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

    private void Editor_OnCompleted(object sender, EventArgs e)
    {
      var text = ((Editor)sender).Text;
      ((SessionRatingViewModel) BindingContext).SetComment(text);
    }

    private void ValidatePickerSelection(object sender, EventArgs e)
    {
      ((Picker) sender).TextColor = Color.Default;
      var selectedItem = ((Picker)sender).SelectedIndex;
      if (selectedItem == 0)
      {
        ((Picker)sender).TextColor = Color.Red;
        return;
      }
    }
  }
}
