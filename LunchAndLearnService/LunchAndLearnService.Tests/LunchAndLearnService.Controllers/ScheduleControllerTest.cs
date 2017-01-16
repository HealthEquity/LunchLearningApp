using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;
using LunchAndLearn.Management;
using LunchAndLearn.Management.Interfaces;
using LunchAndLearn.Model;
using LunchAndLearn.Model.DB_Models;
using LunchAndLearn.Model.DTOs;
using LunchAndLearnService.Controllers;
using NUnit.Framework;
using Telerik.JustMock;

namespace LunchAndLearnService.Tests.LunchAndLearnService.Controllers
{
  [TestFixture]
  internal class ScheduleControllerTest
  {
    private IScheduleService _scheduleService;
    private List<ScheduleDto> _scheduleList;

    [SetUp]
    public void Init()
    {
      _scheduleService = Mock.Create<IScheduleService>();

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
    }

    [TearDown]
    public void CleanUp()
    {
      _scheduleService = null;
      _scheduleList = null;
    }

    [Test]
    public void GetAllSchedules_UnderNormalConditions_ReturnsListOfSchedules()
    {
      //Arrange
      Mock.Arrange(() => _scheduleService.GetAll()).Returns(_scheduleList).OccursOnce();
      var expected = _scheduleList;

      var scheduleController = new ScheduleController(_scheduleService);

      //Act
      var actual = scheduleController.GetAll() as OkNegotiatedContentResult<List<ScheduleDto>>;
      var actualContent = actual.Content;


      //Assert
      Mock.Assert(_scheduleService);
      Assert.That(actualContent, Is.EqualTo(expected));
    }

    [Test]
    public void GetScheduleById_WhereScheduleExists_ReturnsSchedule([Values(1,2,3)] int idOfScheduleToGet)
    {
      //Arrange
      Mock.Arrange(() => _scheduleService.Get(idOfScheduleToGet))
        .Returns(_scheduleList.FirstOrDefault(s => s.ScheduleId == idOfScheduleToGet))
        .OccursOnce();

      var expected = _scheduleList.FirstOrDefault(s => s.ScheduleId == idOfScheduleToGet);

      var scheduleController = new ScheduleController(_scheduleService);

      //Act
      var actual = scheduleController.Get(idOfScheduleToGet) as OkNegotiatedContentResult<ScheduleDto>;
      var actualContent = actual.Content;


      //Assert
      Mock.Assert(_scheduleService);
      Assert.That(actualContent, Is.EqualTo(expected));
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

      Mock.Arrange(() => _scheduleService.Create(scheduleToBeCreated)).OccursOnce();
      var scheduleController = new ScheduleController(_scheduleService);

      //Act
      var actual = scheduleController.Post(scheduleToBeCreated) as OkResult;

      //Assert
      Mock.Assert(_scheduleService);
      Assert.That(actual, Is.TypeOf<OkResult>());
    }

    [Test]
    public void UpdateSchedule_WhereScheduleExists_ReturnsOkResponse([Values(1,2,3)] int idOfScheduleToBeUpdated)
    {
      //Arrange
      var scheduleToBeUpdated = _scheduleList.FirstOrDefault(s => s.ScheduleId == idOfScheduleToBeUpdated);
      Mock.Arrange(() => _scheduleService.Update(scheduleToBeUpdated)).OccursOnce();
      var scheduleController = new ScheduleController(_scheduleService);
      
      //Act
      var actual = scheduleController.Put(scheduleToBeUpdated) as OkResult;

      //Assert    
      Mock.Assert(_scheduleService);
      Assert.That(actual, Is.TypeOf<OkResult>());
    }

    [Test]
    public void DeleteSchedule_WhereScheduleExists_ReturnsOkResponse([Values(1, 2, 3)] int idOfScheduleToBeDeleted)
    {
      //arrange
      Mock.Arrange(() => _scheduleService.Delete(idOfScheduleToBeDeleted)).OccursOnce();
      var scheduleController = new ScheduleController(_scheduleService);

      //act
      var actual = scheduleController.Delete(idOfScheduleToBeDeleted) as OkResult;

      //assert
      Mock.Assert(_scheduleService);
      Assert.That(actual, Is.TypeOf<OkResult>());
    }
  }

}
