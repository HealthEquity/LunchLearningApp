using LunchAndLearn.Management;
using LunchAndLearn.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
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
    private readonly IClassService _classService;

    public ClassController(IClassService classService)
    {
      _classService = classService;
    }

    // GET api/class
    [HttpGet]
    [Route("all")]
    [ResponseType(typeof(List<ClassDto>))]
    public IHttpActionResult GetAll()
    {
      List<ClassDto> allClasses;
      using (_classService)
      {
        allClasses = _classService.GetAll();
      }
      return this.Ok(allClasses);
    }

    [HttpGet]
    [Route("{id}")]
    [ResponseType(typeof(ClassDto))]
    public IHttpActionResult Get(int id)
    {
      ClassDto classToReturn;
      using (_classService)
      {
        classToReturn = _classService.Get(id);
      }
      return this.Ok(classToReturn);
    }

    [HttpPost]
    [Route("create")]
    [ResponseType(typeof(ClassDto))]
    public IHttpActionResult Post(ClassDto classToCreate)
    {
      using (_classService)
      {
        var response =_classService.Create(classToCreate);
        if (response != null)
        {
          return Created(new Uri(Request.RequestUri, $"{response.ClassId}"), response);
        }
        return InternalServerError();
      }
    }

    [HttpPut]
    [Route("update")]
    [ResponseType(typeof(ClassDto))]
    public IHttpActionResult Put(ClassDto classToBeUpdated)
    {
      using (_classService)
      {
        var response = _classService.Update(classToBeUpdated);
        return Ok(response);
      }
    }

    [HttpDelete]
    [Route("delete")]
    [ResponseType(typeof(OkResult))]
    public IHttpActionResult Delete(int id)
    {
      using (_classService)
      {
        _classService.Delete(id); 
      }
      return Ok();
    }

    protected override void Dispose(bool disposing)
    {
      _classService.Dispose();
      base.Dispose(disposing);
    }
  }
}