using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchAndLearn.Data.Interfaces;
using LunchAndLearn.Management;
using LunchAndLearn.Model;
using NUnit.Framework;
using Telerik.JustMock;

namespace LunchAndLearnService.Tests.LunchAndLearn.Management
{
  [TestFixture]
  public class RoomManagerTest
  {
    private RoomManager _roomManager;
    private List<Room> _roomList;

    [SetUp]
    public void Init()
    {
      _roomList = new List<Room>()
      {
        new Room()
        {
          RoomId = 1,
          RoomDescription = "room description 1",
          RoomName = "room name 1"
        },
        new Room()
        {
          RoomId = 2,
          RoomDescription = "room description 2",
          RoomName = "room name 2"
        },
        new Room()
        {
          RoomId = 3,
          RoomDescription = "room description 3",
          RoomName = "room name 3"
        }
      };
    }

    [TearDown]
    public void CleanUp()
    {
      _roomList = null;
      _roomManager = null;
    }

    [Test]
    public void CreateRoom_UnderNormalConditions_AddsRoomToRoomList()
    {
      //arrange
      var originalCountOfRooms = _roomList.Count;
      var roomToCreate = new Room()
      {
        RoomId = 5,
        RoomDescription = "room description 5",
        RoomName = "room name 5"
      };

      var mockRepo = Mock.Create<ILunchAndLearnRepository<Room>>();
      Mock.Arrange(() => mockRepo.Create(Arg.IsAny<Room>())).DoInstead(() => _roomList.Add(roomToCreate)).OccursOnce();

      _roomManager = new RoomManager(mockRepo);

      //act
      _roomManager.Create(roomToCreate);
      var actualCountOfRooms = _roomList.Count;

      //assert
      Mock.Assert(mockRepo);
      Assert.That(actualCountOfRooms, Is.EqualTo(originalCountOfRooms + 1));
    }
  }
}
