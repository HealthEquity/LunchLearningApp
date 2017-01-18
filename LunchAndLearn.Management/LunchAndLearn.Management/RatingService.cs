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
    private readonly IRatingRepository _ratingRepository;

    public RatingService(IRatingRepository ratingRepository)
    {
      _ratingRepository = ratingRepository;
    }

    public RatingDto Get(int id)
    {
      using (_ratingRepository)
      {
        return _ratingRepository.Get(id).ConvertToRatingDto();
      }
    }

    public List<RatingDto> GetAll()
    {
      using (_ratingRepository)
      {
        var ratingList =_ratingRepository.GetAll().ToList();
        return ratingList.Select(x => x.ConvertToRatingDto()).ToList();
      }
    }

    public RatingDto Create(RatingDto entity)
    {
      using (_ratingRepository)
      {
        var entityToCreate = entity.ConvertToRatingDbModel();

        _ratingRepository.Create(entityToCreate);
        _ratingRepository.SaveChanges();

        return entityToCreate.ConvertToRatingDto();
      }
    }

    public RatingDto Update(RatingDto entity)
    {
      using (_ratingRepository)
      {
        var entityToUpdate = entity.ConvertToRatingDbModel();

        _ratingRepository.Update(entityToUpdate);
        _ratingRepository.SaveChanges();

        return entityToUpdate.ConvertToRatingDto();
      }
    }

    public void Delete(int id)
    {
      using (_ratingRepository)
      {
        _ratingRepository.Delete(id);
        _ratingRepository.SaveChanges(); 
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
          _ratingRepository.Dispose();
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