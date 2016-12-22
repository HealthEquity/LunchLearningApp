using System.Web.Mvc;
using LunchAndLearnService;
using LunchAndLearnService.Controllers;
using NUnit.Framework;

namespace LunchAndLearnService.Tests.Controllers
{
  [TestFixture]
  public class ClassControllerTest
  {
    [Test]
    public void Index()
    {
      // Arrange
      ClassController controller = new ClassController();

      //// Act
      //ViewResult result = controller.Index() as ViewResult;

      //// Assert
      //Assert.IsNotNull(result);
      //Assert.AreEqual("Home Page", result.ViewBag.Title);
    }
  }
}
