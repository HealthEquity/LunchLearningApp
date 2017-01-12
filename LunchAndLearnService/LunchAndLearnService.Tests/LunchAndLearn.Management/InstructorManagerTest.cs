using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchAndLearn.Data.Interfaces;
using LunchAndLearn.Management;
using LunchAndLearn.Management.Interfaces;
using LunchAndLearn.Model;
using NUnit.Framework.Internal;
using NUnit.Framework;
using Telerik.JustMock;

namespace LunchAndLearnService.Tests.LunchAndLearn.Management
{
  [TestFixture]
  public class InstructorManagerTest
  {
    private List<Instructor> _instructorList;
    private InstructorManager _instructorManager;
    [SetUp]
    public void Init()
    {
      _instructorList = new List<Instructor>()
      {
        new Instructor()
        {
          InstructorId = 1,
          InstructorName = "test instructor 1",
          IsActive = true
        },
        new Instructor()
        {
          InstructorId = 2,
          InstructorName = "test instructor 2",
          IsActive = true
        },
        new Instructor()
        {
          InstructorId = 3,
          InstructorName = "test instructor 3",
          IsActive = false
        }
      };
    }

    [TearDown]
    public void CleanUp()
    {
      _instructorList = null;
      _instructorManager = null;
    }

    [Test]
    public void CreateInstructor_UnderNormalConditions_AddsInstructorToInstructorList()
    {
      //arrange
      var instructorToBeCreated = new Instructor()
      {
        InstructorName = "test instructor name",
        IsActive = true
      };

      var originalCountOfInstructors = _instructorList.Count;

      var mockInstructorRepo = Mock.Create<ILunchAndLearnRepository<Instructor>>();
      Mock.Arrange(() => mockInstructorRepo.Create(Arg.IsAny<Instructor>()))
        .DoInstead(() =>_instructorList.Add(instructorToBeCreated))
        .OccursOnce();

      _instructorManager = new InstructorManager(mockInstructorRepo);

      //act

      _instructorManager.Create(instructorToBeCreated);
      var actualCount = _instructorList.Count;

      //assert
      Mock.Assert(mockInstructorRepo);
      Assert.That(actualCount, Is.EqualTo(originalCountOfInstructors + 1));
    }
  }
}
