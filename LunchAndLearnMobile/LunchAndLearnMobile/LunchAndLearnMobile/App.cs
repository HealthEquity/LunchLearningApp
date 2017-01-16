using LunchAndLearnMobile.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchAndLearnMobile.Pages;
using Xamarin.Forms;

namespace LunchAndLearnMobile
{
  public class App : Xamarin.Forms.Application
  {
    private static ClassService _classService;
    private static ScheduleService _scheduleService;
    public App()
    {
      MainPage = new ContentPage();
    }

    public void LoadMainPage()
    {
      MainPage = new NavigationPage(
        new Schedules());
    }

    public static ClassService GetClassService()
    {
      return _classService ?? (_classService = new ClassService());
    }

    public static ScheduleService GetScheduleService()
    {
      return _scheduleService ?? (_scheduleService = new ScheduleService());
    }
  }
}
