using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchAndLearn.Data.Interfaces;
using LunchAndLearn.Management;
using LunchAndLearn.Management.Interfaces;
using LunchAndLearn.Model;
using LunchAndLearn.Model.DB_Models;
using LunchAndLearn.Model.DTOs;
using NUnit.Framework;
using Telerik.JustMock;

namespace LunchAndLearnService.Tests.LunchAndLearn.Management
{
  [TestFixture]
  public class RatingServiceTest
  {
    private RatingService _ratingService;
    private List<RatingDto> _ratingList;

    [SetUp]
    public void Init()
    {
      _ratingList = new List<RatingDto>()
      {
        new RatingDto()
        {
          RatingId = 1,
          TrackSessionId = 1,
          InstructorScoreNr = 1,
          SessionScoreNr = 1,
          Comment = "This is a comment"
        },
        new RatingDto()
        {
          RatingId = 2,
          TrackSessionId = 2,
          InstructorScoreNr = 2,
          SessionScoreNr = 2,
          Comment = "This is another a comment"
        },
      };
    }

    [TearDown]
    public void CleanUp()
    {
      _ratingService = null;
      _ratingList = null;
    }


    //[Test]
    //public void CreatingRating_UnderNormalConditions_AddsRatingToRatingList()
    //{
    //  //arrange
    //  var originalCountOfRatings = _ratingList.Count;
    //  var ratingToCreate = new RatingDto()
    //    {
    //      RatingId = 2,
    //      TrackSessionId = 2,
    //      InstructorScoreNr = 2,
    //      SessionScoreNr = 2,
    //      Comment = "This is another a comment"
    //    },

    //  var mockRepo = Mock.Create<IRatingRepository>();
    //  Mock.Arrange(() => mockRepo.Create(Arg.IsAny<Rating>()))
    //    .DoInstead(() => _ratingList.Add(ratingToCreate))
    //    .OccursOnce();

    //  _ratingService = new RatingService(mockRepo);
    //  //act
    //  _ratingService.Create(ratingToCreate);
    //  var actualCount = _ratingList.Count;

    //  //assert
    //  Mock.Assert(mockRepo);
    //  Assert.That(actualCount, Is.EqualTo(originalCountOfRatings + 1));
    //}
  }
}
