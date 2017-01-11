using System.Collections.Generic;
using LunchAndLearn.Data;
using LunchAndLearn.Data.Repositories;
using LunchAndLearn.Management;
using LunchAndLearn.Model;
using NUnit.Framework;
using Telerik.JustMock;
using Telerik.JustMock.Helpers;

namespace LunchAndLearnService.Tests.LunchAndLearn.Management
{
  [TestFixture]
  internal class ClassManagerTest
  {
    private List<Class> _classList;
    private ClassManager _classManager;

    [SetUp]
    public void Init()
    {
      _classManager = new ClassManager();

      _classList = new List<Class>()
      {
        new Class()
        {
          ClassId = 1,
          ClassName = "test class 1",
          ClassDescription = "test class description 1"
        },
        new Class()
        {
          ClassId = 2,
          ClassName = "test class 2",
          ClassDescription = "test class description 2"
        },
        new Class()
        {
          ClassId = 3,
          ClassName = "test class 3",
          ClassDescription = "test class description 3"
        },
      };
    }

    [TearDown]
    public void CleanUp()
    {
      _classManager = null;
      _classList = null;
    }

    [Test]
    public void CreateClass_UnderNormalConditions_ReturnsNewlyCreatedClassId()
    {
      //Arrange
      var classToBeCreated = new Class()
      {
        ClassDescription = "test class description",
        ClassName = "test class name"
      };

      var mockRepo = Mock.Create<LunchAndLearnRepository<Class>>();
      Mock.Arrange(() => mockRepo.Create(classToBeCreated)).DoNothing();

      var classManager = new ClassManager();

      //Act
      var actual = classManager.Create(classToBeCreated);


      //Assert
      Assert.That(actual, Is.Not.EqualTo(0));
    }
  }
}
