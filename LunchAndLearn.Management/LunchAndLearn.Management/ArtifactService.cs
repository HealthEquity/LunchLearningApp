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
  public class ArtifactService : IArtifactService
  {
    private readonly IArtifactRepository _artifactRepository;

    public ArtifactService(IArtifactRepository artifactRepository)
    {
      _artifactRepository = artifactRepository;
    }

    public ArtifactDto Get(int id)
    {
      using (_artifactRepository)
      {
        var retrievedArtifact = _artifactRepository.Get(id);
        return retrievedArtifact.ConvertToArtifactDto();
      }
    }

    public List<ArtifactDto> GetAll()
    {
      using (_artifactRepository)
      {
        var artifacts = _artifactRepository.GetAll().ToList();
        return artifacts.Select(x => x.ConvertToArtifactDto()).ToList();
      }
    }

    public ArtifactDto Create(ArtifactDto entity)
    {
      using (_artifactRepository)
      {
        var entityToCreate = entity.ConvertToArtifactDbModel();

        _artifactRepository.Create(entityToCreate);
        _artifactRepository.SaveChanges();

        return entityToCreate.ConvertToArtifactDto();
      }
    }

    public ArtifactDto Update(ArtifactDto entity)
    {
      using (_artifactRepository)
      {
        var entityToUpdate = entity.ConvertToArtifactDbModel();

        _artifactRepository.Update(entityToUpdate);
        _artifactRepository.SaveChanges();

        return entityToUpdate.ConvertToArtifactDto();
      }
    }

    public void Delete(int id)
    {
      using (_artifactRepository)
      {
        _artifactRepository.Delete(id);
        _artifactRepository.SaveChanges(); 
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
          //Dispose of all repos used in this Class here Example: _productRepository, _personRepository
          _artifactRepository.Dispose();
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
