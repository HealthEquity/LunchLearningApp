using LunchAndLearn.Data;
using LunchAndLearn.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchAndLearn.Data.Interfaces;
using LunchAndLearn.Data.Repositories;
using LunchAndLearn.Management.Interfaces;
using LunchAndLearn.Model.DB_Models;
using LunchAndLearn.Model.DTOs;

namespace LunchAndLearn.Management
{
  public class ClassService : IClassService
  {
    private readonly IClassRepository _classRepository;

    public ClassService(IClassRepository classRepository)
    {
      _classRepository = classRepository;
    }

    public ClassDto Get(int id)
    {
      using (_classRepository)
      {
        var retrievedClass = _classRepository.Get(id);
        return retrievedClass.ConvertToClassDto();
      }
    }

    public List<ClassDto> GetAll()
    {
      using (_classRepository)
      {
        var classes = _classRepository.GetAll().ToList();
        return classes.Select(x => x.ConvertToClassDto()).ToList();
      }
    }

    public ClassDto Create(ClassDto entity)
    {
      using (_classRepository)
      {
        var entityToCreate = entity.ConvertToClassDbModel();

        _classRepository.Create(entityToCreate);
        _classRepository.SaveChanges();

        return entityToCreate.ConvertToClassDto();
      }
    }

    public ClassDto Update(ClassDto entity)
    {
      using (_classRepository)
      {
        var entityToUpdate = entity.ConvertToClassDbModel();

        _classRepository.Update(entityToUpdate);
        _classRepository.SaveChanges();

        return entityToUpdate.ConvertToClassDto();
      }
    }

    public void Delete(int id)
    {
      using (_classRepository)
      {
        _classRepository.Delete(id);
        _classRepository.SaveChanges(); 
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
          //Dispose of all repos used in this class here Example: _productRepository, _personRepository
          _classRepository.Dispose();
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
