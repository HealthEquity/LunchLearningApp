using System.Collections.Generic;
using System.Linq;
using LunchAndLearn.Data;
using LunchAndLearn.Data.Interfaces;
using LunchAndLearn.Data.Repositories;
using LunchAndLearn.Management;
using LunchAndLearn.Model;
using LunchAndLearn.Model.DB_Models;
using LunchAndLearn.Model.DTOs;
using NUnit.Framework;
using Telerik.JustMock;
using Telerik.JustMock.Helpers;

namespace LunchAndLearnService.Tests.LunchAndLearn.Management
{
  [TestFixture]
  internal class CourseServiceTest
  {
    private List<Course> _dbCourseList;
    private CourseService _courseService;


    [SetUp]
    public void Init()
    {
      _dbCourseList = new List<Course>()
      {
        new Course()
        {
          CourseId = 1,
          CourseName = "test Class 1",
          CourseDescription = "test Class description 1"
        },
        new Course()
        {
          CourseId = 2,
          CourseName = "test Class 2",
          CourseDescription = "test Class description 2"
        },
        new Course()
        {
          CourseId = 3,
          CourseName = "test Class 3",
          CourseDescription = "test Class description 3"
        },
      };
    }

    [TearDown]
    public void CleanUp()
    {
      _courseService = null;
      _dbCourseList = null;
    }

    [Test]
    public void CreateCourse_UnderNormalConditions_AddsCoursetoCourseList()
    {
      //Arrange
      var originalCountOfCourses = _dbCourseList.Count;
      var courseToBeCreated = new Course()
      {
        CourseDescription = "test Class description",
        CourseName = "test Class name"
      };

      var mockRepo = Mock.Create<ICourseRepository>();
      Mock.Arrange(() => mockRepo.Create(Arg.IsAny<Course>()))
        .DoInstead(() => _dbCourseList.Add(courseToBeCreated))
        .OccursOnce();

      _courseService = new CourseService(mockRepo);

      //Act
      _courseService.Create(courseToBeCreated.ConvertToCourseDto());
      var actualCount = _dbCourseList.Count;


      //Assert
      Mock.Assert(mockRepo);
      Assert.That(actualCount, Is.EqualTo(originalCountOfCourses + 1));
    }

    [Test]
    public void GetCourseById_WhereIdExists_ReturnsNonNullCourseDto([Values(1,2,3)]int id)
    {
      //arrange
      var mockCourseRepo = Mock.Create<ICourseRepository>();
      Mock.Arrange(() => mockCourseRepo.Get(Arg.IsAny<int>()))
        .Returns(_dbCourseList.FirstOrDefault(x => x.CourseId == id))
        .OccursOnce();

      _courseService = new CourseService(mockCourseRepo);

      //act
      var actual = _courseService.Get(id);

      //assert
      Mock.Assert(mockCourseRepo);
      Assert.IsNotNull(actual);
    }

    [Test]
    public void GetAll_UnderNormalConditions_ReturnsListOfCourseDtos()
    {
      //arrange
      var mockCourseRepo = Mock.Create<ICourseRepository>();
      Mock.Arrange(() => mockCourseRepo.GetAll()).Returns(_dbCourseList).OccursOnce();

      _courseService = new CourseService(mockCourseRepo);
      //act
      var actual = _courseService.GetAll();

      //assert
      Mock.Assert(mockCourseRepo);
      Assert.IsNotNull(actual);
      Assert.That(actual.Count, Is.EqualTo(_dbCourseList.Count));
    }

    [Test]
    public void UpdateClass_WhereCourseExists_DoesntThrowException([Values(1,2,3)]int id)
    {
      //arrange
      const string update = "UPDATED";
      var courseToBeUpdated = _dbCourseList.FirstOrDefault(x => x.CourseId == id);
      var mockCourseRepo = Mock.Create<ICourseRepository>();
      Mock.Arrange(() => mockCourseRepo.Update(Arg.IsAny<Course>()))
        .DoInstead(() =>
        {
          var updatedClass = _dbCourseList.FirstOrDefault(x => x.CourseId == id);
          if (updatedClass != null)
            updatedClass.CourseName = update;
        })
        .OccursOnce();

      _courseService = new CourseService(mockCourseRepo);
      //act
      _courseService.Update(new CourseDto());

      //assert
      Mock.Assert(mockCourseRepo);
      Assert.IsNotNull(courseToBeUpdated);
      Assert.That(courseToBeUpdated.CourseName, Is.EqualTo(update));
    }

    [Test]
    public void DeleteCourse_WhereCourseExists_DoesntThrowException([Values(1,2,3)]int id)
    {
      //arrange
      var courseToBeDeleted = _dbCourseList.FirstOrDefault(x => x.CourseId == id);
      var originalCountOfCourses = _dbCourseList.Count;
      var mockCourseRepo = Mock.Create<ICourseRepository>();
      Mock.Arrange(() => mockCourseRepo.Delete(id)).DoInstead(() => _dbCourseList.RemoveAt(id - 1)).OccursOnce();

      _courseService = new CourseService(mockCourseRepo);

      //act
      _courseService.Delete(id);
      var actualCountOfCourses = _dbCourseList.Count;
      var deletedCourse = _dbCourseList.FirstOrDefault(x => x.CourseId == id);

      //assert
      Mock.Assert(mockCourseRepo);
      Assert.That(courseToBeDeleted, Is.Not.Null);
      Assert.That(actualCountOfCourses, Is.LessThan(originalCountOfCourses));
      Assert.That(deletedCourse, Is.Null);
    }
  }
}
