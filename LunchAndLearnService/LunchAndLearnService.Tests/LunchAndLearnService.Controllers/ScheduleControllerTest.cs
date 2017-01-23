using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http.Results;
using LunchAndLearn.Management;
using LunchAndLearn.Management.Interfaces;
using LunchAndLearn.Model;
using LunchAndLearn.Model.DB_Models;
using LunchAndLearn.Model.DTOs;
using LunchAndLearnService.Controllers;
using NUnit.Framework;
using Telerik.JustMock;
using Telerik.JustMock.Helpers;

namespace LunchAndLearnService.Tests.LunchAndLearnService.Controllers
{
  [TestFixture]
  internal class ScheduleControllerTest
  {
    private IScheduleService _mockScheduleService;
    private List<ScheduleDto> _scheduleList;
    private List<ScheduleDetailDto> _scheduleDetailList;

    [SetUp]
    public void Init()
    {
      _mockScheduleService = Mock.Create<IScheduleService>();

      _scheduleList = new List<ScheduleDto>()
      {
        new ScheduleDto()
        {
          ScheduleId = 1,
          InstructorId = 1,
          ClassId = 1,
          RoomId = 1,
          TrackId = 1,
          ClassDate = DateTime.Now.Date
        },
        new ScheduleDto()
        {
          ScheduleId = 2,
          InstructorId = 2,
          ClassId = 2,
          RoomId = 2,
          TrackId = 2,
          ClassDate = DateTime.Now.AddDays(1).Date
        },
        new ScheduleDto()
        {
          ScheduleId = 3,
          InstructorId = 3,
          ClassId = 3,
          RoomId = 3,
          TrackId = 3,
          ClassDate = DateTime.Now.AddDays(2).Date
        },
      };

      _scheduleDetailList = new List<ScheduleDetailDto>()
      {
        new ScheduleDetailDto()
        {
          ScheduleId = 1,
          ClassDate = DateTime.Now.Date,
          ClassName = "test class name 1",
          TrackName = "test track name 1",
          InstructorName = "test instructor name 1",
          RoomName = "test room name 1"
        },
        new ScheduleDetailDto()
        {
          ScheduleId = 2,
          ClassDate = DateTime.Now.Date.AddDays(1),
          ClassName = "test class name 2",
          TrackName = "test track name 2",
          InstructorName = "test instructor name 2",
          RoomName = "test room name 2"
        }
      };
    }

    [TearDown]
    public void CleanUp()
    {
      _mockScheduleService = null;
      _scheduleList = null;
      _scheduleDetailList = null;
    }

    [Test]
    public void GetAllSchedules_UnderNormalConditions_ReturnsListOfSchedules()
    {
      //Arrange
      Mock.Arrange(() => _mockScheduleService.GetAll()).Returns(_scheduleList).OccursOnce();
      var expected = _scheduleList;

      var scheduleController = new ScheduleController(_mockScheduleService);

      //Act
      var actual = scheduleController.GetAll() as OkNegotiatedContentResult<List<ScheduleDto>>;
      var actualContent = actual.Content;


      //Assert
      Mock.Assert(_mockScheduleService);
      Assert.That(actualContent, Is.EqualTo(expected));
    }

    [Test]
    public void GetScheduleById_WhereScheduleExists_ReturnsSchedule([Values(1,2,3)] int idOfScheduleToGet)
    {
      //Arrange
      Mock.Arrange(() => _mockScheduleService.Get(idOfScheduleToGet))
        .Returns(_scheduleList.FirstOrDefault(s => s.ScheduleId == idOfScheduleToGet))
        .OccursOnce();

      var expected = _scheduleList.FirstOrDefault(s => s.ScheduleId == idOfScheduleToGet);

      var scheduleController = new ScheduleController(_mockScheduleService);

      //Act
      var actual = scheduleController.Get(idOfScheduleToGet) as OkNegotiatedContentResult<ScheduleDto>;
      var actualContent = actual.Content;


      //Assert
      Mock.Assert(_mockScheduleService);
      Assert.That(actualContent, Is.EqualTo(expected));
    }

