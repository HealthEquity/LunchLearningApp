using Microsoft.Practices.Unity;
using System.Web.Http;
using LunchAndLearn.Data.Interfaces;
using LunchAndLearn.Data.Repositories;
using LunchAndLearn.Management;
using LunchAndLearn.Management.Interfaces;
using LunchAndLearn.Model;
using LunchAndLearn.Model.DB_Models;
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
        .RegisterType<IManagerClass<Class>, ClassManager>(new HierarchicalLifetimeManager())
        .RegisterType<ILunchAndLearnRepository<Class>, LunchAndLearnRepository<Class>>(new HierarchicalLifetimeManager());

      //Instructor
      container
        .RegisterType<IManagerClass<Instructor>, InstructorManager>(new HierarchicalLifetimeManager())
        .RegisterType<ILunchAndLearnRepository<Instructor>, LunchAndLearnRepository<Instructor>>(new HierarchicalLifetimeManager());

      //Rating
      container
        .RegisterType<IManagerClass<Rating>, RatingManager>(new HierarchicalLifetimeManager())
        .RegisterType<ILunchAndLearnRepository<Rating>, LunchAndLearnRepository<Rating>>(new HierarchicalLifetimeManager());

      //Room
      container
        .RegisterType<IManagerClass<Room>, RoomManager>(new HierarchicalLifetimeManager())
        .RegisterType<ILunchAndLearnRepository<Room>, LunchAndLearnRepository<Room>>(new HierarchicalLifetimeManager());

      //Schedule
      container
        .RegisterType<IManagerClass<Schedule>, ScheduleManager>(new HierarchicalLifetimeManager())
        .RegisterType<ILunchAndLearnRepository<Schedule>, LunchAndLearnRepository<Schedule>>(
          new HierarchicalLifetimeManager());

      //Track
      container
        .RegisterType<IManagerClass<Track>, TrackManager>(new HierarchicalLifetimeManager())
        .RegisterType<ILunchAndLearnRepository<Track>, LunchAndLearnRepository<Track>>(new HierarchicalLifetimeManager());

      GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
    }
  }
}