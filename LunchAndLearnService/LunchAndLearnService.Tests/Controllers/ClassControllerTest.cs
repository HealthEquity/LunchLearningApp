using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LunchAndLearnService;
using LunchAndLearnService.Controllers;

namespace LunchAndLearnService.Tests.Controllers
{
  [TestClass]
  public class ClassControllerTest
  {
    [TestMethod]
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
