using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using LunchAndLearn.Management;
using LunchAndLearn.Management.Interfaces;
using LunchAndLearn.Model;
using LunchAndLearn.Model.DB_Models;
using LunchAndLearn.Model.DTOs;

namespace LunchAndLearnService.Controllers
{
  [Authorize]
  [RoutePrefix("api/person")]
  public class PersonController : ApiController
  {
    private readonly IPersonService _personService;

    public PersonController(IPersonService personService)
    {
      _personService = personService;
    }

    [Route("all")]
    [HttpGet]
    [ResponseType(typeof(List<PersonDto>))]
    public IHttpActionResult GetAll()
    {
      List<PersonDto> people;
      using (_personService)
      {
        people = _personService.GetAll(); 
      }
      return Ok(people);
    }

    [Route("{id}")]
    [HttpGet]
    [ResponseType(typeof(PersonDto))]
    public IHttpActionResult Get(int id)
    {
      PersonDto person;
      using (_personService)
      {
        person = _personService.Get(id);
      }
      return Ok(person);
    }

    [HttpPost]
    [Route("create")]
    [ResponseType(typeof(PersonDto))]
    public IHttpActionResult Post(PersonDto person)
    {
      using (_personService)
      {
        var response = _personService.Create(person);
        return Created(new Uri(Request.RequestUri, $"{response.PersonId}"), response);
      }
    }

    [HttpPut]
    [Route("update")]
    [ResponseType(typeof(PersonDto))]
    public IHttpActionResult Put(PersonDto person)
    {
      using (_personService)
      {
        var response = _personService.Update(person);
        return Ok(response);
      }
    }

    [HttpDelete]
    [Route("delete")]
    [ResponseType(typeof(OkResult))]
    public IHttpActionResult Delete(int id)
    {
      using (_personService)
      {
        _personService.Delete(id); 
      }
      return Ok();
    }
  }
}
