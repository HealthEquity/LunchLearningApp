using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using LunchAndLearn.Management;
using LunchAndLearn.Model;
using LunchAndLearnService.Controllers;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Telerik.JustMock;

namespace LunchAndLearnService.Tests.Controllers
{
  [TestFixture]
  internal class ScheduleControllerTest
  {
    private ILunchAndLearnManager _lunchAndLearnManager;
    private List<Schedule> _scheduleList;

    [SetUp]
    public void Init()
    {
      _lunchAndLearnManager = Mock.Create<ILunchAndLearnManager>();
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
    }

    [TearDown]
    public void CleanUp()
    {
      _lunchAndLearnManager = null;
      _scheduleList = null;
    }

    [Test]
    public void GetAllSchedules_UnderNormalConditions_ReturnsListOfSchedules()
    {
      //Arrange
      Mock.Arrange(() => _lunchAndLearnManager.ScheduleManager.GetAll()).Returns(_scheduleList).OccursOnce();
      var expected = _scheduleList;

      var scheduleController = new ScheduleController(_lunchAndLearnManager);

      //Act
      var actual = scheduleController.GetAll() as OkNegotiatedContentResult<List<Schedule>>;
      var actualContent = actual.Content;


      //Assert
      Mock.Assert(_lunchAndLearnManager);
      Assert.That(actualContent, Is.EqualTo(expected));
    }

    [Test]
    public void GetScheduleById_WhereScheduleExists_ReturnsSchedule([Values(1,2,3)] int idOfScheduleToGet)
    {
      //Arrange
      Mock.Arrange(() => _lunchAndLearnManager.ScheduleManager.Get(idOfScheduleToGet))
        .Returns(_scheduleList.FirstOrDefault(s => s.ScheduleId == idOfScheduleToGet))
        .OccursOnce();

      var expected = _scheduleList.FirstOrDefault(s => s.ScheduleId == idOfScheduleToGet);

      var scheduleController = new ScheduleController(_lunchAndLearnManager);

      //Act
      var actual = scheduleController.Get(idOfScheduleToGet) as OkNegotiatedContentResult<Schedule>;
      var actualContent = actual.Content;


      //Assert
      Mock.Assert(_lunchAndLearnManager);
      Assert.That(actualContent, Is.EqualTo(expected));
    }

    [Test]
    public void CreateSchedule_UnderNormalConditions_ReturnsOkResponse()
    {
      //Arrange
      var scheduleToBeCreated = new Schedule()
      {
        ScheduleId = 6,
        InstructorId = 6,
        ClassId = 6,
        RoomId = 6,
        TrackId = 6,
        ClassDate = DateTime.Now.AddDays(5).Date
      };

      Mock.Arrange(() => _lunchAndLearnManager.ScheduleManager.Create(scheduleToBeCreated)).OccursOnce();
      var scheduleController = new ScheduleController(_lunchAndLearnManager);

      //Act
      var actual = scheduleController.Post(scheduleToBeCreated) as OkResult;

      //Assert
      Mock.Assert(_lunchAndLearnManager);
      Assert.That(actual, Is.TypeOf<OkResult>());
    }

    [Test]
    public void UpdateSchedule_WhereScheduleExists_ReturnsOkResponse([Values(1,2,3)] int idOfScheduleToBeUpdated)
    {
      //Arrange
      var scheduleToBeUpdated = _scheduleList.FirstOrDefault(s => s.ScheduleId == idOfScheduleToBeUpdated);
      Mock.Arrange(() => _lunchAndLearnManager.ScheduleManager.Update(scheduleToBeUpdated)).OccursOnce();
      var scheduleController = new ScheduleController(_lunchAndLearnManager);
      
      //Act
      var actual = scheduleController.Put(scheduleToBeUpdated) as OkResult;

      //Assert    
      Mock.Assert(_lunchAndLearnManager);
      Assert.That(actual, Is.TypeOf<OkResult>());
    }

    [Test]
    public void DeleteSchedule_WhereScheduleExists_ReturnsOkResponse([Values(1, 2, 3)] int idOfScheduleToBeDeleted)
    {
      //arrange
      Mock.Arrange(() => _lunchAndLearnManager.ScheduleManager.Delete(idOfScheduleToBeDeleted)).OccursOnce();
      var scheduleController = new ScheduleController(_lunchAndLearnManager);

      //act
      var actual = scheduleController.Delete(idOfScheduleToBeDeleted) as OkResult;

      //assert
      Mock.Assert(_lunchAndLearnManager);
      Assert.That(actual, Is.TypeOf<OkResult>());
    }
  }

}
