CREATE SCHEMA LunchAndLearn
GO

GO


CREATE TABLE LunchAndLearn.Course
(
	CourseId int IDENTITY (1, 1) NOT NULL,
	ClassName nvarchar(100) NOT NULL,
	ClassDescription nvarchar(400),
	CONSTRAINT Course_PK PRIMARY KEY(CourseId)
)
GO


CREATE TABLE LunchAndLearn.Track
(
	TrackId int IDENTITY (1, 1) NOT NULL,
	Name nvarchar(100) NOT NULL,
	SeasonNr int NOT NULL,
	Description nvarchar(400),
	CONSTRAINT Track_PK PRIMARY KEY(TrackId),
	CONSTRAINT Track_UC UNIQUE(SeasonNr, Name)
)
GO


CREATE TABLE LunchAndLearn.TrackSession
(
	TrackSessionId int IDENTITY (1, 1) NOT NULL,
	SessionDate date NOT NULL,
	TrackId int NOT NULL,
	RoomId int,
	CourseSessionId int,
	IsReady bit,
	Note nvarchar(max),
	CONSTRAINT TrackSession_PK PRIMARY KEY(TrackSessionId),
	CONSTRAINT TrackSession_UC1 UNIQUE(TrackId, SessionDate)
)
GO


CREATE VIEW LunchAndLearn.TrackSession_UC2 (RoomId, SessionDate)
WITH SCHEMABINDING
AS
	SELECT RoomId, SessionDate
	FROM 
		LunchAndLearn.TrackSession
	WHERE RoomId IS NOT NULL
GO


CREATE UNIQUE CLUSTERED INDEX TrackSession_UC2Index ON LunchAndLearn.TrackSession_UC2(RoomId, SessionDate)
GO


CREATE TABLE LunchAndLearn.SessionInstructor
(
	InstructorId int NOT NULL,
	TrackSessionId int NOT NULL,
	CONSTRAINT SessionInstructor_PK PRIMARY KEY(InstructorId, TrackSessionId)
)
GO


CREATE TABLE LunchAndLearn.Room
(
	RoomId int IDENTITY (1, 1) NOT NULL,
	Name nvarchar(100) NOT NULL,
	Description nvarchar(400),
	MaxOccupancy tinyint,
	CONSTRAINT Room_PK PRIMARY KEY(RoomId)
)
GO


CREATE TABLE LunchAndLearn.Rating
(
	RatingId int IDENTITY (1, 1) NOT NULL,
	TrackSessionId int NOT NULL,
	Comment nvarchar(max),
	InstructorScoreNr int,
	SessionScoreNr int,
	CONSTRAINT Rating_PK PRIMARY KEY(RatingId)
)
GO


CREATE TABLE LunchAndLearn.SessionAttendee
(
	AttendeeId int NOT NULL,
	TrackSessionId int NOT NULL,
	CONSTRAINT SessionAttendee_PK PRIMARY KEY(TrackSessionId, AttendeeId)
)
GO


CREATE TABLE LunchAndLearn.Person
(
	PersonId int IDENTITY (1, 1) NOT NULL,
	CONSTRAINT Person_PK PRIMARY KEY(PersonId)
)
GO


CREATE TABLE LunchAndLearn.RatingHash
(
	"Value" nchar(300) NOT NULL,
	CONSTRAINT RatingHash_PK PRIMARY KEY("Value")
)
GO


CREATE TABLE LunchAndLearn.Artifact
(
	ArtifactId int IDENTITY (1, 1) NOT NULL,
	FilePath nvarchar(500),
	CONSTRAINT Artifact_PK PRIMARY KEY(ArtifactId)
)
GO


CREATE TABLE LunchAndLearn.SessionCurriculum
(
	ArtifactId int NOT NULL,
	CourseSessionId int NOT NULL,
	CONSTRAINT SessionCurriculum_PK PRIMARY KEY(ArtifactId, CourseSessionId)
)
GO


CREATE TABLE LunchAndLearn.CourseOwner
(
	CourseId int NOT NULL,
	InstructorId int NOT NULL,
	CONSTRAINT CourseOwner_PK PRIMARY KEY(CourseId, InstructorId)
)
GO


CREATE TABLE LunchAndLearn.CourseSession
(
	CourseSessionId int IDENTITY (1, 1) NOT NULL,
	CourseId int NOT NULL,
	CONSTRAINT CourseSession_PK PRIMARY KEY(CourseSessionId)
)
GO


ALTER TABLE LunchAndLearn.TrackSession ADD CONSTRAINT TrackSession_FK1 FOREIGN KEY (TrackId) REFERENCES LunchAndLearn.Track (TrackId) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


ALTER TABLE LunchAndLearn.TrackSession ADD CONSTRAINT TrackSession_FK2 FOREIGN KEY (CourseSessionId) REFERENCES LunchAndLearn.CourseSession (CourseSessionId) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


ALTER TABLE LunchAndLearn.TrackSession ADD CONSTRAINT TrackSession_FK3 FOREIGN KEY (RoomId) REFERENCES LunchAndLearn.Room (RoomId) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


ALTER TABLE LunchAndLearn.SessionInstructor ADD CONSTRAINT SessionInstructor_FK1 FOREIGN KEY (InstructorId) REFERENCES LunchAndLearn.Person (PersonId) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


ALTER TABLE LunchAndLearn.SessionInstructor ADD CONSTRAINT SessionInstructor_FK2 FOREIGN KEY (TrackSessionId) REFERENCES LunchAndLearn.TrackSession (TrackSessionId) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


ALTER TABLE LunchAndLearn.Rating ADD CONSTRAINT Rating_FK FOREIGN KEY (TrackSessionId) REFERENCES LunchAndLearn.TrackSession (TrackSessionId) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


ALTER TABLE LunchAndLearn.SessionAttendee ADD CONSTRAINT SessionAttendee_FK1 FOREIGN KEY (AttendeeId) REFERENCES LunchAndLearn.Person (PersonId) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


ALTER TABLE LunchAndLearn.SessionAttendee ADD CONSTRAINT SessionAttendee_FK2 FOREIGN KEY (TrackSessionId) REFERENCES LunchAndLearn.TrackSession (TrackSessionId) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


ALTER TABLE LunchAndLearn.SessionCurriculum ADD CONSTRAINT SessionCurriculum_FK1 FOREIGN KEY (ArtifactId) REFERENCES LunchAndLearn.Artifact (ArtifactId) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


ALTER TABLE LunchAndLearn.SessionCurriculum ADD CONSTRAINT SessionCurriculum_FK2 FOREIGN KEY (CourseSessionId) REFERENCES LunchAndLearn.CourseSession (CourseSessionId) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


ALTER TABLE LunchAndLearn.CourseOwner ADD CONSTRAINT CourseOwner_FK1 FOREIGN KEY (CourseId) REFERENCES LunchAndLearn.Course (CourseId) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


ALTER TABLE LunchAndLearn.CourseOwner ADD CONSTRAINT CourseOwner_FK2 FOREIGN KEY (InstructorId) REFERENCES LunchAndLearn.Person (PersonId) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


ALTER TABLE LunchAndLearn.CourseSession ADD CONSTRAINT CourseSession_FK FOREIGN KEY (CourseId) REFERENCES LunchAndLearn.Course (CourseId) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


GO