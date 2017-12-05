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
  [RoutePrefix("api/course")]
  public class CourseController : ApiController
  {
    private readonly ICourseService _courseService;

    public CourseController(ICourseService courseService)
    {
      _courseService = courseService;
    }

    // GET api/course
    [HttpGet]
    [Route("all")]
    [ResponseType(typeof(List<CourseDto>))]
    public IHttpActionResult GetAll()
    {
      List<CourseDto> allCourses;
      using (_courseService)
      {
        allCourses = _courseService.GetAll();
      }
      return this.Ok(allCourses);
    }

    [HttpGet]
    [Route("{id}")]
    [ResponseType(typeof(CourseDto))]
    public IHttpActionResult Get(int id)
    {
      CourseDto courseToReturn;
      using (_courseService)
      {
        courseToReturn = _courseService.Get(id);
      }
      return this.Ok(courseToReturn);
    }

    [HttpPost]
    [Route("create")]
    [ResponseType(typeof(CourseDto))]
    public IHttpActionResult Post(CourseDto courseToCreate)
    {
      using (_courseService)
      {
        var response = _courseService.Create(courseToCreate);
        if (response != null)
        {
          return Created(new Uri(Request.RequestUri, $"{response.CourseId}"), response);
        }
        return InternalServerError();
      }
    }

    [HttpPut]
    [Route("update")]
    [ResponseType(typeof(CourseDto))]
    public IHttpActionResult Put(CourseDto courseToBeUpdated)
    {
      using (_courseService)
      {
        var response = _courseService.Update(courseToBeUpdated);
        return Ok(response);
      }
    }

    [HttpDelete]
    [Route("delete")]
    [ResponseType(typeof(OkResult))]
    public IHttpActionResult Delete(int id)
    {
      using (_courseService)
      {
        _courseService.Delete(id); 
      }
      return Ok();
    }
  }
}