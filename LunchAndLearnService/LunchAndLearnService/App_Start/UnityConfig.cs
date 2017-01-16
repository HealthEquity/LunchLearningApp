using Microsoft.Practices.Unity;
using System.Web.Http;
using LunchAndLearn.Data.Interfaces;
using LunchAndLearn.Data.Repositories;
using LunchAndLearn.Management;
using LunchAndLearn.Management.Interfaces;
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
        .RegisterType<IManagerClass<ClassDto>, ClassManager>(new HierarchicalLifetimeManager())
        .RegisterType<IClassRepository, ClassRepository>(new HierarchicalLifetimeManager());

      //Instructor
      container
        .RegisterType<IManagerClass<InstructorDto>, InstructorManager>(new HierarchicalLifetimeManager())
        .RegisterType<IInstructorRepository, InstructorRepository>(new HierarchicalLifetimeManager());

      //Rating
      container
        .RegisterType<IManagerClass<RatingDto>, RatingManager>(new HierarchicalLifetimeManager())
        .RegisterType<IRatingRepository, RatingRepository>(new HierarchicalLifetimeManager());

      //Room
      container
        .RegisterType<IManagerClass<RoomDto>, RoomManager>(new HierarchicalLifetimeManager())
        .RegisterType<IRoomRepository, RoomRepository>(new HierarchicalLifetimeManager());

      //Schedule
      container
        .RegisterType<IManagerClass<ScheduleDto>, ScheduleManager>(new HierarchicalLifetimeManager())
        .RegisterType<IScheduleRepository, ScheduleRepository>(new HierarchicalLifetimeManager());

      //Track
      container
        .RegisterType<IManagerClass<TrackDto>, TrackManager>(new HierarchicalLifetimeManager())
        .RegisterType<ITrackRepository, TrackRepository>(new HierarchicalLifetimeManager());

      GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
    }
  }
}