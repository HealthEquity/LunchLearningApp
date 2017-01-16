using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using LunchAndLearn.Model;
using LunchAndLearn.Management;
using LunchAndLearn.Management.Interfaces;
using LunchAndLearn.Model.DB_Models;
using LunchAndLearn.Model.DTOs;

namespace LunchAndLearnService.Controllers
{
  [RoutePrefix("api/instructor")]
  public class InstructorController : ApiController
  {
    readonly IManagerClass<InstructorDto> _instructorManager;

    public InstructorController(IManagerClass<InstructorDto> instructorManager)
    {
      _instructorManager = instructorManager;
    }

    [HttpGet]
    [Route("all")]
    [ResponseType(typeof(List<InstructorDto>))]
    public IHttpActionResult GetAll()
    {
      List<InstructorDto> instructors;
      using (_instructorManager)
      {
        instructors = _instructorManager.GetAll(); 
      }
      return Ok(instructors);
    }

    [HttpGet]
    [Route("{id}")]
    [ResponseType(typeof(InstructorDto))]
    public IHttpActionResult Get(int id)
    {
      InstructorDto instructor;
      using (_instructorManager)
      {
        instructor = _instructorManager.Get(id); 
      }
      return Ok(instructor);
    }

    [HttpPut]
    [Route("update")]
    [ResponseType(typeof(OkResult))]
    public IHttpActionResult Put(InstructorDto instructor)
    {
      using (_instructorManager)
      {
        _instructorManager.Update(instructor); 
      }
      return Ok();
    }

    [HttpDelete]
    [Route("delete")]
    [ResponseType(typeof(OkResult))]
    public IHttpActionResult Delete(int id)
    {
      using (_instructorManager)
      {
        _instructorManager.Delete(id); 
      }
      return Ok();
    }

    [HttpPost]
    [Route("create")]
    [ResponseType(typeof(OkResult))]
    public IHttpActionResult Post(InstructorDto instructor)
    {
      using (_instructorManager)
      {
        _instructorManager.Create(instructor); 
      }
      return Ok();
    }
  }
}