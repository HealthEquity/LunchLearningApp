using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using LunchAndLearnService;
using LunchAndLearnService.Controllers;
using NUnit.Framework;
using LunchAndLearn.Management;
using LunchAndLearn.Model;
using Telerik.JustMock;

namespace LunchAndLearnService.Tests.Controllers
{
  [TestFixture]
  public class ClassControllerTest
  {
    private List<Class> _mockClassList;

    [SetUp]
    public void Init()
    {
      _mockClassList = new List<Class>()
      {
        new Class() {ClassDescription = "test class description 1", ClassId = 1, ClassName = "Test Class 1"},
        new Class() {ClassDescription = "test class description 2", ClassId = 2, ClassName = "Test Class 2"}
      };
    }

    [Test]
    public void GetAll_UnderNormalConditions_DoesNotReturnNull()
    {
      // Arrange
      var mockClassController = Mock.Create<ClassController>();
      Mock.Arrange(() => mockClassController.GetAll())
        .Returns(new OkNegotiatedContentResult<ICollection<Class>>(_mockClassList, mockClassController)).OccursOnce();

      //// Act
      var result = (OkNegotiatedContentResult<ICollection<Class>>)mockClassController.GetAll();

      var actualResult = result.Content;

      //// Assert
      Assert.IsNotNull(actualResult);
      Mock.Assert(mockClassController);
    }

    [Test]
    public void GetOneById_WhereIdExists_DoesNotReturnNull([Values(1, 2)]int idToRetrieve)
    {
      //Arrange
      var mockClassController = Mock.Create<ClassController>();
      Mock.Arrange(() => mockClassController.Get(idToRetrieve))
        .Returns(new OkNegotiatedContentResult<ICollection<Class>>(_mockClassList.Where(x => x.ClassId == idToRetrieve).ToList(), mockClassController))
        .OccursOnce();

      //Act
      var result = (OkNegotiatedContentResult<ICollection<Class>>)mockClassController.Get(idToRetrieve);

      var actualResult = result.Content;


      //Assert
      Assert.IsNotNull(actualResult);
      Mock.Assert(mockClassController);
    }
  }
}
