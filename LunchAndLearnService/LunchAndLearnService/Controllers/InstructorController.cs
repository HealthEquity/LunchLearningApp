using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using LunchAndLearn.Model;
using LunchAndLearn.Management;

namespace LunchAndLearnService.Controllers
{
  [RoutePrefix("api/instructor")]
  public class InstructorController : ApiController
  {
    readonly ILunchAndLearnManager _lunchAndLearnManager;

    public InstructorController(ILunchAndLearnManager lunchAndLearnManager)
    {
      _lunchAndLearnManager = lunchAndLearnManager;
    }

    public InstructorController()
    {
      _lunchAndLearnManager = new LunchAndLearnManager();
    }

    [HttpGet]
    [Route("all")]
    [ResponseType(typeof(List<Instructor>))]
    public IHttpActionResult GetAll()
    {
      var response = _lunchAndLearnManager.InstructorManager.GetAll();
      return Ok(response);
    }

    [HttpGet]
    [Route("{id}")]
    [ResponseType(typeof(Instructor))]
    public IHttpActionResult Get(int id)
    {
      var response = _lunchAndLearnManager.InstructorManager.Get(id);
      return Ok(response);
    }

    [HttpPut]
    [Route("update")]
    [ResponseType(typeof(OkResult))]
    public IHttpActionResult Put(Instructor instructor)
    {
      _lunchAndLearnManager.InstructorManager.Update(instructor);
      return Ok();
    }

    [HttpDelete]
    [Route("delete")]
    [ResponseType(typeof(OkResult))]
    public IHttpActionResult Delete(int id)
    {
      _lunchAndLearnManager.InstructorManager.Delete(id);
      return Ok();
    }

    [HttpPost]
    [Route("create")]
    [ResponseType(typeof(OkResult))]
    public IHttpActionResult Post(Instructor instructor)
    {
      _lunchAndLearnManager.InstructorManager.Create(instructor);
      return Ok();
    }
  }
}