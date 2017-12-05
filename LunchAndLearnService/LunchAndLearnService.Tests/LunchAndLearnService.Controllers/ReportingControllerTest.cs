using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using LunchAndLearn.Management.Interfaces;
using LunchAndLearn.Model.DTOs;
using LunchAndLearnService.Controllers;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Telerik.JustMock;
using Telerik.JustMock.Helpers;

namespace LunchAndLearnService.Tests.LunchAndLearnService.Controllers
{
  [TestFixture]
  public class ReportingControllerTest
  {
    private List<RatingDto> _ratingsList;

    [SetUp]
    public void Init()
    {

      _ratingsList = new List<RatingDto>()
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
      _ratingsList = null;
    }

    //[Test]
    //public void GetAverageScoreForInstructorByInstructorId_WhereInstructorExists_ReturnsAverageOfAllRatingsForInstructor([Values(1, 2, 3)]int instructorId)
    //{
    //  //arrange
    //  var expectedScore =
    //    _ratingsList.Where(x => x.InstructorId == instructorId).Select(x => x.InstructorRating).Average();
    //  var expectedResponse = new OverallInstructorRatingDTO()
    //  {
    //    InstructorId = instructorId,
    //    OverallInstructorRating = expectedScore
    //  };

    //  IReportingService reportingService = Mock.Create<IReportingService>();
    //  Mock.Arrange(() => reportingService.GetAverageRatingForInstructor(instructorId)).Returns(expectedResponse);

    //  var reportingController = new ReportingController(reportingService);

    //  //act
    //  var actual = reportingController.GetAverageRatingForInstructor(instructorId) as OkNegotiatedContentResult<OverallInstructorRatingDTO>;
    //  var actualContent = actual.Content;

    //  //assert
    //  Mock.Assert(reportingService);
    //  Assert.That(actual, Is.Not.Null);
    //  Assert.That(actual, Is.TypeOf(typeof(OkNegotiatedContentResult<OverallInstructorRatingDTO>)));
    //  Assert.That(actualContent, Is.EqualTo(expectedResponse));
    //}

    //[Test]
    //public void GetAverageScoreForInstructorByInstructorId_WhereInstructorDoesntExist_ReturnsNotFoundResult([Values(100, 200, 300)]int instructorId)
    //{
    //  //arrange
    //  OverallInstructorRatingDTO expected = null;

    //  IReportingService reportingService = Mock.Create<IReportingService>();
    //  Mock.Arrange(() => reportingService.GetAverageRatingForInstructor(instructorId)).Returns(expected);

    //  var reportingController = new ReportingController(reportingService);

    //  //act
    //  var actual = reportingController.GetAverageRatingForInstructor(instructorId) as NotFoundResult;

    //  //assert
    //  Mock.Assert(reportingService);
    //  Assert.That(actual, Is.Not.Null);
    //  Assert.That(actual, Is.TypeOf(typeof(NotFoundResult)));
    //}
  }
}
