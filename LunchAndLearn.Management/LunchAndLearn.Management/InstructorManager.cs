using System;
using LunchAndLearn.Data;
using LunchAndLearn.Model;
using System.Collections.Generic;
using System.Linq;
using LunchAndLearn.Data.Interfaces;
using LunchAndLearn.Data.Repositories;
using LunchAndLearn.Management.Interfaces;
using LunchAndLearn.Model.DB_Models;
using LunchAndLearn.Model.DTOs;

namespace LunchAndLearn.Management
{
  public class InstructorManager : IManagerClass<InstructorDto>
  {
    private readonly IInstructorRepository _instructorRepository;

    public InstructorManager(IInstructorRepository instructorRepository)
    {
      _instructorRepository = instructorRepository;
    }

    public InstructorDto Get(int id)
    {
      using (_instructorRepository)
      {
        return _instructorRepository.Get(id).ConvertToInstructorDto(); 
      }
    }

    public List<InstructorDto> GetAll()
    {
      using (_instructorRepository)
      {
        var instructorList = _instructorRepository.GetAll().ToList();
        return instructorList.Select(x => x.ConvertToInstructorDto()).ToList();
      }
    }

    public int Create(InstructorDto entity)
    {
      using (_instructorRepository)
      {
        var entityToCreate = entity.ConvertToInstructorDbModel();
        _instructorRepository.Create(entityToCreate);
        _instructorRepository.SaveChanges();
        return entityToCreate.InstructorId; 
      }
    }

    public void Update(InstructorDto entity)
    {
      using (_instructorRepository)
      {
        var entityToUpdate = entity.ConvertToInstructorDbModel();
        _instructorRepository.Update(entityToUpdate);
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