    [Test]
    public void GetScheduleById_WhereScheduleDoesntExist_ReturnsNotFound([Values(7, 8, 9)] int idOfScheduleToGet)
    {
      //arrange
      _mockScheduleService = Mock.Create<IScheduleService>();
      Mock.Arrange(() => _mockScheduleService.Get(Arg.IsAny<int>()))
        .DoInstead(() => _scheduleList.FirstOrDefault(x => x.ScheduleId == idOfScheduleToGet))
        .OccursOnce();

      var scheduleController = new ScheduleController(_mockScheduleService);

      //act
      var actual = scheduleController.Get(idOfScheduleToGet) as NotFoundResult;

      //assert
      Mock.Assert(_mockScheduleService);
      Assert.That(actual, Is.Not.Null);
      Assert.That(actual, Is.TypeOf(typeof(NotFoundResult)));
    }

    [Test]
    public void CreateSchedule_UnderNormalConditions_ReturnsOkResponse()
    {
      //Arrange
      var scheduleToBeCreated = new ScheduleDto()
      {
        ScheduleId = 6,
        InstructorId = 6,
        ClassId = 6,
        RoomId = 6,
        TrackId = 6,
        ClassDate = DateTime.Now.AddDays(5).Date
      };

      Mock.Arrange(() => _mockScheduleService.Create(scheduleToBeCreated))
        .Returns(scheduleToBeCreated)
        .OccursOnce();

      var scheduleController = new ScheduleController(_mockScheduleService)
      {
        Request = new HttpRequestMessage()
        {
          RequestUri = new Uri("http://localhost/api/schedule")
        }
      };

      //Act
      var actual = scheduleController.Post(scheduleToBeCreated) as CreatedNegotiatedContentResult<ScheduleDto>;
      var actualContent = actual.Content;

      //Assert
      Mock.Assert(_mockScheduleService);
      Assert.That(actual, Is.Not.Null);
      Assert.That(actual, Is.TypeOf<CreatedNegotiatedContentResult<ScheduleDto>>());
      Assert.That(actualContent, Is.EqualTo(scheduleToBeCreated));
    }

    [Test]
    public void UpdateSchedule_WhereScheduleExists_ReturnsOkResponse([Values(1,2,3)] int idOfScheduleToBeUpdated)
    {
      //Arrange
      var scheduleToBeUpdated = _scheduleList.FirstOrDefault(s => s.ScheduleId == idOfScheduleToBeUpdated);
      Mock.Arrange(() => _mockScheduleService.Update(scheduleToBeUpdated))
        .Returns(scheduleToBeUpdated)
        .OccursOnce();

      var scheduleController = new ScheduleController(_mockScheduleService)
      {
        Request = new HttpRequestMessage()
        {
          RequestUri = new Uri("http://localhost/api/schedule")
        }
      };

      //Act
      var actual = scheduleController.Put(scheduleToBeUpdated) as OkNegotiatedContentResult<ScheduleDto>;
      var actualContent = actual.Content;

      //Assert    
      Mock.Assert(_mockScheduleService);
      Assert.That(actual, Is.Not.Null);
      Assert.That(actual, Is.TypeOf<OkNegotiatedContentResult<ScheduleDto>>());
      Assert.That(actualContent, Is.EqualTo(scheduleToBeUpdated));
    }

    [Test]
    public void UpdateSchedule_WhereScheduleDoesntExist_ReturnsNotFound([Values(7, 8, 9)] int idOfScheduleToUpdate)
    {
      //arrange
      var scheduleToUpdate = new ScheduleDto()
      {
        ScheduleId = 10
      };
      _mockScheduleService = Mock.Create<IScheduleService>();
      Mock.Arrange(() => _mockScheduleService.Update(Arg.IsAny<ScheduleDto>()))
        .DoInstead(() => _scheduleList.FirstOrDefault(x => x.ScheduleId == idOfScheduleToUpdate))
        .OccursOnce();

      var scheduleController = new ScheduleController(_mockScheduleService);

      //act
      var actual = scheduleController.Put(scheduleToUpdate) as NotFoundResult;

      //assert
      Mock.Assert(_mockScheduleService);
      Assert.That(actual, Is.Not.Null);
      Assert.That(actual, Is.TypeOf(typeof(NotFoundResult)));
    }

    [Test]
    public void DeleteSchedule_WhereScheduleExists_ReturnsOkResponse([Values(1, 2, 3)] int idOfScheduleToBeDeleted)
    {
      //arrange
      Mock.Arrange(() => _mockScheduleService.Delete(idOfScheduleToBeDeleted)).OccursOnce();
      var scheduleController = new ScheduleController(_mockScheduleService);

      //act
      var actual = scheduleController.Delete(idOfScheduleToBeDeleted) as OkResult;

      //assert
      Mock.Assert(_mockScheduleService);
      Assert.That(actual, Is.TypeOf<OkResult>());
    }

