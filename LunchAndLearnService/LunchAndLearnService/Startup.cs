using System;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Unity.WebApi;

[assembly: OwinStartup(typeof(LunchAndLearnService.Startup))]

namespace LunchAndLearnService
{
  public class Startup
  {
    public void Configuration(IAppBuilder app)
    {
      var httpConfiguration = new HttpConfiguration
      {
        DependencyResolver = new UnityDependencyResolver(UnityConfig.GetUnityContainerWithRegisteredComponents())
      };


      ConfigureOAuth(app);

      WebApiConfig.Register(httpConfiguration);
      app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
      app.UseWebApi(httpConfiguration);
    }

    public void ConfigureOAuth(IAppBuilder app)
    {
      var oAuthServerOptions = new OAuthAuthorizationServerOptions()
      {
        AllowInsecureHttp = true,
        TokenEndpointPath = new PathString("/token"),
        AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
        Provider = new SimpleAuthorizationServerProvider()
      };

      // Token Generation
      app.UseOAuthAuthorizationServer(oAuthServerOptions);
      app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

    }
  }
}
