using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms.Platform.Android;

namespace LunchAndLearnMobile.Droid
{
  //[Activity(Label = "LunchAndLearnMobile", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
  //public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
  //{
  //  protected override void OnCreate(Bundle bundle)
  //  {
  //    TabLayoutResource = Resource.Layout.Tabbar;
  //    ToolbarResource = Resource.Layout.Toolbar;

  //    base.OnCreate(bundle);

  //    global::Xamarin.Forms.Forms.Init(this, bundle);
  //    LoadApplication(new App());
  //  }
  //}

  [Activity(Label = "LunchAndLearnMobile.Droid", MainLauncher = true, Icon = "@drawable/icon")]
  public class MainActivity : FormsApplicationActivity
  {
    protected override void OnCreate(Bundle bundle)
    {
      base.OnCreate(bundle);

      //Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init ();
      Xamarin.Forms.Forms.Init(this, bundle);

      var xApp = new App();
      xApp.LoadMainPage();
      LoadApplication(xApp);
    }
  }
}

