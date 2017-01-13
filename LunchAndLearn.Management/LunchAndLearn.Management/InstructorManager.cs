using System;
using LunchAndLearn.Data;
using LunchAndLearn.Model;
using System.Collections.Generic;
using System.Linq;
using LunchAndLearn.Data.Interfaces;
using LunchAndLearn.Data.Repositories;
using LunchAndLearn.Management.Interfaces;
using LunchAndLearn.Model.DB_Models;

namespace LunchAndLearn.Management
{
  public class InstructorManager : IManagerClass<Instructor>
  {
    private readonly IInstructorRepository _instructorRepository;

    public InstructorManager(IInstructorRepository instructorRepository)
    {
      _instructorRepository = instructorRepository;
    }

    public Instructor Get(int id)
    {
      using (_instructorRepository)
      {
        return _instructorRepository.Get(id); 
      }
    }

    public List<Instructor> GetAll()
    {
      using (_instructorRepository)
      {
        return _instructorRepository.GetAll().ToList(); 
      }
    }

    public int Create(Instructor entity)
    {
      using (_instructorRepository)
      {
        _instructorRepository.Create(entity);
        _instructorRepository.SaveChanges();
        return entity.InstructorId; 
      }
    }

    public void Update(Instructor entity)
    {
      using (_instructorRepository)
      {
        _instructorRepository.Update(entity);
        _instructorRepository.SaveChanges(); 
      }
    }

    public void Delete(int id)
    {
      using (_instructorRepository)
      {
        _instructorRepository.Delete(id);
        _instructorRepository.SaveChanges(); 
      }
    }

    #region Disposal
    private bool _disposed = false;

    protected virtual void Dispose(bool disposing)
    {
      if (!this._disposed)
      {
        if (disposing)
        {
          _instructorRepository.Dispose();
        }
      }
      this._disposed = true;
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }
    #endregion
  }
}