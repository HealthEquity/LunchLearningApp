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
  public class RatingHashService : IRatingHashService
  {
    private readonly IRatingHashRepository _ratingHashRepository;

    public RatingHashService(IRatingHashRepository ratingHashRepository)
    {
      _ratingHashRepository = ratingHashRepository;
    }

    public RatingHashDto Get(int id)
    {
      using (_ratingHashRepository)
      {
        return _ratingHashRepository.Get(id).ConvertToRatingHashDto();
      }
    }

    public List<RatingHashDto> GetAll()
    {
      using (_ratingHashRepository)
      {
        var ratingHashList = _ratingHashRepository.GetAll().ToList();
        return ratingHashList.Select(x => x.ConvertToRatingHashDto()).ToList();
      }
    }

    public RatingHashDto Create(RatingHashDto entity)
    {
      using (_ratingHashRepository)
      {
        var entityToCreate = entity.ConvertToRatingHashDbModel();

        _ratingHashRepository.Create(entityToCreate);
        _ratingHashRepository.SaveChanges();

        return entityToCreate.ConvertToRatingHashDto();
      }
    }

    public RatingHashDto Update(RatingHashDto entity)
    {
      using (_ratingHashRepository)
      {
        var entityToUpdate = entity.ConvertToRatingHashDbModel();

        _ratingHashRepository.Update(entityToUpdate);
        _ratingHashRepository.SaveChanges();

        return entityToUpdate.ConvertToRatingHashDto();
      }
    }

    public void Delete(int id)
    {
      using (_ratingHashRepository)
      {
        _ratingHashRepository.Delete(id);
        _ratingHashRepository.SaveChanges(); 
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
          _ratingHashRepository.Dispose();
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