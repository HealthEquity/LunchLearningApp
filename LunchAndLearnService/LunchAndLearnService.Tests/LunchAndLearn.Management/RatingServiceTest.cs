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
          InstructorId = 1,
          ClassId = 1,
          ClassRating = 1,
          InstructorRating = 1,
          Comment = "test comment"
        },
        new RatingDto()
        {
          RatingId = 2,
          InstructorId = 2,
          ClassId = 2,
          ClassRating = 2,
          InstructorRating = 2,
          Comment = "test comment 2"
        },
        new RatingDto()
        {
          RatingId = 3,
          InstructorId = 3,
          ClassId = 3,
          ClassRating = 3,
          InstructorRating = 3,
          Comment = "test comment 3"
        },
      };
    }

    [TearDown]
    public void CleanUp()
    {
      _ratingService = null;
      _ratingList = null;
    }


    [Test]
    public void CreatingRating_UnderNormalConditions_AddsRatingToRatingList()
    {
      //arrange
      var originalCountOfRatings = _ratingList.Count;
      var ratingToCreate = new RatingDto()
      {
        InstructorId = 6,
        ClassId = 6,
        RatingId = 6,
        ClassRating = 6,
        Comment = "test comment 6",
        InstructorRating = 6
      };

      var mockRepo = Mock.Create<IUnitOfWork>();
      Mock.Arrange(() => mockRepo.RatingRepository.Insert(Arg.IsAny<Rating>()))
        .DoInstead(() => _ratingList.Add(ratingToCreate))
        .OccursOnce();

      _ratingService = new RatingService(mockRepo);
      //act
      _ratingService.Create(ratingToCreate);
      var actualCount = _ratingList.Count;

      //assert
      Mock.Assert(mockRepo);
      Assert.That(actualCount, Is.EqualTo(originalCountOfRatings + 1));
    }
  }
}
