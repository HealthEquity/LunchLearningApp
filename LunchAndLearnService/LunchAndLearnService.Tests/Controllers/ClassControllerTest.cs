using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;
using LunchAndLearn.Management;
using LunchAndLearnService.Controllers;
using NUnit.Framework;
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
      var lunchAndLearnManager = Mock.Create<ILunchAndLearnManager>();
      Mock.Arrange(() => lunchAndLearnManager.ClassManager.GetAll()).Returns(_mockClassList).OccursOnce();
      var classController = new ClassController(lunchAndLearnManager);

      //// Act
      var result = (OkNegotiatedContentResult<List<Class>>)classController.GetAll();

      var actualResult = result.Content;

      //// Assert
      Assert.IsNotNull(actualResult);
      Assert.That(actualResult.Count, Is.GreaterThan(1));
      Mock.Assert(lunchAndLearnManager);
    }

    [Test]
    public void GetOneById_WhereIdExists_DoesNotReturnNull([Values(1, 2)]int idToRetrieve)
    {
      // Arrange
      var lunchAndLearnManager = Mock.Create<ILunchAndLearnManager>();
      var expected = _mockClassList.FirstOrDefault(x => x.ClassId == idToRetrieve);
      Mock.Arrange(() => lunchAndLearnManager.ClassManager.Get(idToRetrieve))
        .Returns(_mockClassList.FirstOrDefault(x => x.ClassId == idToRetrieve))
        .OccursOnce();
      var classController = new ClassController(lunchAndLearnManager);

      //// Act
      var result = (OkNegotiatedContentResult<Class>)classController.Get(idToRetrieve);

      var actualResult = result.Content;


      //Assert
      Mock.Assert(lunchAndLearnManager);
      Assert.That(actualResult, Is.EqualTo(expected));
    }
  }
}
