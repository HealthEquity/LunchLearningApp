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
  public class PersonService : IPersonService
  {
    private readonly IPersonRepository _personRepository;

    public PersonService(IPersonRepository personRepository)
    {
      _personRepository = personRepository;
    }

    public PersonDto Get(int id)
    {
      using (_personRepository)
      {
        var retrievedPerson = _personRepository.Get(id);
        return retrievedPerson.ConvertToPersonDto();
      }
    }

    public List<PersonDto> GetAll()
    {
      using (_personRepository)
      {
        var people = _personRepository.GetAll().ToList();
        return people.Select(x => x.ConvertToPersonDto()).ToList();
      }
    }

    public PersonDto Create(PersonDto entity)
    {
      using (_personRepository)
      {
        var entityToCreate = entity.ConvertToPersonDbModel();

        _personRepository.Create(entityToCreate);
        _personRepository.SaveChanges();

        return entityToCreate.ConvertToPersonDto();
      }
    }

    public PersonDto Update(PersonDto entity)
    {
      using (_personRepository)
      {
        var entityToUpdate = entity.ConvertToPersonDbModel();

        _personRepository.Update(entityToUpdate);
        _personRepository.SaveChanges();

        return entityToUpdate.ConvertToPersonDto();
      }
    }

    public void Delete(int id)
    {
      using (_personRepository)
      {
        _personRepository.Delete(id);
        _personRepository.SaveChanges(); 
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
          _personRepository.Dispose();
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
