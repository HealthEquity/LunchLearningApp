using Microsoft.Practices.Unity;
using LunchAndLearn.Data.Interfaces;
using LunchAndLearn.Data.Repositories;
using LunchAndLearn.Management;
using LunchAndLearn.Management.Interfaces;

namespace LunchAndLearnService
{
  public static class UnityConfig
  {
    public static IUnityContainer GetUnityContainerWithRegisteredComponents()
    {
      var container = new UnityContainer();

      // register all your components with the container here
      // it is NOT necessary to register your controllers

      // e.g. container.RegisterType<ITestService, TestService>();
      //Artifact
      container
        .RegisterType<IArtifactService, ArtifactService>(new HierarchicalLifetimeManager())
        .RegisterType<IArtifactRepository, ArtifactRepository>(new HierarchicalLifetimeManager());
      //Course
      container
        .RegisterType<ICourseService, CourseService>(new HierarchicalLifetimeManager())
        .RegisterType<ICourseRepository, CourseRepository>(new HierarchicalLifetimeManager());

      //CourseSession
      container
        .RegisterType<ICourseSessionService, CourseSessionService>(new HierarchicalLifetimeManager())
        .RegisterType<ICourseSessionRepository, CourseSessionRepository>(new HierarchicalLifetimeManager());
      //Person
      container
        .RegisterType<IPersonService, PersonService>(new HierarchicalLifetimeManager())
        .RegisterType<IPersonRepository, PersonRepository>(new HierarchicalLifetimeManager());
      //Rating
      container
        .RegisterType<IRatingService, RatingService>(new HierarchicalLifetimeManager())
        .RegisterType<IRatingRepository, RatingRepository>(new HierarchicalLifetimeManager());
      //RatingHash
      container
        .RegisterType<IRatingHashService, RatingHashService>(new HierarchicalLifetimeManager())
        .RegisterType<IRatingHashRepository, RatingHashRepository>(new HierarchicalLifetimeManager());
      //Room
      container
        .RegisterType<IRoomService, RoomService>(new HierarchicalLifetimeManager())
        .RegisterType<IRoomRepository, RoomRepository>(new HierarchicalLifetimeManager());
      //Track
      container
        .RegisterType<ITrackService, TrackService>(new HierarchicalLifetimeManager())
        .RegisterType<ITrackRepository, TrackRepository>(new HierarchicalLifetimeManager());
      //TrackSession
      container
        .RegisterType<ITrackSessionService, TrackSessionService>(new HierarchicalLifetimeManager())
        .RegisterType<ITrackSessionRepository, TrackSessionRepository>(new HierarchicalLifetimeManager());
      //SessionAttendee
      container
        .RegisterType<ISessionAttendeeService, SessionAttendeeService>(new HierarchicalLifetimeManager())
        .RegisterType<ISessionAttendeeRepository, SessionAttendeeRepository>(new HierarchicalLifetimeManager());
      return container;
    }
  }
}