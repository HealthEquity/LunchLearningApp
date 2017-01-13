using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;
using LunchAndLearn.Management;
using LunchAndLearn.Management.Interfaces;
using LunchAndLearn.Model;
using LunchAndLearn.Model.DB_Models;
using LunchAndLearnService.Controllers;
using NUnit.Framework;
using Telerik.JustMock;

namespace LunchAndLearnService.Tests.LunchAndLearnService.Controllers
{
  [TestFixture]
  internal class RoomControllerTest
  {
    private IManagerClass<Room> _roomManager;
    private List<Room> _roomsList;

    [SetUp]
    public void Init()
    {
      _roomsList = new List<Room>()
      {
        new Room()
        {
          RoomId = 1,
          RoomDescription = "This is a description of room 1",
          RoomName = "This is the name of room 1"
        },
        new Room()
        {
          RoomId = 2,
          RoomDescription = "This is a description of room 2",
          RoomName = "This is the name of room 2"
        },
        new Room()
        {
          RoomId = 3,
          RoomDescription = "This is a description of room 3",
          RoomName = "This is the name of room 3"
        }
      };

      _roomManager = Mock.Create<IManagerClass<Room>>();
    }

    [TearDown]
    public void CleanUp()
    {
      _roomsList = null;
      _roomManager = null;
    }

    [Test]
    public void GetAllRooms_UnderNormalConditions_ReturnsCollectionOfRooms()
    {
      //Arrange
      Mock.Arrange(() => _roomManager.GetAll()).Returns(_roomsList).OccursOnce();
      var expected = _roomsList;

      var roomController = new RoomController(_roomManager);

      //Act
      var actual = roomController.GetAll() as OkNegotiatedContentResult<List<Room>>;
      var actualContent = actual.Content;


      //Assert
      Mock.Assert(_roomManager);
      Assert.That(actualContent, Is.EqualTo(expected));
    }

    [Test]
    public void GetRoomById_WhereRoomExists_ReturnsRoom([Values(1,2,3)] int roomIdToRetrieve)
    {
      //Arrange
      Mock.Arrange(() => _roomManager.Get(roomIdToRetrieve))
        .Returns(_roomsList.FirstOrDefault(r => r.RoomId == roomIdToRetrieve)).OccursOnce();

      var expected = _roomsList.FirstOrDefault(r => r.RoomId == roomIdToRetrieve);

      var roomController = new RoomController(_roomManager);

      //Act
      var actual = roomController.Get(roomIdToRetrieve) as OkNegotiatedContentResult<Room>;
      var actualContent = actual.Content;


      //Assert
      Mock.Assert(_roomManager);
      Assert.That(actualContent, Is.EqualTo(expected));
    }

    [Test]
    public void CreateRoom_UnderNormalConditions_ReturnsOkResponse()
    {
      //Arrange
      var roomToBeCreated = new Room()
      {
        RoomId = 5,
        RoomDescription = "Test description of room",
        RoomName = "Purple Popsicle"
      };

      Mock.Arrange(() => _roomManager.Create(roomToBeCreated)).OccursOnce();

      var roomController = new RoomController(_roomManager);

      //Act
      var actual = roomController.Post(roomToBeCreated) as OkResult;

      //Assert
      Mock.Assert(_roomManager);
      Assert.That(actual, Is.TypeOf<OkResult>());
    }

    [Test]
    public void UpdateRoom_WhereRoomExists_ReturnsOkResponse([Values(1,2,3)]int roomIdToBeUpdated)
    {
      //Arrange
      var roomToBeUpdated = _roomsList.FirstOrDefault(ro => ro.RoomId == roomIdToBeUpdated);

      Mock.Arrange(() => _roomManager.Update(roomToBeUpdated)).OccursOnce();

      var roomController = new RoomController(_roomManager);

      //Act
      var actual = roomController.Put(roomToBeUpdated) as OkResult;

      //Assert
      Mock.Assert(_roomManager);
      Assert.That(actual, Is.TypeOf<OkResult>());
    }

    [Test]
    public void DeleteRoom_WhereRoomExists_ReturnsOkResponse([Values(1, 2, 3)] int roomIdToBeDeleted)
    {
      //Arrange
      Mock.Arrange(() => _roomManager.Delete(roomIdToBeDeleted)).OccursOnce();

      var roomController = new RoomController(_roomManager);
      //Act

      var actual = roomController.Delete(roomIdToBeDeleted) as OkResult;

      //Assert
      Mock.Assert(_roomManager);
      Assert.That(actual, Is.TypeOf<OkResult>());
    }
  }
}
