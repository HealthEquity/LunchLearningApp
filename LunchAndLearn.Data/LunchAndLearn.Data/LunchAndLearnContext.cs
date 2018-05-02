using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using LunchAndLearn.Model.DB_Models;

namespace LunchAndLearn.Data
{
  public class LunchAndLearnContext : DbContext
  {
    public DbSet<Artifact> Artifacts { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<CourseSession> CourseSessions { get; set; }
    public DbSet<Person> People { get; set; }
    public DbSet<Rating> Ratings { get; set; }
    public DbSet<RatingHash> RatingHashes { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Track> Tracks { get; set; }
    public DbSet<TrackSession> TrackSessions { get; set; }
    
    public LunchAndLearnContext() : this("LunchAndLearnDatabase")
    {
    }

    public LunchAndLearnContext(bool proxyCreationEnabled = true, bool lazyLoadingEnabled = true)
            : this("LunchAndLearnDatabase", proxyCreationEnabled, lazyLoadingEnabled)
        {
    }

    public LunchAndLearnContext(string connectionString, bool proxyCreationEnabled = true, bool lazyLoadingEnabled = true)
            : base(connectionString)
        {
      // disable database initialization
      Database.SetInitializer<LunchAndLearnContext>(null);

      Configuration.ProxyCreationEnabled = proxyCreationEnabled;
      Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
      Configuration.ValidateOnSaveEnabled = false;
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      // disable pluralized names
      modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

      base.OnModelCreating(modelBuilder);
    }
  }
}
