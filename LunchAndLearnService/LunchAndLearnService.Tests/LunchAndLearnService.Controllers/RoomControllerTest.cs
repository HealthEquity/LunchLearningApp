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

namespace LunchAndLearnService.Tests.LunchAndLearnService.Controllers
{
  [TestFixture]
  internal class RoomControllerTest
  {
    private IRoomService _roomService;
    private List<RoomDto> _roomsList;

    [SetUp]
    public void Init()
    {
      _roomService = Mock.Create<IRoomService>();

      _roomsList = new List<RoomDto>()
      {
        new RoomDto()
        {
          RoomId = 1,
          Name = "Room name 1",
          Description = "Room description 1",
          MaxOccupancy = 10
        },
        new RoomDto()
        {
          RoomId = 2,
          Name = "Room name 2",
          Description = "Room description 2",
          MaxOccupancy = 15
        },
        new RoomDto()
        {
          RoomId = 1,
          Name = "Room name 3",
          Description = "Room description 3",
          MaxOccupancy = 20
        }
      };
    }

    [TearDown]
    public void CleanUp()
    {
      _roomsList = null;
      _roomService = null;
    }

    //[Test]
    //public void GetAllRooms_UnderNormalConditions_ReturnsCollectionOfRooms()
    //{
    //  //Arrange
    //  Mock.Arrange(() => _roomService.GetAll()).Returns(_roomsList).OccursOnce();
    //  var expected = _roomsList;

    //  var roomController = new RoomController(_roomService);

    //  //Act
    //  var actual = roomController.GetAll() as OkNegotiatedContentResult<List<RoomDto>>;
    //  var actualContent = actual.Content;


    //  //Assert
    //  Mock.Assert(_roomService);
    //  Assert.That(actualContent, Is.EqualTo(expected));
    //}

    //[Test]
    //public void GetRoomById_WhereRoomExists_ReturnsRoom([Values(1,2,3)] int roomIdToRetrieve)
    //{
    //  //Arrange
    //  Mock.Arrange(() => _roomService.Get(roomIdToRetrieve))
    //    .Returns(_roomsList.FirstOrDefault(r => r.RoomId == roomIdToRetrieve)).OccursOnce();

    //  var expected = _roomsList.FirstOrDefault(r => r.RoomId == roomIdToRetrieve);

    //  var roomController = new RoomController(_roomService);

    //  //Act
    //  var actual = roomController.Get(roomIdToRetrieve) as OkNegotiatedContentResult<RoomDto>;
    //  var actualContent = actual.Content;


    //  //Assert
    //  Mock.Assert(_roomService);
    //  Assert.That(actualContent, Is.EqualTo(expected));
    //}

    //[Test]
    //public void CreateRoom_UnderNormalConditions_ReturnsOkResponse()
    //{
    //  //Arrange
    //  var roomToBeCreated = new RoomDto()
    //  {
    //    RoomId = 5,
    //    RoomDescription = "Test description of room",
    //    RoomName = "Purple Popsicle"
    //  };

    //  Mock.Arrange(() => _roomService.Create(roomToBeCreated))
    //    .Returns(roomToBeCreated)
    //    .OccursOnce();

    //  var roomController = new RoomController(_roomService)
    //  {
    //    Request = new HttpRequestMessage()
    //    {
    //      RequestUri = new Uri("http://localhost/api/room")
    //    }
    //  };

    //  //Act
    //  var actual = roomController.Post(roomToBeCreated) as CreatedNegotiatedContentResult<RoomDto>;
    //  var actualContent = actual.Content;

    //  //Assert
    //  Mock.Assert(_roomService);
    //  Assert.That(actual, Is.Not.Null);
    //  Assert.That(actual, Is.TypeOf<CreatedNegotiatedContentResult<RoomDto>>());
    //  Assert.That(actualContent, Is.EqualTo(roomToBeCreated));
    //}

    //[Test]
    //public void UpdateRoom_WhereRoomExists_ReturnsOkResponse([Values(1,2,3)]int roomIdToBeUpdated)
    //{
    //  //Arrange
    //  var roomToBeUpdated = _roomsList.FirstOrDefault(ro => ro.RoomId == roomIdToBeUpdated);

    //  Mock.Arrange(() => _roomService.Update(roomToBeUpdated)).Returns(roomToBeUpdated).OccursOnce();

    //  var roomController = new RoomController(_roomService)
    //  {
    //    Request = new HttpRequestMessage()
    //    {
    //      RequestUri = new Uri("http://localhost/api/room")
    //    }
    //  };

    //  //Act
    //  var actual = roomController.Put(roomToBeUpdated) as OkNegotiatedContentResult<RoomDto>;
    //  var actualContent = actual.Content;

    //  //Assert
    //  Mock.Assert(_roomService);
    //  Assert.That(actual, Is.Not.Null);
    //  Assert.That(actual, Is.TypeOf<OkNegotiatedContentResult<RoomDto>>());
    //  Assert.That(actualContent, Is.EqualTo(roomToBeUpdated));
    //}

    //[Test]
    //public void DeleteRoom_WhereRoomExists_ReturnsOkResponse([Values(1, 2, 3)] int roomIdToBeDeleted)
    //{
    //  //Arrange
    //  Mock.Arrange(() => _roomService.Delete(roomIdToBeDeleted)).OccursOnce();

    //  var roomController = new RoomController(_roomService);
    //  //Act

    //  var actual = roomController.Delete(roomIdToBeDeleted) as OkResult;

    //  //Assert
    //  Mock.Assert(_roomService);
    //  Assert.That(actual, Is.TypeOf<OkResult>());
    //}
  }
}
