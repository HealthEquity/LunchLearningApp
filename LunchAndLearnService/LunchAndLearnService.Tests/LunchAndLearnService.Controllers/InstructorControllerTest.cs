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
  internal class InstructorControllerTest
  {
    private List<InstructorDto> _mockInstructorList;
    private IInstructorService _instructorService;

    [SetUp]
    public void Init()
    {
      _mockInstructorList = new List<InstructorDto>()
      {
        new InstructorDto() {InstructorId = 1, InstructorName = "John Jacob", IsActive = true},
        new InstructorDto() {InstructorId = 2, InstructorName = "Bruce Wayne", IsActive = true},
        new InstructorDto() {InstructorId = 3, InstructorName = "Clark Kent", IsActive = true}
      };

      _instructorService = Mock.Create<IInstructorService>();
    }

    [TearDown]
    public void Cleanup()
    {
      _mockInstructorList = null;
      _instructorService = null;
    }

    [Test]
    public void GetAll_UnderNormalConditions_ReturnsMultipleInstructors()
    {
      //Arrange
      Mock.Arrange(() => _instructorService.GetAll()).Returns(_mockInstructorList).OccursOnce();

      var expected = _mockInstructorList;

      var instructorController = new InstructorController(_instructorService);

      ////Act
      var actual = instructorController.GetAll() as OkNegotiatedContentResult<List<InstructorDto>>;
      var actualContent = actual.Content;

      //Assert
      Mock.Assert(_instructorService);
      Assert.That(actualContent, Is.EqualTo(expected));
    }

    [Test]
    public void GetById_WhereIdExists_ReturnsInstructorWithThatId([Values(1, 2, 3)]int idToRetrieve)
    {
      //Arrange
      Mock.Arrange(() => _instructorService.Get(idToRetrieve)).Returns(_mockInstructorList.First(x => x.InstructorId == idToRetrieve)).OccursOnce();

      var expected = _mockInstructorList.First(x => x.InstructorId == idToRetrieve);

      var instructorController = new InstructorController(_instructorService);

      ////Act
      var actual = instructorController.Get(idToRetrieve) as OkNegotiatedContentResult<InstructorDto>;
      var actualContent = actual.Content;

      //Assert
      Mock.Assert(_instructorService);
      Assert.That(actualContent, Is.EqualTo(expected));
    }

    [Test]
    public void GetById_WhereIdDoesntExist_ReturnsEmptyCollection([Values(4, 5, 6)]int idToRetrieve)
    {
      //Arrange
      Mock.Arrange(() => _instructorService.Get(idToRetrieve)).Returns(_mockInstructorList.FirstOrDefault(x => x.InstructorId == idToRetrieve)).OccursOnce();

      var expected = _mockInstructorList.FirstOrDefault(x => x.InstructorId == idToRetrieve);

      var instructorController = new InstructorController(_instructorService);

      ////Act
      var actual = instructorController.Get(idToRetrieve) as OkNegotiatedContentResult<InstructorDto>;
      var actualContent = actual.Content;

      //Assert
      Mock.Assert(_instructorService);
      Assert.IsNull(actualContent);
      Assert.IsNull(expected);
    }

    [Test]
    public void CreateInstructor_UnderNormalConditions_ReturnsOkResponse()
    {
      //Arrange
      var instructorToBeCreated = new InstructorDto()
      {
        InstructorId = 10,
        InstructorName = "Wayne Gretzky",
        IsActive = true
      };

      Mock.Arrange(() => _instructorService.Create(instructorToBeCreated))
        .Returns(instructorToBeCreated)
        .OccursOnce();

      var instructorController = new InstructorController(_instructorService)
      {
        Request = new HttpRequestMessage()
        {
          RequestUri = new Uri("http://localhost/api/instructor/create")
        }
      };


      //Act
      var actual = instructorController.Post(instructorToBeCreated) as CreatedNegotiatedContentResult<InstructorDto>;
      var actualContent = actual.Content;

      //Assert
      Mock.Assert(_instructorService);
      Assert.That(actual, Is.Not.Null);
      Assert.That(actualContent, Is.EqualTo(instructorToBeCreated));
      Assert.That(actual, Is.TypeOf<CreatedNegotiatedContentResult<InstructorDto>>());
    }

    [Test]
    public void UpdateInstructor_WhereInstructorExists_UpdatesEntityWithoutError([Values(1, 2, 3)]int idOfInstructorToUpdate)
    {
      //Arrange
      var expected = _mockInstructorList.First(x => x.InstructorId == idOfInstructorToUpdate);
      expected.InstructorName = "UPDATED";

      Mock.Arrange(() => _instructorService.Update(expected)).Returns(expected).OccursOnce();
      var instructorController = new InstructorController(_instructorService)
      {
        Request = new HttpRequestMessage()
        {
          RequestUri = new Uri("http://localhost/api/instructor/create")
        }
      };



      ////Act
      var actual = instructorController.Put(expected) as OkNegotiatedContentResult<InstructorDto>;
      var actualContent = actual.Content;

      //Assert
      Mock.Assert(_instructorService);
      Assert.That(actual, Is.Not.Null);
      Assert.That(actual, Is.TypeOf<OkNegotiatedContentResult<InstructorDto>>());
      Assert.That(actualContent, Is.EqualTo(expected));
    }

    [Test]
    public void DeleteInstructor_WhereInstructorExists_ReturnsOkResponse([Values(1, 2, 3)]int idOfInstructorToDelete)
    {
      //Arrange
      Mock.Arrange(() => _instructorService.Delete(idOfInstructorToDelete)).OccursOnce();

      var instructorController = new InstructorController(_instructorService);

      ////Act
      var actual = instructorController.Delete(idOfInstructorToDelete) as OkResult;

      //Assert
      Mock.Assert(_instructorService);
      Assert.That(actual, Is.TypeOf<OkResult>());
    }
  }
}
