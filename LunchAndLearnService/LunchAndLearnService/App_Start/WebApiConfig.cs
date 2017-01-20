using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using LunchAndLearnService.Filters;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;

namespace LunchAndLearnService
{
  public static class WebApiConfig
  {
    public static void Register(HttpConfiguration config)
    {
      //enable cross origin requests for client consumption
      var cors = new EnableCorsAttribute(origins: "*", headers: "*", methods: "*");
      config.EnableCors(cors);

      // Web API configuration and services
      // Configure Web API to use only bearer token authentication.
      config.SuppressDefaultHostAuthentication();
      config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

      //Comment or un-comment to validate models that have data annotations or not. This will return an error response outlining the problems.
      config.Filters.Add(new ValidateModelAttribute());

      //Comment or un-comment to ensure all models are not null before being handed to the controller
      config.Filters.Add(new CheckModelForNullAttribute());

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
