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
using NUnit.Framework;
using Telerik.JustMock;

namespace LunchAndLearnService.Tests.LunchAndLearn.Management
{
  [TestFixture]
  public class RatingManagerTest
  {
    private RatingManager _ratingManager;
    private List<Rating> _ratingList;

    [SetUp]
    public void Init()
    {
      _ratingList = new List<Rating>()
      {
        new Rating()
        {
          RatingId = 1,
          InstructorId = 1,
          ClassId = 1,
          ClassRating = 1,
          InstructorRating = 1,
          Comment = "test comment"
        },
        new Rating()
        {
          RatingId = 2,
          InstructorId = 2,
          ClassId = 2,
          ClassRating = 2,
          InstructorRating = 2,
          Comment = "test comment 2"
        },
        new Rating()
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
      _ratingManager = null;
      _ratingList = null;
    }


    [Test]
    public void CreatingRating_UnderNormalConditions_AddsRatingToRatingList()
    {
      //arrange
      var originalCountOfRatings = _ratingList.Count;
      var ratingToCreate = new Rating()
      {
        InstructorId = 6,
        ClassId = 6,
        RatingId = 6,
        ClassRating = 6,
        Comment = "test comment 6",
        InstructorRating = 6
      };

      var mockRepo = Mock.Create<IRatingRepository>();
      Mock.Arrange(() => mockRepo.Create(Arg.IsAny<Rating>()))
        .DoInstead(() => _ratingList.Add(ratingToCreate))
        .OccursOnce();

      _ratingManager = new RatingManager(mockRepo);
      //act
      _ratingManager.Create(ratingToCreate);
      var actualCount = _ratingList.Count;

      //assert
      Mock.Assert(mockRepo);
      Assert.That(actualCount, Is.EqualTo(originalCountOfRatings + 1));
    }
  }
}
