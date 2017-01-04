using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;
using LunchAndLearn.Management;
using LunchAndLearn.Model;
using LunchAndLearnService.Controllers;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using Telerik.JustMock;
using Telerik.JustMock.AutoMock.Ninject.Infrastructure.Language;
using Telerik.JustMock.Helpers;

namespace LunchAndLearnService.Tests.Controllers
{
  [TestFixture]
  public class InstructorControllerTest
  {
    private List<Instructor> _mockInstructorList;
    private ILunchAndLearnManager _lunchAndLearnManager;

    [SetUp]
    public void Init()
    {
      _mockInstructorList = new List<Instructor>()
      {
        new Instructor() {InstructorId = 1, InstructorName = "John Jacob", IsActive = true},
        new Instructor() {InstructorId = 2, InstructorName = "Bruce Wayne", IsActive = true},
        new Instructor() {InstructorId = 3, InstructorName = "Clark Kent", IsActive = true}
      };

      _lunchAndLearnManager = Mock.Create<ILunchAndLearnManager>();
    }

    [TearDown]
    public void Cleanup()
    {
      _mockInstructorList = null;
      _lunchAndLearnManager = null;
    }

    [Test]
    public void GetAll_UnderNormalConditions_ReturnsMultipleInstructors()
    {
      //Arrange
      Mock.Arrange(() => _lunchAndLearnManager.InstructorManager.GetAll()).Returns(_mockInstructorList).OccursOnce();

      var expected = _mockInstructorList;

      var instructorController = new InstructorController(_lunchAndLearnManager);

      ////Act
      var actual = instructorController.GetAll() as OkNegotiatedContentResult<List<Instructor>>;
      var actualContent = actual.Content;

      //Assert
      Mock.Assert(_lunchAndLearnManager);
      Assert.That(actualContent, Is.EqualTo(expected));
    }

    [Test]
    public void GetById_WhereIdExists_ReturnsInstructorWithThatId([Values(1, 2, 3)]int idToRetrieve)
    {
      //Arrange
      Mock.Arrange(() => _lunchAndLearnManager.InstructorManager.Get(idToRetrieve)).Returns(_mockInstructorList.First(x => x.InstructorId == idToRetrieve)).OccursOnce();

      var expected = _mockInstructorList.First(x => x.InstructorId == idToRetrieve);

      var instructorController = new InstructorController(_lunchAndLearnManager);

      ////Act
      var actual = instructorController.Get(idToRetrieve) as OkNegotiatedContentResult<Instructor>;
      var actualContent = actual.Content;

      //Assert
      Mock.Assert(_lunchAndLearnManager);
      Assert.That(actualContent, Is.EqualTo(expected));
    }

    [Test]
    public void GetById_WhereIdDoesntExist_ReturnsEmptyCollection([Values(4, 5, 6)]int idToRetrieve)
    {
      //Arrange
      Mock.Arrange(() => _lunchAndLearnManager.InstructorManager.Get(idToRetrieve)).Returns(_mockInstructorList.FirstOrDefault(x => x.InstructorId == idToRetrieve)).OccursOnce();

      var expected = _mockInstructorList.FirstOrDefault(x => x.InstructorId == idToRetrieve);

      var instructorController = new InstructorController(_lunchAndLearnManager);

      ////Act
      var actual = instructorController.Get(idToRetrieve) as OkNegotiatedContentResult<Instructor>;
      var actualContent = actual.Content;

      //Assert
      Mock.Assert(_lunchAndLearnManager);
      Assert.IsNull(actualContent);
      Assert.IsNull(expected);
    }

    [Test]
    public void CreateInstructor_UnderNormalConditions_ReturnsOkResponse()
    {
      //Arrange
      var instructorToBeCreated = new Instructor()
      {
        InstructorId = 10,
        InstructorName = "Wayne Gretzky",
        IsActive = true
      };

      Mock.Arrange(() => _lunchAndLearnManager.InstructorManager.Create(instructorToBeCreated)).OccursOnce();

      var instructorController = new InstructorController(_lunchAndLearnManager);

      //Act
      var actual = instructorController.Post(instructorToBeCreated) as OkResult;

      //Assert
      Mock.Assert(_lunchAndLearnManager);
      Assert.That(actual, Is.TypeOf<OkResult>());
    }

    [Test]
    public void UpdateInstructor_WhereInstructorExists_UpdatesEntityWithoutError([Values(1, 2, 3)]int idOfInstructorToUpdate)
    {
      //Arrange
      var expected = _mockInstructorList.First(x => x.InstructorId == idOfInstructorToUpdate);
      expected.InstructorName = "UPDATED";

      Mock.Arrange(() => _lunchAndLearnManager.InstructorManager.Update(expected)).OccursOnce();

      var instructorController = new InstructorController(_lunchAndLearnManager);

      ////Act
      var actual = instructorController.Put(expected) as OkResult;

      //Assert
      Mock.Assert(_lunchAndLearnManager);
      Assert.That(actual, Is.TypeOf<OkResult>());
    }

    [Test]
    public void DeleteInstructor_WhereInstructorExists_ReturnsOkResponse([Values(1, 2, 3)]int idOfInstructorToDelete)
    {
      //Arrange
      Mock.Arrange(() => _lunchAndLearnManager.InstructorManager.Delete(idOfInstructorToDelete)).OccursOnce();

      var instructorController = new InstructorController(_lunchAndLearnManager);

      ////Act
      var actual = instructorController.Delete(idOfInstructorToDelete) as OkResult;

      //Assert
      Mock.Assert(_lunchAndLearnManager);
      Assert.That(actual, Is.TypeOf<OkResult>());
    }
  }
}
