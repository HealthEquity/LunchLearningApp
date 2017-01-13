using LunchAndLearn.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchAndLearn.Model.DB_Models;

namespace LunchAndLearn.Data
{
  public class LunchAndLearnContext : DbContext
  {
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<Class> Classes { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<Rating> Ratings { get; set; }
    public DbSet<Track> Tracks { get; set; }
    public DbSet<Room> Rooms { get; set; }

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
