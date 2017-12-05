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
  public class CourseService : ICourseService
  {
    private readonly ICourseRepository _courseRepository;

    public CourseService(ICourseRepository courseRepository)
    {
      _courseRepository = courseRepository;
    }

    public CourseDto Get(int id)
    {
      using (_courseRepository)
      {
        var retrievedClass = _courseRepository.Get(id);
        return retrievedClass.ConvertToCourseDto();
      }
    }

    public List<CourseDto> GetAll()
    {
      using (_courseRepository)
      {
        var Classs = _courseRepository.GetAll().ToList();
        return Classs.Select(x => x.ConvertToCourseDto()).ToList();
      }
    }

    public CourseDto Create(CourseDto entity)
    {
      using (_courseRepository)
      {
        var entityToCreate = entity.ConvertToCourseDbModel();

        _courseRepository.Create(entityToCreate);
        _courseRepository.SaveChanges();

        return entityToCreate.ConvertToCourseDto();
      }
    }

    public CourseDto Update(CourseDto entity)
    {
      using (_courseRepository)
      {
        var entityToUpdate = entity.ConvertToCourseDbModel();

        _courseRepository.Update(entityToUpdate);
        _courseRepository.SaveChanges();

        return entityToUpdate.ConvertToCourseDto();
      }
    }

    public void Delete(int id)
    {
      using (_courseRepository)
      {
        _courseRepository.Delete(id);
        _courseRepository.SaveChanges(); 
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
          _courseRepository.Dispose();
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
