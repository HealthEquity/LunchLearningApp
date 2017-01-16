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
  internal class ClassServiceTest
  {
    private List<Class> _dbClassList;
    private ClassService _classService;


    [SetUp]
    public void Init()
    {
      _dbClassList = new List<Class>()
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
      _classService = null;
      _dbClassList = null;
    }

    [Test]
    public void CreateClass_UnderNormalConditions_AddsClasstoClassList()
    {
      //Arrange
      var originalCountOfClasses = _dbClassList.Count;
      var classToBeCreated = new Class()
      {
        ClassDescription = "test class description",
        ClassName = "test class name"
      };

      var mockRepo = Mock.Create<IClassRepository>();
      Mock.Arrange(() => mockRepo.Create(Arg.IsAny<Class>()))
        .DoInstead(() => _dbClassList.Add(classToBeCreated))
        .OccursOnce();

      _classService = new ClassService(mockRepo);

      //Act
      _classService.Create(classToBeCreated.ConvertToClassDto());
      var actualCount = _dbClassList.Count;


      //Assert
      Mock.Assert(mockRepo);
      Assert.That(actualCount, Is.EqualTo(originalCountOfClasses + 1));
    }

    [Test]
    public void GetClassById_WhereIdExists_ReturnsNonNullClassDto([Values(1,2,3)]int id)
    {
      //arrange
      var mockClassRepo = Mock.Create<IClassRepository>();
      Mock.Arrange(() => mockClassRepo.Get(Arg.IsAny<int>()))
        .Returns(_dbClassList.FirstOrDefault(x => x.ClassId == id))
        .OccursOnce();

      _classService = new ClassService(mockClassRepo);

      //act
      var actual = _classService.Get(id);

      //assert
      Mock.Assert(mockClassRepo);
      Assert.IsNotNull(actual);
    }

    [Test]
    public void GetAll_UnderNormalConditions_ReturnsListOfClassDtos()
    {
      //arrange
      var mockClassRepo = Mock.Create<IClassRepository>();
      Mock.Arrange(() => mockClassRepo.GetAll()).Returns(_dbClassList.AsQueryable).OccursOnce();

      _classService = new ClassService(mockClassRepo);
      //act
      var actual = _classService.GetAll();

      //assert
      Mock.Assert(mockClassRepo);
      Assert.IsNotNull(actual);
      Assert.That(actual.Count, Is.EqualTo(_dbClassList.Count));
    }

    [Test]
    public void UpdateClass_WhereClassExists_DoesntThrowException([Values(1,2,3)]int id)
    {
      //arrange
      const string update = "UPDATED";
      var classToBeUpdated = _dbClassList.FirstOrDefault(x => x.ClassId == id);
      var mockClassRepo = Mock.Create<IClassRepository>();
      Mock.Arrange(() => mockClassRepo.Update(Arg.IsAny<Class>()))
        .DoInstead(() =>
        {
          var updatedClass = _dbClassList.FirstOrDefault(x => x.ClassId == id);
          if (updatedClass != null)
            updatedClass.ClassName = update;
        })
        .OccursOnce();

      _classService = new ClassService(mockClassRepo);
      //act
      _classService.Update(new ClassDto());

      //assert
      Mock.Assert(mockClassRepo);
      Assert.IsNotNull(classToBeUpdated);
      Assert.That(classToBeUpdated.ClassName, Is.EqualTo(update));
    }

    [Test]
    public void DeleteClass_WhereClassExists_DoesntThrowException([Values(1,2,3)]int id)
    {
      //arrange
      var classToBeDeleted = _dbClassList.FirstOrDefault(x => x.ClassId == id);
      var originalCountOfClasses = _dbClassList.Count;
      var mockClassRepo = Mock.Create<IClassRepository>();
      Mock.Arrange(() => mockClassRepo.Delete(id)).DoInstead(() => _dbClassList.RemoveAt(id - 1)).OccursOnce();

      _classService = new ClassService(mockClassRepo);

      //act
      _classService.Delete(id);
      var actualCountOfClasses = _dbClassList.Count;
      var deletedClass = _dbClassList.FirstOrDefault(x => x.ClassId == id);

      //assert
      Mock.Assert(mockClassRepo);
      Assert.That(classToBeDeleted, Is.Not.Null);
      Assert.That(actualCountOfClasses, Is.LessThan(originalCountOfClasses));
      Assert.That(deletedClass, Is.Null);
    }
  }
}
