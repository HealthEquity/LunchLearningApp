namespace LunchAndLearn.Model.DB_Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LunchAndLearn : DbContext
    {
        public LunchAndLearn()
            : base("name=LunchAndLearn")
        {
        }

        public virtual DbSet<Artifact> Artifacts { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseSession> CourseSessions { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<RatingHash> RatingHashes { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }
        public virtual DbSet<TrackSession> TrackSessions { get; set; }
        public virtual DbSet<SessionAttendee> SessionAttendees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artifact>()
                .HasMany(e => e.CourseSessions)
                .WithMany(e => e.Artifacts)
                .Map(m => m.ToTable("SessionCurriculum", "LunchAndLearn").MapLeftKey("ArtifactId").MapRightKey("CourseSessionId"));

            modelBuilder.Entity<Course>()
                .HasMany(e => e.CourseSessions)
                .WithRequired(e => e.Course)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.People)
                .WithMany(e => e.Courses)
                .Map(m => m.ToTable("CourseOwner", "LunchAndLearn").MapLeftKey("CourseId").MapRightKey("InstructorId"));

            modelBuilder.Entity<Person>()
                .HasMany(e => e.TrackSessions)
                .WithMany(e => e.People)
                .Map(m => m.ToTable("SessionAttendee", "LunchAndLearn").MapLeftKey("AttendeeId").MapRightKey("TrackSessionId"));

            modelBuilder.Entity<Person>()
                .HasMany(e => e.TrackSessions)
                .WithMany(e => e.People)
                .Map(m => m.ToTable("SessionInstructor", "LunchAndLearn").MapLeftKey("InstructorId").MapRightKey("TrackSessionId"));

            modelBuilder.Entity<RatingHash>()
                .Property(e => e.Value)
                .IsFixedLength();

            modelBuilder.Entity<Track>()
                .HasMany(e => e.TrackSessions)
                .WithRequired(e => e.Track)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TrackSession>()
                .HasMany(e => e.Ratings)
                .WithRequired(e => e.TrackSession)
                .WillCascadeOnDelete(false);
        }
    }
}
