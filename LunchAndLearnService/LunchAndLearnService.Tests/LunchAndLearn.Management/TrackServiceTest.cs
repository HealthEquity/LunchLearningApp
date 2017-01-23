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
          TrackName = "track 1",
          TrackDescription = "track description 1",
          IsActive = true
        },
        new TrackDto()
        {
          TrackId = 2,
          TrackName = "track 2",
          TrackDescription = "track description 2",
          IsActive = true
        },
        new TrackDto()
        {
          TrackId = 3,
          TrackName = "track 3",
          TrackDescription = "track description 3",
          IsActive = false
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
        TrackName = "track 6",
        TrackDescription = "track description 6",
        IsActive = true
      };

      var mockRepo = Mock.Create<IUnitOfWork>();
      Mock.Arrange(() => mockRepo.TrackRepository.Insert(Arg.IsAny<Track>()))
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
