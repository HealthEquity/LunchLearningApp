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
using LunchAndLearn.Management.Interfaces;

namespace LunchAndLearnService.Controllers
{
  [RoutePrefix("api/class")]
  public class ClassController : ApiController
  {
    private readonly IManagerClass<Class> _classManager;

    public ClassController(IManagerClass<Class> classManager)
    {
      _classManager = classManager;
    }

    // GET api/class
    [HttpGet]
    [Route("all")]
    [ResponseType(typeof(List<Class>))]
    public IHttpActionResult GetAll()
    {
      List<Class> allClasses;
      using (_classManager)
      {
        allClasses = _classManager.GetAll();
      }
      return this.Ok(allClasses);
    }

    [HttpGet]
    [Route("{id}")]
    [ResponseType(typeof(Class))]
    public IHttpActionResult Get(int id)
    {
      Class classToReturn;
      using (_classManager)
      {
        classToReturn = _classManager.Get(id);
      }
      return this.Ok(classToReturn);
    }

    [HttpPost]
    [Route("create")]
    [ResponseType(typeof(OkResult))]
    public IHttpActionResult Post(Class classToCreate)
    {
      using (_classManager)
      {
        _classManager.Create(classToCreate);
      }
      return Ok();
    }

    [HttpPut]
    [Route("update")]
    [ResponseType(typeof(OkResult))]
    public IHttpActionResult Put(Class classToBeUpdated)
    {
      using (_classManager)
      {
        _classManager.Update(classToBeUpdated);
      }
      return Ok();
    }

    [HttpDelete]
    [Route("delete")]
    [ResponseType(typeof(OkResult))]
    public IHttpActionResult Delete(int id)
    {
      using (_classManager)
      {
        _classManager.Delete(id); 
      }
      return Ok();
    }
  }
}