    [Test]
    public void GetScheduleDetailsByDate_UnderNormalConditions_ReturnsListOfScheduleDetailDtos()
    {
      //arrange
      Mock.Arrange(() => _mockScheduleService.GetDetailedSchedulesForSpecificDate(Arg.IsAny<DateTime>()))
        .Returns(_scheduleDetailList)
        .OccursOnce();

      var scheduleController = new ScheduleController(_mockScheduleService);
      
      //act
      var actual = scheduleController.GetScheduleDetailsForSpecificDate(DateTime.Now.Date) as OkNegotiatedContentResult<List<ScheduleDetailDto>>;
      var actualContent = actual.Content;

      //assert
      Mock.Assert(_mockScheduleService);
      Assert.That(actual, Is.Not.Null);
      Assert.That(actual, Is.TypeOf(typeof(OkNegotiatedContentResult<List<ScheduleDetailDto>>)));
      Assert.That(_scheduleDetailList, Is.EqualTo(actualContent));
    }

    [Test]
    public void GetScheduleDetailsByScheduleId_WhereScheduleExists_ReturnsScheduleDetailDto([Values(1,2)]int id)
    {
      //arrange
      Mock.Arrange(() => _mockScheduleService.GetDetailedScheduleById(id))
        .Returns(() => _scheduleDetailList.FirstOrDefault(x => x.ScheduleId == id))
        .OccursOnce();

      var scheduleController = new ScheduleController(_mockScheduleService);
      var expected = _scheduleDetailList.FirstOrDefault(x => x.ScheduleId == id);
      //act
      var actual = scheduleController.GetScheduleDetailsById(id) as OkNegotiatedContentResult<ScheduleDetailDto>;
      var actualContent = actual.Content;

      //assert
      Mock.Assert(_mockScheduleService);
      Assert.That(actual, Is.Not.Null);
      Assert.That(actual, Is.TypeOf(typeof(OkNegotiatedContentResult<ScheduleDetailDto>)));
      Assert.That(actualContent, Is.EqualTo(expected));
    }

    [Test]
    public void GetScheduleDetailsByScheduleId_WhereScheduleDoesntExist_ReturnsNotFoundResult([Values(8, 9, 10)] int scheduleId)
    {
      //arrange
      _mockScheduleService = Mock.Create<IScheduleService>();
      Mock.Arrange(() => _mockScheduleService.GetDetailedScheduleById(Arg.IsAny<int>()))
        .DoInstead(() => _scheduleDetailList.FirstOrDefault(x => x.ScheduleId == scheduleId))
        .OccursOnce();

      var scheduleController = new ScheduleController(_mockScheduleService);

      //act
      var actual = scheduleController.GetScheduleDetailsById(scheduleId) as NotFoundResult;

      //assert
      Mock.Assert(_mockScheduleService);
      Assert.That(actual, Is.Not.Null);
      Assert.That(actual, Is.TypeOf(typeof(NotFoundResult)));
    }

    [Test]
    public void GetSchedulesByDateForCurrentWeek_ReturnsListOfClassesWithDatesInsideTheCurrentWeek()
    {
      //arrange
      var searchDateDayOfWeek = (int)DateTime.Now.DayOfWeek;
      var beginningSearchDateOfWeek = DateTime.Now.Date.AddDays(-searchDateDayOfWeek);
      var endSearchDateOfWeek = beginningSearchDateOfWeek.AddDays(7);

      var expected =
        _scheduleDetailList.Where(
          x => x.ClassDate >= beginningSearchDateOfWeek && x.ClassDate < endSearchDateOfWeek);


      var todaysDate = DateTime.Now.Date;
      var mockScheduleService = Mock.Create<IScheduleService>();
      Mock.Arrange(() => mockScheduleService.GetDetailedSchedulesForWeek(todaysDate)).Returns(_scheduleDetailList).OccursOnce();

      var scheduleController = new ScheduleController(mockScheduleService);

      //act
      var actual =
        scheduleController.GetDetailedSchedulesForWeek(todaysDate) as OkNegotiatedContentResult<List<ScheduleDetailDto>>;
      var actualContent = actual.Content;

      //assert
      Mock.Assert(mockScheduleService);
      Assert.That(actual, Is.Not.Null);
      Assert.That(actualContent, Is.Not.Null);
      Assert.That(actualContent, Is.EqualTo(expected));
    }
  }

}
