using System.Collections.Generic;
using System.Linq;
using LunchAndLearn.Data;
using LunchAndLearn.Data.Interfaces;
using LunchAndLearn.Data.Repositories;
using LunchAndLearn.Management;
using LunchAndLearn.Model;
using LunchAndLearn.Model.DB_Models;
using LunchAndLearn.Model.DTOs;
using NUnit.Framework;
using Telerik.JustMock;
using Telerik.JustMock.Helpers;

namespace LunchAndLearnService.Tests.LunchAndLearn.Management
{
  [TestFixture]
  internal class ClassManagerTest
  {
    private List<ClassDto> _classList;
    private ClassManager _classManager;


    [SetUp]
    public void Init()
    {
      _classList = new List<ClassDto>()
      {
        new ClassDto()
        {
          ClassId = 1,
          ClassName = "test class 1",
          ClassDescription = "test class description 1"
        },
        new ClassDto()
        {
          ClassId = 2,
          ClassName = "test class 2",
          ClassDescription = "test class description 2"
        },
        new ClassDto()
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
    public void CreateClass_UnderNormalConditions_AddsClasstoClassList()
    {
      //Arrange
      var originalCountOfClasses = _classList.Count;
      var classToBeCreated = new ClassDto()
      {
        ClassDescription = "test class description",
        ClassName = "test class name"
      };

      var mockRepo = Mock.Create<IClassRepository>();
      Mock.Arrange(() => mockRepo.Create(Arg.IsAny<Class>()))
        .DoInstead(() => _classList.Add(classToBeCreated))
        .OccursOnce();

      _classManager = new ClassManager(mockRepo);

      //Act
      _classManager.Create(classToBeCreated);
      var actualCount = _classList.Count;


      //Assert
      Mock.Assert(mockRepo);
      Assert.That(actualCount, Is.EqualTo(originalCountOfClasses + 1));
    }
  }
}
