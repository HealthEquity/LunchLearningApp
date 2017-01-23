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
    private readonly IUnitOfWork _unitOfWork;

    public ClassService(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    public ClassDto Get(int id)
    {
      return _unitOfWork.ClassRepository.GetById(id)?.ConvertToClassDto();
    }

    public List<ClassDto> GetAll()
    {
      return _unitOfWork.ClassRepository.Get().Select(x => x.ConvertToClassDto()).ToList();
    }

    public ClassDto Create(ClassDto entity)
    {
      var entityToCreate = entity.ConvertToClassDbModel();

      _unitOfWork.ClassRepository.Insert(entityToCreate);
      _unitOfWork.Commit();

      return entityToCreate.ConvertToClassDto();
    }

    public ClassDto Update(ClassDto entity)
    {
      if (!_unitOfWork.ClassRepository.Exists(x => x.ClassId == entity.ClassId)) return null;

      var entityToUpdate = entity.ConvertToClassDbModel();

      _unitOfWork.ClassRepository.Update(entityToUpdate);
      _unitOfWork.Commit();

      return entityToUpdate.ConvertToClassDto();
    }

    public void Delete(int id)
    {
      if (!_unitOfWork.ClassRepository.Exists(x => x.ClassId == id)) return;

      _unitOfWork.ClassRepository.Delete(id);
      _unitOfWork.Commit();
    }

    #region Disposal
    private bool _disposed = false;

    protected virtual void Dispose(bool disposing)
    {
      if (!this._disposed)
      {
        if (disposing)
        {
          _unitOfWork.Dispose();
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
