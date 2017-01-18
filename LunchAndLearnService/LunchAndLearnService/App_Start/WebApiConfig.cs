using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using LunchAndLearnService.ActionFilters;
using Microsoft.Owin.Security.OAuth;

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

      //comment or un-comment for logging
      config.Filters.Add(new LoggingFilterAttribute());

      //comment or un-comment for global exception handling
      //config.Filters.Add(new GlobalExceptionAttribute());

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
