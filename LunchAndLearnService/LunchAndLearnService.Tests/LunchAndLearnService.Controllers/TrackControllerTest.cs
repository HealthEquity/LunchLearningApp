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
  internal class TrackControllerTest
  {
    private ITrackService _trackService;
    private List<TrackDto> _trackList;

    [SetUp]
    public void Init()
    {
      _trackService = Mock.Create<ITrackService>();
      _trackList = new List<TrackDto>()
      {
        new TrackDto()
        {
          TrackId = 1,
          IsActive = true,
          TrackDescription = "track description 1",
          TrackName = "track name 1"
        },
        new TrackDto()
        {
          TrackId = 2,
          IsActive = true,
          TrackDescription = "track description 2",
          TrackName = "track name 2"
        },
        new TrackDto()
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
      _trackService = null;
      _trackList = null;
    }


    [Test]
    public void GetAllTracks_UnderNormalConditions_ReturnsListOfTracks()
    {
      //Arrange
      Mock.Arrange(() => _trackService.GetAll()).Returns(_trackList).OccursOnce();

      var trackController = new TrackController(_trackService);

      var expected = _trackList;

      //Act
      var actual = trackController.GetAll() as OkNegotiatedContentResult<List<TrackDto>>;
      var actualContent = actual.Content;


      //Assert
      Mock.Assert(_trackService);
      Assert.That(actualContent, Is.EqualTo(expected));
    }

    [Test]
    public void GetTrackById_WhereTrackExists_ReturnsTrack([Values(1,2,3)] int idOfTrackToRetrieve)
    {
      //Arrange
      Mock.Arrange(() => _trackService.Get(idOfTrackToRetrieve))
        .Returns(_trackList.FirstOrDefault(t => t.TrackId == idOfTrackToRetrieve))
        .OccursOnce();

      var expected = _trackList.FirstOrDefault(tr => tr.TrackId == idOfTrackToRetrieve);

      var trackController = new TrackController(_trackService);

      //Act
      var actual = trackController.Get(idOfTrackToRetrieve) as OkNegotiatedContentResult<TrackDto>;
      var actualContent = actual.Content;

      //Assert
      Mock.Assert(_trackService);
      Assert.That(actualContent, Is.EqualTo(expected));
    }

    [Test]
    public void CreateTrack_UnderNormalConditions_ReturnsOkResponse()
    {
      //arrange
      var trackToCreate = new TrackDto()
      {
        TrackId = 7,
        IsActive = true,
        TrackDescription = "test description 7",
        TrackName = "track name 7"
      };

      Mock.Arrange(() => _trackService.Create(trackToCreate))
        .Returns(trackToCreate)
        .OccursOnce();

      var trackController= new TrackController(_trackService)
      {
        Request = new HttpRequestMessage()
        {
          RequestUri = new Uri("http://localhost/api/track")
        }
      };

      //act
      var actual = trackController.Post(trackToCreate) as CreatedNegotiatedContentResult<TrackDto>;
      var actualContent = actual.Content;

      //assert
      Mock.Assert(_trackService);
      Assert.That(actual, Is.Not.Null);
      Assert.That(actual, Is.TypeOf<CreatedNegotiatedContentResult<TrackDto>>());
      Assert.That(actualContent, Is.EqualTo(trackToCreate));
    }

    [Test]
    public void UpdateTrack_WhereTrackExists_ReturnsOkResponse([Values(1,2,3)] int idOfTrackToBeUpdated)
    {
      //arrange
      var trackToUpdate = _trackList.FirstOrDefault(tr => tr.TrackId == idOfTrackToBeUpdated);

      Mock.Arrange(() => _trackService.Update(trackToUpdate))
        .Returns(trackToUpdate)
        .OccursOnce();

      var trackController = new TrackController(_trackService)
      {
        Request = new HttpRequestMessage()
        {
          RequestUri = new Uri("http://localhost/api/track")
        }
      };

      //act
      var actual = trackController.Put(trackToUpdate) as OkNegotiatedContentResult<TrackDto>;
      var actualContent = actual.Content;

      //assert
      Mock.Assert(_trackService);
      Assert.That(actual, Is.Not.Null);
      Assert.That(actual, Is.TypeOf<OkNegotiatedContentResult<TrackDto>>());
      Assert.That(actualContent, Is.EqualTo(trackToUpdate));
    }

    [Test]
    public void DeleteTrack_WhereTrackExists_ReturnsOkResponse([Values(1, 2, 3)] int idOfTrackToBeDeleted)
    {
      //arrange
      Mock.Arrange(() => _trackService.Delete(idOfTrackToBeDeleted)).OccursOnce();

      var trackController = new TrackController(_trackService);

      //act
      var actual = trackController.Delete(idOfTrackToBeDeleted) as OkResult;

      //assert
      Mock.Assert(_trackService);
      Assert.That(actual, Is.TypeOf<OkResult>());
    }
  }
}
