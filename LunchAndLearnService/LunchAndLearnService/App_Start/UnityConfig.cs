using Microsoft.Practices.Unity;
using System.Web.Http;
using LunchAndLearn.Data;
using LunchAndLearn.Data.Interfaces;
using LunchAndLearn.Data.Repositories;
using LunchAndLearn.Management;
using LunchAndLearn.Management.Interfaces;
using LunchAndLearn.Management.Interfaces.Reporting;
using LunchAndLearn.Management.Reporting;
using LunchAndLearn.Model;
using LunchAndLearn.Model.DB_Models;
using LunchAndLearn.Model.DTOs;
using Unity.WebApi;

namespace LunchAndLearnService
{
  public static class UnityConfig
  {
    public static void RegisterComponents()
    {
      var container = new UnityContainer();

      // register all your components with the container here
      // it is NOT necessary to register your controllers

      // e.g. container.RegisterType<ITestService, TestService>();

      //Class
      container
        .RegisterType<IClassService, ClassService>(new HierarchicalLifetimeManager());

      //Instructor
      container
        .RegisterType<IInstructorService, InstructorService>(new HierarchicalLifetimeManager());

      //Rating
      container
        .RegisterType<IRatingService, RatingService>(new HierarchicalLifetimeManager());

      //Room
      container
        .RegisterType<IRoomService, RoomService>(new HierarchicalLifetimeManager());

      //Schedule
      container
        .RegisterType<IScheduleService, ScheduleService>(new HierarchicalLifetimeManager());

      //Track
      container
        .RegisterType<ITrackService, TrackService>(new HierarchicalLifetimeManager());

      //Reporting
      container
        .RegisterType<IReportingService, ReportingService>(new HierarchicalLifetimeManager());

      //UnitOfWork
      container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());

      GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
    }
  }
}