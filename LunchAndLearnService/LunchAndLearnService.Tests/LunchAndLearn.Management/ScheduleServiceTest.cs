using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LunchAndLearn.Data.Interfaces;
using LunchAndLearn.Management;
using LunchAndLearn.Model;
using LunchAndLearn.Model.DB_Models;
using LunchAndLearn.Model.DTOs;
using NUnit.Framework;
using Telerik.JustMock;

namespace LunchAndLearnService.Tests.LunchAndLearn.Management
{
  [TestFixture]
  public class ScheduleServiceTest
  {
    private ScheduleService _scheduleService;
    private List<Schedule> _scheduleList;
    private List<ScheduleDetailDto> _scheduleDetailList;

    [SetUp]
    public void Init()
    {
      _scheduleList = new List<Schedule>()
      {
        new Schedule()
        {
          ScheduleId = 1,
          InstructorId = 1,
          ClassId = 1,
          RoomId = 1,
          TrackId = 1,
          ClassDate = DateTime.Now.Date
        },
        new Schedule()
        {
          ScheduleId = 2,
          InstructorId = 2,
          ClassId = 2,
          RoomId = 2,
          TrackId = 2,
          ClassDate = DateTime.Now.AddDays(1).Date
        },
        new Schedule()
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
      _scheduleList = null;
      _scheduleService = null;
      _scheduleDetailList = null;
    }

    [Test]
    public void GetSchedule_WhereScheduleExists_ReturnsScheduleDto([Values(1, 2, 3)] int idOfScheduleToRetrieve)
    {
      //arrange
      var expected = _scheduleList.FirstOrDefault(x => x.ScheduleId == idOfScheduleToRetrieve);
      var mockScheduleRepository = Mock.Create<IScheduleRepository>();
      Mock.Arrange(() => mockScheduleRepository.Get(Arg.IsAny<int>()))
        .Returns(expected)
        .OccursOnce();

      var scheduleService = new ScheduleService(mockScheduleRepository);

      //act
      var actual = scheduleService.Get(idOfScheduleToRetrieve);

      //assert
      Mock.Assert(mockScheduleRepository);
      Assert.That(actual, Is.Not.Null);
      Assert.That(actual, Is.TypeOf(typeof(ScheduleDto)));
    }

    [Test]
    public void GetSchedule_WhereScheduleDoesntExist_ReturnsNull([Values(8, 9, 10)] int idOfScheduleToRetrieve)
    {
      //arrange
      var expected = _scheduleList.FirstOrDefault(x => x.ScheduleId == idOfScheduleToRetrieve);
      var mockScheduleRepository = Mock.Create<IScheduleRepository>();
      Mock.Arrange(() => mockScheduleRepository.Get(Arg.IsAny<int>()))
        .Returns(expected)
        .OccursOnce();

      var scheduleService = new ScheduleService(mockScheduleRepository);

      //act
      var actual = scheduleService.Get(idOfScheduleToRetrieve);

      //assert
      Mock.Assert(mockScheduleRepository);
      Assert.That(actual, Is.Null);
    }

    [Test]
    public void UpdateSchedule_WhereScheduleExists_ReturnsScheduleDTO([Values(1, 2, 3)] int idOfScheduleToBeUpdated)
    {
      //arrange
      Func<Schedule, bool> whereExpression = x => x.ScheduleId == idOfScheduleToBeUpdated;
      var expected = _scheduleList.FirstOrDefault(whereExpression)?.ConvertToScheduleDto();
      var scheduleToUpdate = _scheduleList.FirstOrDefault(whereExpression);

      var mockScheduleRepository = Mock.Create<IScheduleRepository>();
      Mock.Arrange(() => mockScheduleRepository.Get(Arg.IsAny<int>()))
        .Returns(scheduleToUpdate)
        .OccursOnce();

      _scheduleService = new ScheduleService(mockScheduleRepository);

      //act
      var actual = _scheduleService.Update(expected);

      //assert
      Mock.Assert(mockScheduleRepository);
      Assert.That(actual, Is.Not.Null);
      Assert.That(actual.ScheduleId, Is.EqualTo(expected?.ScheduleId));
    }

    [Test]
    public void UpdateSchedule_WhereScheduleDoesntExist_ReturnsNull([Values(8, 9, 10)] int idOfScheduleToBeUpdated)
    {
      //arrange
      var scheduleDtoToUpdate = new ScheduleDto() {ScheduleId = idOfScheduleToBeUpdated};
      var scheduleToUpdate = _scheduleList.FirstOrDefault(x => x.ScheduleId == idOfScheduleToBeUpdated);

      var mockScheduleRepository = Mock.Create<IScheduleRepository>();
      Mock.Arrange(() => mockScheduleRepository.Get(Arg.IsAny<int>()))
        .Returns(scheduleToUpdate)
        .OccursOnce();

      _scheduleService = new ScheduleService(mockScheduleRepository);
      
      //act
      var actual = _scheduleService.Update(scheduleDtoToUpdate);

      //assert
      Mock.Assert(mockScheduleRepository);
      Assert.That(actual, Is.Null);
    }

    [Test]
    public void CreateSchedule_UnderNormalConditions_AddScheduleToScheduleList()
    {
      //arrange
      var originalCountOfSchedules = _scheduleList.Count;

      var scheduleToCreate = new Schedule()
      {
        InstructorId = 6,
        ClassId = 6,
        RoomId = 6,
        TrackId = 6,
        ScheduleId = 6,
        ClassDate = DateTime.Now
      };

      var mockRepo = Mock.Create<IScheduleRepository>();
      Mock.Arrange(() => mockRepo.Create(Arg.IsAny<Schedule>()))
        .DoInstead(() => _scheduleList.Add(scheduleToCreate))
        .OccursOnce();

      _scheduleService = new ScheduleService(mockRepo);
      
      //act
      _scheduleService.Create(scheduleToCreate.ConvertToScheduleDto());
      var actualCountOfSchedules = _scheduleList.Count;

      //assert
      Mock.Assert(mockRepo);
      Assert.That(actualCountOfSchedules, Is.EqualTo(originalCountOfSchedules + 1));
    }

    [Test]
    public void GetScheduleDetailsByDate_WhereDateIsTodaysDate_ReturnsOnlySchedulesForThatDate()
    {
      //arrange
      var mockRepo = Mock.Create<IScheduleRepository>();
      DateTime searchStartDate = DateTime.Now.Date;
      DateTime searchEndDate = DateTime.Now.Date.AddDays(1);

      Func<Schedule, bool> countFunc = (Schedule x) => x.ClassDate >= searchStartDate && x.ClassDate < searchEndDate;
      Expression<Func<Schedule, bool>> whereExpression = (Schedule x) => x.ClassDate >= searchStartDate && x.ClassDate < searchEndDate;

      var expectedCount = _scheduleList.Count(countFunc);

      Mock.Arrange(() => mockRepo.GetSchedulesWithConditionEagerLoaded(whereExpression))
        .Returns(() => _scheduleList.Where(countFunc).ToList())
        .OccursOnce();

      _scheduleService = new ScheduleService(mockRepo);

      //act
      var actual = _scheduleService.GetDetailedSchedulesForSpecificDate(DateTime.Now.Date);

      //assert
      Mock.Assert(mockRepo);
      Assert.That(actual, Is.Not.Null);
      Assert.That(actual.Count, Is.EqualTo(expectedCount));
    }

    [Test]
    public void GetDetailedSchedule_WhereScheduleExists_ReturnsScheduleDetailDTO([Values(1,2,3)]int scheduleId)
    {
      //arrange
      Expression<Func<Schedule, bool>> whereStatement = x => x.ScheduleId == scheduleId;
      var mockResults = _scheduleList.Where(x => x.ScheduleId == scheduleId).ToList();
      var expected = mockResults.FirstOrDefault();
      var mockScheduleRepo = Mock.Create<IScheduleRepository>();
      Mock.Arrange(() => mockScheduleRepo.GetSchedulesWithConditionEagerLoaded(whereStatement))
        .Returns(mockResults)
        .OccursOnce();

      var scheduleService = new ScheduleService(mockScheduleRepo);

      //act
      var actual = scheduleService.GetDetailedScheduleById(scheduleId);

      //assert
      Mock.Assert(mockScheduleRepo);
      Assert.That(actual, Is.Not.Null);
      Assert.That(actual.ScheduleId, Is.EqualTo(expected.ScheduleId));
    }

    [Test]
    public void GetDetailedSchedule_WhereScheduleDoesntExist_ReturnsNull([Values(8, 9, 10)] int scheduleId)
    {
      //arrange
      List<Schedule> scheduleDbModels = new List<Schedule>();
      var mockResults = _scheduleList.Where(x => x.ScheduleId == scheduleId).ToList();
      var expected = mockResults?.FirstOrDefault()?.ConvertToScheduleDetailDto();

      var mockScheduleRepo = Mock.Create<IScheduleRepository>();
      Mock.Arrange(() => mockScheduleRepo.GetSchedulesWithConditionEagerLoaded(x => x.ScheduleId == scheduleId))
        .Returns(mockResults)
        .OccursOnce();

      var scheduleService = new ScheduleService(mockScheduleRepo);

      //act
      var actual = scheduleService.GetDetailedScheduleById(scheduleId);

      //assert
      Mock.Assert(mockScheduleRepo);
      Assert.That(actual, Is.Null);
      Assert.That(actual, Is.EqualTo(expected));
    }
  }
}
