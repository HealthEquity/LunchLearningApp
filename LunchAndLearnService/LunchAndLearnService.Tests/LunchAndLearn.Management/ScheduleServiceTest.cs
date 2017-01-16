using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    private List<ScheduleDto> _scheduleList;

    [SetUp]
    public void Init()
    {
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
      _scheduleList = null;
      _scheduleService = null;
    }

    [Test]
    public void CreateSchedule_UnderNormalConditions_AddScheduleToScheduleList()
    {
      //arrange
      var originalCountOfSchedules = _scheduleList.Count;

      var scheduleToCreate = new ScheduleDto()
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
      _scheduleService.Create(scheduleToCreate);
      var actualCountOfSchedules = _scheduleList.Count;

      //assert
      Mock.Assert(mockRepo);
      Assert.That(actualCountOfSchedules, Is.EqualTo(originalCountOfSchedules + 1));
    }
  }
}
