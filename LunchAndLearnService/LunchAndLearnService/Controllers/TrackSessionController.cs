using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using LunchAndLearn.Management.Interfaces;
using LunchAndLearn.Model.DB_Models;
using LunchAndLearn.Model.DTOs;

namespace LunchAndLearnService.Controllers
{
  [Authorize]
  [RoutePrefix("api/tracksession")]
  public class TrackSessionController : ApiController
  {
    private readonly ITrackSessionService _trackSessionService;
    private readonly ISessionAttendeeService _sessionAttendeeService;

    public TrackSessionController(ITrackSessionService trackSessionService, ISessionAttendeeService sessionAttendeeService)
    {
      _trackSessionService = trackSessionService;
      _sessionAttendeeService = sessionAttendeeService;
    }

    [HttpGet]
    [Route("all")]
    [ResponseType(typeof(List<TrackSessionDto>))]
    public IHttpActionResult GetAll()
    {
      List<TrackSessionDto> trackSessions;
      using (_trackSessionService)
      {
        trackSessions = _trackSessionService.GetAll(); 
      }
      return Ok(trackSessions);
    }

    [HttpGet]
    [Route("upcoming")]
    [ResponseType(typeof(List<TrackSessionDetailDto>))]
    public IHttpActionResult GetUpcoming()
    {
      List<TrackSessionDetailDto> trackSessions;
      using (_trackSessionService)
      {
        trackSessions = _trackSessionService.GetUpcoming();
      }
      return Ok(trackSessions);
    }

    [HttpGet]
    [Route("mysessions")]
    [ResponseType(typeof(List<TrackSessionDetailDto>))]
    public IHttpActionResult GetMySessions(int personId)
    {
      var attendingSessions = new List<SessionAttendeeDto>();
      var trackSessions = new List<TrackSessionDetailDto>();
      using (_sessionAttendeeService)
      {
        attendingSessions = _sessionAttendeeService.GetByPersonId(personId);
      }
      if (attendingSessions == null || attendingSessions.Count <= 0) return Ok(trackSessions);
      foreach (var session in attendingSessions)
      {
        using (_trackSessionService)
        {
          trackSessions.Add(_trackSessionService.GetTrackSessionDetail(session.TrackSessionId));
        }
      }
      return Ok(trackSessions);
    }

    [HttpGet]
    [Route("{id}")]
    [ResponseType(typeof(TrackSessionDto))]
    public IHttpActionResult Get(int id)
    {
      TrackSessionDto trackSession;
      using (_trackSessionService)
      {
        trackSession = _trackSessionService.Get(id); 
      }
      return Ok(trackSession);
    }

    [HttpPost]
    [Route("create")]
    [ResponseType(typeof(TrackSessionDto))]
    public IHttpActionResult Post(TrackSessionDto trackSession)
    {
      using (_trackSessionService)
      {
        var response = _trackSessionService.Create(trackSession);
        return Created(new Uri(Request.RequestUri, $"{response.TrackSessionId}"), response);
      }
    }

    [HttpPut]
    [Route("update")]
    [ResponseType(typeof(TrackSessionDto))]
    public IHttpActionResult Put(TrackSessionDto trackSession)
    {
      using (_trackSessionService)
      {
        var response = _trackSessionService.Update(trackSession); 
        return Ok(response);
      }
    }

    [HttpDelete]
    [Route("delete")]
    [ResponseType(typeof(OkResult))]
    public IHttpActionResult Delete(int id)
    {
      using (_trackSessionService)
      {
        _trackSessionService.Delete(id); 
      }
      return Ok();
    }
  }
}
