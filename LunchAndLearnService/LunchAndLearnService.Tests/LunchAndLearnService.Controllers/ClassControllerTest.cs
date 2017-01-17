using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using LunchAndLearn.Management;
using LunchAndLearn.Management.Interfaces;
using LunchAndLearn.Model;
using LunchAndLearn.Model.DB_Models;
using LunchAndLearn.Model.DTOs;
using LunchAndLearnService.Controllers;
using NUnit.Framework;
using Telerik.JustMock;
using Telerik.JustMock.AutoMock.Ninject.Infrastructure.Language;
using Telerik.JustMock.Helpers;

namespace LunchAndLearnService.Tests.LunchAndLearnService.Controllers
{
  [TestFixture]
  internal class ClassControllerTest
  {
    private List<ClassDto> _mockClassList;
    private IClassService _classService;
    private ClassController _classController;

    [SetUp]
    public void Init()
    {
      _classService = Mock.Create<IClassService>();

      _classController = new ClassController(_classService)
      {
        Request = new HttpRequestMessage()
        {
          RequestUri = new Uri("http://localhost/api/class")
        }
      };

      _mockClassList = new List<ClassDto>()
      {
        new ClassDto() {ClassDescription = "test class description 1", ClassId = 1, ClassName = "Test Class 1"},
        new ClassDto() {ClassDescription = "test class description 2", ClassId = 2, ClassName = "Test Class 2"}
      };

    }

    [TearDown]
    public void CleanUp()
    {
      _mockClassList = null;
      _classService = null;
      _classController = null;
    }

    [Test]
    public void GetAll_UnderNormalConditions_DoesNotReturnNull()
    {
      // Arrange
      Mock.Arrange(() => _classService.GetAll()).Returns(_mockClassList).OccursOnce();
      var classController = new ClassController(_classService);

      //// Act
      var result = (OkNegotiatedContentResult<List<ClassDto>>)classController.GetAll();

      var actualResult = result.Content;

      //// Assert
      Assert.IsNotNull(actualResult);
      Assert.That(actualResult.Count, Is.GreaterThan(1));
      Mock.Assert(_classService);
    }

    [Test]
    public void GetOneById_WhereIdExists_DoesNotReturnNull([Values(1, 2)]int idToRetrieve)
    {
      // Arrange
      var expected = _mockClassList.FirstOrDefault(x => x.ClassId == idToRetrieve);
      Mock.Arrange(() => _classService.Get(idToRetrieve))
        .Returns(_mockClassList.FirstOrDefault(x => x.ClassId == idToRetrieve))
        .OccursOnce();
      var classController = new ClassController(_classService);

      //// Act
      var result = (OkNegotiatedContentResult<ClassDto>)classController.Get(idToRetrieve);

      var actualResult = result.Content;


      //Assert
      Mock.Assert(_classService);
      Assert.That(actualResult, Is.EqualTo(expected));
    }

    [Test]
    public void CreateClass_UnderNormalConditions_ReturnsCreatedResponse()
    {
      //Arrange
      var classToCreate = new ClassDto()
      {
        ClassDescription = "This is a test class.",
        ClassId = 5,
        ClassName = "This is a test class name"
      };

      Mock.Arrange(() => _classService.Create(classToCreate))
        .Returns(classToCreate)
        .OccursOnce();

      _classController.Request.RequestUri = new Uri("http://localhost/api/class/create");

      //Act

      var actual = _classController.Post(classToCreate) as CreatedNegotiatedContentResult<ClassDto>;
      var actualContent = actual.Content;
      //var actualContent = actual.Content;

      //Assert
      Mock.Assert(_classService);
      Assert.That(actual, Is.TypeOf<CreatedNegotiatedContentResult<ClassDto>>());
      Assert.That(actualContent, Is.EqualTo(classToCreate));
    }

    [Test]
    public void UpdateClass_WhereClassExists_ReturnsOkResponse([Values(1,2,3)] int idOfClassToUpdate)
    {
      //Arrange
      var classToBeUpdated = _mockClassList.FirstOrDefault(x => x.ClassId == idOfClassToUpdate);

      Mock.Arrange(() => _classService.Update(classToBeUpdated))
        .Returns(classToBeUpdated)
        .OccursOnce();

      //Act
      var actual = _classController.Put(classToBeUpdated) as OkNegotiatedContentResult<ClassDto>;
      var actualContent = actual.Content;

      //Assert
      Mock.Assert(_classService);
      Assert.That(actual, Is.Not.Null);
      Assert.That(actualContent, Is.EqualTo(classToBeUpdated));
      Assert.That(actual, Is.TypeOf<OkNegotiatedContentResult<ClassDto>>());
    }

    [Test]
    public void DeleteClass_WhereClassExists_ReturnsOkResponse([Values(1, 2, 3)] int idOfClassToBeDeleted)
    {
      //Arrange
      Mock.Arrange(() => _classService.Delete(idOfClassToBeDeleted)).OccursOnce();
      var classController = new ClassController(_classService);

      //Act
      var actual = classController.Delete(idOfClassToBeDeleted) as OkResult;

      //Assert
      Mock.Assert(_classService);
      Assert.That(actual, Is.TypeOf<OkResult>());
    }
  }
}
