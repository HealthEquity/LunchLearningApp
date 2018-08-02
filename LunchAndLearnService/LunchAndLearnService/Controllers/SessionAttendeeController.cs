using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using LunchAndLearn.Management.Interfaces;
using LunchAndLearn.Model.DTOs;

namespace LunchAndLearnService.Controllers
{
  [Authorize]
  [RoutePrefix("api/sessionattendee")]
  public class SessionAttendeeController : ApiController
  {
    private readonly ISessionAttendeeService _sessionAttendeeService;

    public SessionAttendeeController(ISessionAttendeeService sessionAttendeeService)
    {
      _sessionAttendeeService = sessionAttendeeService;
    }

    [HttpGet]
    [Route("all")]
    [ResponseType(typeof(List<SessionAttendeeDto>))]
    public IHttpActionResult GetAll()
    {
      List<SessionAttendeeDto> sessionAttendees;
      using (_sessionAttendeeService)
      {
        sessionAttendees = _sessionAttendeeService.GetAll(); 
      }
      return Ok(sessionAttendees);
    }

    [HttpGet]
    [Route("{id}")]
    [ResponseType(typeof(SessionAttendeeDto))]
    public IHttpActionResult Get(int id)
    {
      SessionAttendeeDto sessionAttendee;
      using (_sessionAttendeeService)
      {
        sessionAttendee = _sessionAttendeeService.Get(id); 
      }
      return Ok(sessionAttendee);
    }

    [HttpPost]
    [Route("create")]
    [ResponseType(typeof(SessionAttendeeDto))]
    public IHttpActionResult Post(SessionAttendeeDto trackSession)
    {
      using (_sessionAttendeeService)
      {
        var response = _sessionAttendeeService.Create(trackSession);
        return Created(new Uri(Request.RequestUri, $"{response.TrackSessionId}"), response);
      }
    }

    [HttpPost]
    [Route("enroll")]
    [ResponseType(typeof(SessionAttendeeDto))]
    public IHttpActionResult Enroll(int trackSessionId, int attendeeId)
    {
      using (_sessionAttendeeService)
      {
        _sessionAttendeeService.Enroll(trackSessionId, attendeeId);
        return Ok();
      }
    }

    [HttpPut]
    [Route("update")]
    [ResponseType(typeof(SessionAttendeeDto))]
    public IHttpActionResult Put(SessionAttendeeDto sessionAttendee)
    {
      using (_sessionAttendeeService)
      {
        var response = _sessionAttendeeService.Update(sessionAttendee); 
        return Ok(response);
      }
    }

    [HttpDelete]
    [Route("delete")]
    [ResponseType(typeof(OkResult))]
    public IHttpActionResult Delete(int id)
    {
      using (_sessionAttendeeService)
      {
        _sessionAttendeeService.Delete(id); 
      }
      return Ok();
    }
  }
}
