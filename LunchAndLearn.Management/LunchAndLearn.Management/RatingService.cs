using LunchAndLearn.Data;
using LunchAndLearn.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using LunchAndLearn.Data.Interfaces;
using LunchAndLearn.Data.Repositories;
using LunchAndLearn.Management.Interfaces;
using LunchAndLearn.Model.DB_Models;
using LunchAndLearn.Model.DTOs;

namespace LunchAndLearn.Management
{
  public class RatingService : IRatingService
  {
    private readonly IUnitOfWork _unitOfWork;

    public RatingService(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    public RatingDto Get(int ratingId)
    {
      return _unitOfWork.RatingRepository.GetById(ratingId)?.ConvertToRatingDto();
    }

    public List<RatingDto> GetAll()
    {
      return _unitOfWork.RatingRepository.Get().Select(x => x.ConvertToRatingDto()).ToList();
    }

    public RatingDto Create(RatingDto ratingDto)
    {
      var ratingDbModelToCreate = ratingDto.ConvertToRatingDbModel();

      _unitOfWork.RatingRepository.Insert(ratingDbModelToCreate);
      _unitOfWork.Save();

      return ratingDbModelToCreate.ConvertToRatingDto();
    }

    public RatingDto Update(RatingDto ratingDto)
    {
      if (!_unitOfWork.RatingRepository.Exists(x => x.RatingId == ratingDto.RatingId)) return null;

      var ratingDbModelToUpdate = ratingDto.ConvertToRatingDbModel();

      _unitOfWork.RatingRepository.Update(ratingDbModelToUpdate);
      _unitOfWork.Save();

      return ratingDbModelToUpdate.ConvertToRatingDto();
    }

    public void Delete(int ratingId)
    {
      if (!_unitOfWork.RatingRepository.Exists(x => x.RatingId == ratingId)) return;

      _unitOfWork.RatingRepository.Delete(ratingId);
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