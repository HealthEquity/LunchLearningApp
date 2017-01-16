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
using LunchAndLearn.Model.DB_Models;
using LunchAndLearn.Model.DTOs;

namespace LunchAndLearnService.Controllers
{
  [RoutePrefix("api/class")]
  public class ClassController : ApiController
  {
    private readonly IManagerClass<ClassDto> _classManager;

    public ClassController(IManagerClass<ClassDto> classManager)
    {
      _classManager = classManager;
    }

    // GET api/class
    [HttpGet]
    [Route("all")]
    [ResponseType(typeof(List<ClassDto>))]
    public IHttpActionResult GetAll()
    {
      List<ClassDto> allClasses;
      using (_classManager)
      {
        allClasses = _classManager.GetAll();
      }
      return this.Ok(allClasses);
    }

    [HttpGet]
    [Route("{id}")]
    [ResponseType(typeof(ClassDto))]
    public IHttpActionResult Get(int id)
    {
      ClassDto classToReturn;
      using (_classManager)
      {
        classToReturn = _classManager.Get(id);
      }
      return this.Ok(classToReturn);
    }

    [HttpPost]
    [Route("create")]
    [ResponseType(typeof(OkResult))]
    public IHttpActionResult Post(ClassDto classToCreate)
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
    public IHttpActionResult Put(ClassDto classToBeUpdated)
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