using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;
using LunchAndLearn.Management;
using LunchAndLearn.Management.Interfaces;
using LunchAndLearn.Model;
using LunchAndLearn.Model.DB_Models;
using LunchAndLearnService.Controllers;
using NUnit.Framework;
using Telerik.JustMock;

namespace LunchAndLearnService.Tests.LunchAndLearnService.Controllers
{
  [TestFixture]
  internal class InstructorControllerTest
  {
    private List<Instructor> _mockInstructorList;
    private IManagerClass<Instructor> _instructorManager;

    [SetUp]
    public void Init()
    {
      _mockInstructorList = new List<Instructor>()
      {
        new Instructor() {InstructorId = 1, InstructorName = "John Jacob", IsActive = true},
        new Instructor() {InstructorId = 2, InstructorName = "Bruce Wayne", IsActive = true},
        new Instructor() {InstructorId = 3, InstructorName = "Clark Kent", IsActive = true}
      };

      _instructorManager = Mock.Create<IManagerClass<Instructor>>();
    }

    [TearDown]
    public void Cleanup()
    {
      _mockInstructorList = null;
      _instructorManager = null;
    }

    [Test]
    public void GetAll_UnderNormalConditions_ReturnsMultipleInstructors()
    {
      //Arrange
      Mock.Arrange(() => _instructorManager.GetAll()).Returns(_mockInstructorList).OccursOnce();

      var expected = _mockInstructorList;

      var instructorController = new InstructorController(_instructorManager);

      ////Act
      var actual = instructorController.GetAll() as OkNegotiatedContentResult<List<Instructor>>;
      var actualContent = actual.Content;

      //Assert
      Mock.Assert(_instructorManager);
      Assert.That(actualContent, Is.EqualTo(expected));
    }

    [Test]
    public void GetById_WhereIdExists_ReturnsInstructorWithThatId([Values(1, 2, 3)]int idToRetrieve)
    {
      //Arrange
      Mock.Arrange(() => _instructorManager.Get(idToRetrieve)).Returns(_mockInstructorList.First(x => x.InstructorId == idToRetrieve)).OccursOnce();

      var expected = _mockInstructorList.First(x => x.InstructorId == idToRetrieve);

      var instructorController = new InstructorController(_instructorManager);

      ////Act
      var actual = instructorController.Get(idToRetrieve) as OkNegotiatedContentResult<Instructor>;
      var actualContent = actual.Content;

      //Assert
      Mock.Assert(_instructorManager);
      Assert.That(actualContent, Is.EqualTo(expected));
    }

    [Test]
    public void GetById_WhereIdDoesntExist_ReturnsEmptyCollection([Values(4, 5, 6)]int idToRetrieve)
    {
      //Arrange
      Mock.Arrange(() => _instructorManager.Get(idToRetrieve)).Returns(_mockInstructorList.FirstOrDefault(x => x.InstructorId == idToRetrieve)).OccursOnce();

      var expected = _mockInstructorList.FirstOrDefault(x => x.InstructorId == idToRetrieve);

      var instructorController = new InstructorController(_instructorManager);

      ////Act
      var actual = instructorController.Get(idToRetrieve) as OkNegotiatedContentResult<Instructor>;
      var actualContent = actual.Content;

      //Assert
      Mock.Assert(_instructorManager);
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

      Mock.Arrange(() => _instructorManager.Create(instructorToBeCreated)).OccursOnce();

      var instructorController = new InstructorController(_instructorManager);

      //Act
      var actual = instructorController.Post(instructorToBeCreated) as OkResult;

      //Assert
      Mock.Assert(_instructorManager);
      Assert.That(actual, Is.TypeOf<OkResult>());
    }

    [Test]
    public void UpdateInstructor_WhereInstructorExists_UpdatesEntityWithoutError([Values(1, 2, 3)]int idOfInstructorToUpdate)
    {
      //Arrange
      var expected = _mockInstructorList.First(x => x.InstructorId == idOfInstructorToUpdate);
      expected.InstructorName = "UPDATED";

      Mock.Arrange(() => _instructorManager.Update(expected)).OccursOnce();

      var instructorController = new InstructorController(_instructorManager);

      ////Act
      var actual = instructorController.Put(expected) as OkResult;

      //Assert
      Mock.Assert(_instructorManager);
      Assert.That(actual, Is.TypeOf<OkResult>());
    }

    [Test]
    public void DeleteInstructor_WhereInstructorExists_ReturnsOkResponse([Values(1, 2, 3)]int idOfInstructorToDelete)
    {
      //Arrange
      Mock.Arrange(() => _instructorManager.Delete(idOfInstructorToDelete)).OccursOnce();

      var instructorController = new InstructorController(_instructorManager);

      ////Act
      var actual = instructorController.Delete(idOfInstructorToDelete) as OkResult;

      //Assert
      Mock.Assert(_instructorManager);
      Assert.That(actual, Is.TypeOf<OkResult>());
    }
  }
}
