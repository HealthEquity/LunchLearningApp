namespace LunchAndLearn.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Class",
                c => new
                    {
                        ClassId = c.Int(nullable: false, identity: true),
                        ClassName = c.String(),
                        ClassDescription = c.String(),
                    })
                .PrimaryKey(t => t.ClassId);
            
            CreateTable(
                "dbo.Rating",
                c => new
                    {
                        RatingId = c.Int(nullable: false, identity: true),
                        ClassId = c.Int(nullable: false),
                        ClassRating = c.Int(nullable: false),
                        InstructorId = c.Int(nullable: false),
                        InstructorRating = c.Int(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.RatingId)
                .ForeignKey("dbo.Class", t => t.ClassId, cascadeDelete: true)
                .ForeignKey("dbo.Instructor", t => t.InstructorId, cascadeDelete: true)
                .Index(t => t.ClassId)
                .Index(t => t.InstructorId);
            
            CreateTable(
                "dbo.Instructor",
                c => new
                    {
                        InstructorId = c.Int(nullable: false, identity: true),
                        InstructorName = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.InstructorId);
            
            CreateTable(
                "dbo.Schedule",
                c => new
                    {
                        ScheduleId = c.Int(nullable: false, identity: true),
                        ClassId = c.Int(nullable: false),
                        InstructorId = c.Int(nullable: false),
                        TrackId = c.Int(nullable: false),
                        ClassDate = c.DateTime(nullable: false),
                        RoomId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ScheduleId)
                .ForeignKey("dbo.Class", t => t.ClassId, cascadeDelete: true)
                .ForeignKey("dbo.Instructor", t => t.InstructorId, cascadeDelete: true)
                .ForeignKey("dbo.Room", t => t.RoomId, cascadeDelete: true)
                .ForeignKey("dbo.Track", t => t.TrackId, cascadeDelete: true)
                .Index(t => t.ClassId)
                .Index(t => t.InstructorId)
                .Index(t => t.TrackId)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.Room",
                c => new
                    {
                        RoomId = c.Int(nullable: false, identity: true),
                        RoomName = c.String(),
                        RoomDescription = c.String(),
                    })
                .PrimaryKey(t => t.RoomId);
            
            CreateTable(
                "dbo.Track",
                c => new
                    {
                        TrackId = c.Int(nullable: false, identity: true),
                        TrackName = c.String(),
                        TrackDescription = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TrackId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schedule", "TrackId", "dbo.Track");
            DropForeignKey("dbo.Schedule", "RoomId", "dbo.Room");
            DropForeignKey("dbo.Schedule", "InstructorId", "dbo.Instructor");
            DropForeignKey("dbo.Schedule", "ClassId", "dbo.Class");
            DropForeignKey("dbo.Rating", "InstructorId", "dbo.Instructor");
            DropForeignKey("dbo.Rating", "ClassId", "dbo.Class");
            DropIndex("dbo.Schedule", new[] { "RoomId" });
            DropIndex("dbo.Schedule", new[] { "TrackId" });
            DropIndex("dbo.Schedule", new[] { "InstructorId" });
            DropIndex("dbo.Schedule", new[] { "ClassId" });
            DropIndex("dbo.Rating", new[] { "InstructorId" });
            DropIndex("dbo.Rating", new[] { "ClassId" });
            DropTable("dbo.Track");
            DropTable("dbo.Room");
            DropTable("dbo.Schedule");
            DropTable("dbo.Instructor");
            DropTable("dbo.Rating");
            DropTable("dbo.Class");
        }
    }
}
