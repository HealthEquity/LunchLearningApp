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
  public class InstructorService : IInstructorService
  {
    private readonly IUnitOfWork _unitOfWork;

    public InstructorService(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    public InstructorDto Get(int instructorId)
    {
      return _unitOfWork.InstructorRepository.GetById(instructorId)?.ConvertToInstructorDto();
    }

    public List<InstructorDto> GetAll()
    {
      return _unitOfWork.InstructorRepository.Get().Select(x => x.ConvertToInstructorDto()).ToList();
    }

    public InstructorDto Create(InstructorDto instructorDto)
    {
      var instructorDbModelToCreate = instructorDto.ConvertToInstructorDbModel();

      _unitOfWork.InstructorRepository.Insert(instructorDbModelToCreate);
      _unitOfWork.Save();

      return instructorDbModelToCreate.ConvertToInstructorDto();
    }

    public InstructorDto Update(InstructorDto instructorDto)
    {
      if (!_unitOfWork.InstructorRepository.Exists(x => x.InstructorId == instructorDto.InstructorId)) return null;

      var entityToUpdate = instructorDto.ConvertToInstructorDbModel();

      _unitOfWork.InstructorRepository.Update(entityToUpdate);

      _unitOfWork.Save();

      return entityToUpdate.ConvertToInstructorDto();
    }

    public void Delete(int instructorId)
    {
      if (!_unitOfWork.InstructorRepository.Exists(x => x.InstructorId == instructorId)) return;

      _unitOfWork.InstructorRepository.Delete(instructorId);

      _unitOfWork.Save();
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