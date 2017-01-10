using LunchAndLearnMobile.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LunchAndLearnMobile
{
  public class App : Xamarin.Forms.Application
  {
    private static ClassService _classService;

    public App()
    {
      MainPage = new ContentPage();
    }

    public void LoadMainPage()
    {
      MainPage = new NavigationPage(
        new Classes());
    }

    public static ClassService GetClassService()
    {
      if (_classService == null)
      {
        _classService = new ClassService();
      }
      return _classService;
    }
  }
}
