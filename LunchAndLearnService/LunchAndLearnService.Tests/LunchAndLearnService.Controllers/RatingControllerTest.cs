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
  internal class RatingControllerTest
  {
    private IRatingService _ratingService;
    private List<RatingDto> _ratingsList;

    [SetUp]
    public void Init()
    {
      _ratingService = Mock.Create<IRatingService>();
      _ratingsList = new List<RatingDto>()
      {
        new RatingDto()
        {
          ClassId = 1,
          RatingId = 1,
          ClassRating = 1,
          Comment = "blah",
          InstructorId = 1,
          InstructorRating = 1
        },
        new RatingDto()
        {
          ClassId = 2,
          RatingId = 2,
          ClassRating = 2,
          Comment = "blah blah",
          InstructorId = 2,
          InstructorRating = 2
        },
        new RatingDto()
        {
          ClassId = 3,
          RatingId = 3,
          ClassRating = 3,
          Comment = "blah blah blah",
          InstructorId = 3,
          InstructorRating = 3
        }
      };
    }

    [TearDown]
    public void Cleanup()
    {
      _ratingService = null;
      _ratingsList = null;
    }

    [Test]
    public void GetAllRatings_UnderNormalConditions_ReturnsMultipleRatings()
    {
      //Arrange
      Mock.Arrange(() => _ratingService.GetAll()).Returns(_ratingsList).OccursOnce();

      var expected = _ratingsList;

      var ratingController = new RatingController(_ratingService);

      //Act
      var actual = ratingController.GetAll() as OkNegotiatedContentResult<List<RatingDto>>;
      var actualContent = actual.Content;


      //Assert
      Mock.Assert(_ratingService);
      Assert.That(actualContent, Is.EqualTo(expected));
    }

    [Test]
    public void GetRatingById_WhereRatingExists_ReturnsRatingMatchingIdArgument([Values(1,2,3)]int idOfRatingToBeFound)
    {
      //Arrange
      var expected = _ratingsList.FirstOrDefault(x => x.RatingId == idOfRatingToBeFound);
      Mock.Arrange(() => _ratingService.Get(idOfRatingToBeFound))
        .Returns(_ratingsList.FirstOrDefault(x => x.RatingId == idOfRatingToBeFound))
        .OccursOnce();

      
      var ratingController = new RatingController(_ratingService);

      //Act
      var actual = ratingController.Get(idOfRatingToBeFound) as OkNegotiatedContentResult<RatingDto>;
      var actualContent = actual.Content;


      //Assert
      Mock.Assert(_ratingService);
      Assert.That(actualContent, Is.EqualTo(expected));
    }

    [Test]
    public void CreateRating_UnderNormalConditions_ReturnsOkResponse()
    {
      //Arrange
      var ratingToCreate = new RatingDto()
      {
        InstructorId = 5,
        ClassId = 5,
        ClassRating = 5,
        Comment = "Creating a new rating comment..",
        InstructorRating = 5,
        RatingId = 5
      };
      Mock.Arrange(() => _ratingService.Create(ratingToCreate))
        .Returns(ratingToCreate)
        .OccursOnce();

      var ratingController = new RatingController(_ratingService)
      {
        Request = new HttpRequestMessage()
        {
          RequestUri = new Uri("http://localhost/api/rating")
        }
      };

      //Act
      var actual = ratingController.Post(ratingToCreate) as CreatedNegotiatedContentResult<RatingDto>;
      var actualContent = actual.Content;

      //Assert
      Mock.Assert(_ratingService);
      Assert.IsNotNull(actual);
      Assert.That(actual, Is.TypeOf<CreatedNegotiatedContentResult<RatingDto>>());
      Assert.That(actualContent, Is.EqualTo(ratingToCreate));
    }

    [Test]
    public void UpdateRating_WhereRatingExists_ReturnsOkResponse([Values(1,2,3)] int ratingIdToUpdate)
    {
      //arrange
      var ratingToUpdate = _ratingsList.FirstOrDefault(x => x.RatingId == ratingIdToUpdate);

      Mock.Arrange(() => _ratingService.Update(ratingToUpdate)).Returns(ratingToUpdate).OccursOnce();

      var ratingController = new RatingController(_ratingService)
      {
        Request = new HttpRequestMessage()
        {
          RequestUri = new Uri("http://localhost/api/rating")
        }
      };

      //act
      var actual = ratingController.Put(ratingToUpdate) as OkNegotiatedContentResult<RatingDto>;
      var actualContent = actual.Content;

      //assert
      Mock.Assert(_ratingService);
      Assert.That(actual, Is.Not.Null);
      Assert.That(actual, Is.TypeOf<OkNegotiatedContentResult<RatingDto>>());
      Assert.That(actualContent, Is.EqualTo(ratingToUpdate));
    }

    [Test]
    public void DeleteRating_WhereRatingExists_ReturnsOkResponse([Values(1,2,3)] int ratingIdToDelete)
    {
      //arrange
      Mock.Arrange(() => _ratingService.Delete(ratingIdToDelete)).OccursOnce();

      var ratingController = new RatingController(_ratingService);

      //act
      var actual = ratingController.Delete(ratingIdToDelete) as OkResult;

      //assert
      Mock.Assert(_ratingService);
      Assert.That(actual, Is.TypeOf<OkResult>());
    }
  }
}
