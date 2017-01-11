using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;
using LunchAndLearn.Management;
using LunchAndLearn.Management.Interfaces;
using LunchAndLearn.Model;
using LunchAndLearnService.Controllers;
using NUnit.Framework;
using Telerik.JustMock;

namespace LunchAndLearnService.Tests.LunchAndLearnService.Controllers
{
  [TestFixture]
  internal class TrackControllerTest
  {
    private IManagerClass<Track> _trackManager;
    private List<Track> _trackList;

    [SetUp]
    public void Init()
    {
      _trackManager = Mock.Create<IManagerClass<Track>>();
      _trackList = new List<Track>()
      {
        new Track()
        {
          TrackId = 1,
          IsActive = true,
          TrackDescription = "track description 1",
          TrackName = "track name 1"
        },
        new Track()
        {
          TrackId = 2,
          IsActive = true,
          TrackDescription = "track description 2",
          TrackName = "track name 2"
        },
        new Track()
        {
          TrackId = 3,
          IsActive = true,
          TrackDescription = "track description 3",
          TrackName = "track name 3"
        }
      };
    }

    [TearDown]
    public void CleanUp()
    {
      _trackManager = null;
      _trackList = null;
    }


    [Test]
    public void GetAllTracks_UnderNormalConditions_ReturnsListOfTracks()
    {
      //Arrange
      Mock.Arrange(() => _trackManager.GetAll()).Returns(_trackList).OccursOnce();

      var trackController = new TrackController(_trackManager);

      var expected = _trackList;

      //Act
      var actual = trackController.GetAll() as OkNegotiatedContentResult<List<Track>>;
      var actualContent = actual.Content;


      //Assert
      Mock.Assert(_trackManager);
      Assert.That(actualContent, Is.EqualTo(expected));
    }

    [Test]
    public void GetTrackById_WhereTrackExists_ReturnsTrack([Values(1,2,3)] int idOfTrackToRetrieve)
    {
      //Arrange
      Mock.Arrange(() => _trackManager.Get(idOfTrackToRetrieve))
        .Returns(_trackList.FirstOrDefault(t => t.TrackId == idOfTrackToRetrieve))
        .OccursOnce();

      var expected = _trackList.FirstOrDefault(tr => tr.TrackId == idOfTrackToRetrieve);

      var trackController = new TrackController(_trackManager);

      //Act
      var actual = trackController.Get(idOfTrackToRetrieve) as OkNegotiatedContentResult<Track>;
      var actualContent = actual.Content;

      //Assert
      Mock.Assert(_trackManager);
      Assert.That(actualContent, Is.EqualTo(expected));
    }

    [Test]
    public void CreateTrack_UnderNormalConditions_ReturnsOkResponse()
    {
      //arrange
      var trackToCreate = new Track()
      {
        TrackId = 7,
        IsActive = true,
        TrackDescription = "test description 7",
        TrackName = "track name 7"
      };

      Mock.Arrange(() => _trackManager.Create(trackToCreate)).OccursOnce();

      var trackController= new  TrackController(_trackManager);

      //act
      var actual = trackController.Create(trackToCreate) as OkResult;

      //assert
      Mock.Assert(_trackManager);
      Assert.That(actual, Is.TypeOf<OkResult>());
    }

    [Test]
    public void UpdateTrack_WhereTrackExists_ReturnsOkResponse([Values(1,2,3)] int idOfTrackToBeUpdated)
    {
      //arrange
      var trackToUpdate = _trackList.FirstOrDefault(tr => tr.TrackId == idOfTrackToBeUpdated);
      Mock.Arrange(() => _trackManager.Update(trackToUpdate)).OccursOnce();

      var trackController = new TrackController(_trackManager);

      //act
      var actual = trackController.Put(trackToUpdate) as OkResult;

      //assert
      Mock.Assert(_trackManager);
      Assert.That(actual, Is.TypeOf<OkResult>());
    }

    [Test]
    public void DeleteTrack_WhereTrackExists_ReturnsOkResponse([Values(1, 2, 3)] int idOfTrackToBeDeleted)
    {
      //arrange
      Mock.Arrange(() => _trackManager.Delete(idOfTrackToBeDeleted)).OccursOnce();

      var trackController = new TrackController(_trackManager);

      //act
      var actual = trackController.Delete(idOfTrackToBeDeleted) as OkResult;

      //assert
      Mock.Assert(_trackManager);
      Assert.That(actual, Is.TypeOf<OkResult>());
    }
  }
}
