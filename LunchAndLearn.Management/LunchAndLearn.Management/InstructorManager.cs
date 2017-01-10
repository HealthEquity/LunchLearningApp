using System;
using LunchAndLearn.Data;
using LunchAndLearn.Model;
using System.Collections.Generic;
using System.Linq;

namespace LunchAndLearn.Management
{
  public class InstructorManager : BaseManager, ILunchAndLearnRepository<Instructor, int>
  {
    public InstructorManager() { }

    public InstructorManager(LunchAndLearnContext context)
        : base(context)
    {
    }


    // CRUD

    /// <summary>Create a new instructor</summary>
    public virtual Instructor Create(Instructor instructor)
    {
      ValidateModel(instructor);

      AddEntity(instructor);

      return instructor;
    }


    /// <summary>Get an instructor</summary>
    public virtual Instructor Get(int id)
    {
      return Context.Instructors.FirstOrDefault(al => al.InstructorId == id);
    }

    public virtual List<Instructor> GetAll()
    {
      return Context.Instructors.ToList();
    }
    /// <summary>Update existing instructor</summary>
    public virtual void Update(Instructor instructor)
    {
      ValidateModel(instructor);
      UpdateEntity(instructor);
    }

    /// <summary>Delete instructor</summary>
    public virtual void Delete(int id)
    {
      DeleteEntity(new Instructor());
    }


    // Getters


  }
}