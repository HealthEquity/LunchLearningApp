using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using LunchAndLearn.Model;
using LunchAndLearn.Management;
using LunchAndLearn.Management.Interfaces;

namespace LunchAndLearnService.Controllers
{
  [RoutePrefix("api/instructor")]
  public class InstructorController : ApiController
  {
    readonly IManagerClass<Instructor> _instructorManager;

    public InstructorController(IManagerClass<Instructor> instructorManager)
    {
      _instructorManager = instructorManager;
    }

    public InstructorController()
    {
      _instructorManager = new InstructorManager();
    }

    [HttpGet]
    [Route("all")]
    [ResponseType(typeof(List<Instructor>))]
    public IHttpActionResult GetAll()
    {
      List<Instructor> instructors;
      using (_instructorManager)
      {
        instructors = _instructorManager.GetAll(); 
      }
      return Ok(instructors);
    }

    [HttpGet]
    [Route("{id}")]
    [ResponseType(typeof(Instructor))]
    public IHttpActionResult Get(int id)
    {
      Instructor instructor;
      using (_instructorManager)
      {
        instructor = _instructorManager.Get(id); 
      }
      return Ok(instructor);
    }

    [HttpPut]
    [Route("update")]
    [ResponseType(typeof(OkResult))]
    public IHttpActionResult Put(Instructor instructor)
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
    public IHttpActionResult Post(Instructor instructor)
    {
      using (_instructorManager)
      {
        _instructorManager.Create(instructor); 
      }
      return Ok();
    }
  }
}