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
  [Authorize]
  [RoutePrefix("api/coursesession")]
  public class CourseSessionController : ApiController
  {
    private readonly ICourseSessionService _courseSessionService;

    public CourseSessionController(ICourseSessionService courseSessionService)
    {
      _courseSessionService = courseSessionService;
    }

    // GET api/Classsession
    [HttpGet]
    [Route("all")]
    [ResponseType(typeof(List<CourseSessionDto>))]
    public IHttpActionResult GetAll()
    {
      List<CourseSessionDto> allClassSessions;
      using (_courseSessionService)
      {
        allClassSessions = _courseSessionService.GetAll();
      }
      return this.Ok(allClassSessions);
    }

    [HttpGet]
    [Route("{id}")]
    [ResponseType(typeof(CourseSessionDto))]
    public IHttpActionResult Get(int id)
    {
      CourseSessionDto courseSessionToReturn;
      using (_courseSessionService)
      {
        courseSessionToReturn = _courseSessionService.Get(id);
      }
      return this.Ok(courseSessionToReturn);
    }

    [HttpPost]
    [Route("create")]
    [ResponseType(typeof(CourseSessionDto))]
    public IHttpActionResult Post(CourseSessionDto ClassSessionToCreate)
    {
      using (_courseSessionService)
      {
        var response = _courseSessionService.Create(ClassSessionToCreate);
        if (response != null)
        {
          return Created(new Uri(Request.RequestUri, $"{response.CourseSessionId}"), response);
        }
        return InternalServerError();
      }
    }

    [HttpPut]
    [Route("update")]
    [ResponseType(typeof(CourseSessionDto))]
    public IHttpActionResult Put(CourseSessionDto courseSessionToBeUpdated)
    {
      using (_courseSessionService)
      {
        var response = _courseSessionService.Update(courseSessionToBeUpdated);
        return Ok(response);
      }
    }

    [HttpDelete]
    [Route("delete")]
    [ResponseType(typeof(OkResult))]
    public IHttpActionResult Delete(int id)
    {
      using (_courseSessionService)
      {
        _courseSessionService.Delete(id); 
      }
      return Ok();
    }
  }
}