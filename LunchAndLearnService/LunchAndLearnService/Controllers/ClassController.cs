using LunchAndLearn.Management;
using LunchAndLearn.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;

namespace LunchAndLearnService.Controllers
{
  [RoutePrefix("api/class")]
  public class ClassController : ApiController
  {
    readonly ILunchAndLearnManager _lunchAndLearnManager;

    public ClassController(ILunchAndLearnManager lunchAndLearnManager)
    {
      _lunchAndLearnManager = lunchAndLearnManager;
    }

    public ClassController()
    {
      _lunchAndLearnManager = new LunchAndLearnManager();
    }

    // GET api/class
    [HttpGet]
    [Route("all")]
    [ResponseType(typeof(List<Class>))]
    public IHttpActionResult GetAll()
    {
      var classes = _lunchAndLearnManager.ClassManager.GetAll();
      return this.Ok(classes);
    }

    [HttpGet]
    [Route("{id}")]
    [ResponseType(typeof(Class))]
    public IHttpActionResult Get(int id)
    {
      var dbClass = _lunchAndLearnManager.ClassManager.Get(id);
      return this.Ok(dbClass);
    }

    [HttpPost]
    [Route("create")]
    [ResponseType(typeof(OkResult))]
    public IHttpActionResult Post(Class classToCreate)
    {
      _lunchAndLearnManager.ClassManager.Create(classToCreate);
      return Ok();
    }

    [HttpPut]
    [Route("update")]
    [ResponseType(typeof(OkResult))]
    public IHttpActionResult Put(Class classToBeUpdated)
    {
      _lunchAndLearnManager.ClassManager.Update(classToBeUpdated);
      return Ok();
    }

    [HttpDelete]
    [Route("delete")]
    [ResponseType(typeof(OkResult))]
    public IHttpActionResult Delete(int id)
    {
      _lunchAndLearnManager.ClassManager.Delete(id);
      return Ok();
    }
  }
}