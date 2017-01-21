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
    readonly IInstructorService _instructorService;

    public InstructorController(IInstructorService instructorService)
    {
      _instructorService = instructorService;
    }

    [HttpGet]
    [Route("all")]
    [ResponseType(typeof(List<InstructorDto>))]
    public IHttpActionResult GetAll()
    {
      List<InstructorDto> instructors;
      using (_instructorService)
      {
        instructors = _instructorService.GetAll(); 
      }
      return Ok(instructors);
    }

    [HttpGet]
    [Route("{id}")]
    [ResponseType(typeof(InstructorDto))]
    public IHttpActionResult Get(int id)
    {
      InstructorDto instructor;
      using (_instructorService)
      {
        instructor = _instructorService.Get(id); 
      }
      return Ok(instructor);
    }

    [HttpPost]
    [Route("create")]
    [ResponseType(typeof(InstructorDto))]
    public IHttpActionResult Post(InstructorDto instructor)
    {
      using (_instructorService)
      {
        var response = _instructorService.Create(instructor);
        return Created(new Uri(Request.RequestUri, $"{response.InstructorId}"), response);
      }
    }

    [HttpPut]
    [Route("update")]
    [ResponseType(typeof(InstructorDto))]
    public IHttpActionResult Put(InstructorDto instructor)
    {
      using (_instructorService)
      {
        var response = _instructorService.Update(instructor); 
        return Ok(response);
      }
    }

    [HttpDelete]
    [Route("delete")]
    [ResponseType(typeof(OkResult))]
    public IHttpActionResult Delete(int id)
    {
      using (_instructorService)
      {
        _instructorService.Delete(id); 
      }
      return Ok();
    }

    protected override void Dispose(bool disposing)
    {
      _instructorService.Dispose();
      base.Dispose(disposing);
    }
  }
}