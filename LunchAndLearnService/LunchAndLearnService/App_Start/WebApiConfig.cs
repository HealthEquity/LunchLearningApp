using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using LunchAndLearnService.Filters;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;

namespace LunchAndLearnService
{
  public static class WebApiConfig
  {
    public static void Register(HttpConfiguration config)
    {
      // Web API configuration and services
      // Configure Web API to use only bearer token authentication.
      config.SuppressDefaultHostAuthentication();
      config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

      //Comment or un-comment to validate models that have data annotations or not. This will return an error response outlining the problems.
      config.Filters.Add(new ValidateModelAttribute());

      // Web API routes
      config.MapHttpAttributeRoutes();

      config.Routes.MapHttpRoute(
          name: "DefaultApi",
          routeTemplate: "api/{controller}/{id}",
          defaults: new { id = RouteParameter.Optional }
      );
    }
  }
}
