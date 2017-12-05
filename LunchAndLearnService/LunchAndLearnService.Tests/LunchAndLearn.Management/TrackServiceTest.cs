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
  class TrackServiceTest
  {
    private TrackService _trackService;
    private List<TrackDto> _trackList;

    [SetUp]
    public void Init()
    {
      _trackList = new List<TrackDto>()
      {
        new TrackDto()
        {
          TrackId = 1,
          Name = "track 1",
          Description = "description 1",
          SeasonNr = 1
        },
        new TrackDto()
        {
          TrackId = 2,
          Name = "track 2",
          Description = "description 2",
          SeasonNr = 2
        },
        new TrackDto()
        {
          TrackId = 3,
          Name = "track 3",
          Description = "description 3",
          SeasonNr = 3
        },
      };
    }

    [TearDown]
    public void CleanUp()
    {
      _trackList = null;
      _trackService = null;
    }

    [Test]
    public void CreateTrack_UnderNormalConditions_AddsTrackToTrackList()
    {
      //arrange
      var originalCountOfTracks = _trackList.Count;
      var trackToCreate = new TrackDto()
      {
        TrackId = 6,
        Name = "track 6",
        Description = "description 6",
        SeasonNr = 5
      };

      var mockRepo = Mock.Create<ITrackRepository>();
      Mock.Arrange(() => mockRepo.Create(Arg.IsAny<Track>()))
        .DoInstead(() => _trackList.Add(trackToCreate))
        .OccursOnce();

      _trackService = new TrackService(mockRepo);

      //act
      _trackService.Create(trackToCreate);
      var actualCount = _trackList.Count;

      //assert
      Mock.Assert(mockRepo);
      Assert.That(actualCount, Is.EqualTo(originalCountOfTracks + 1));
    }
  }
}
