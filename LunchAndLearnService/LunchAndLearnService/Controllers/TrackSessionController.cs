using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using LunchAndLearn.Management;
using LunchAndLearn.Management.Interfaces;
using LunchAndLearn.Model;
using LunchAndLearn.Model.DB_Models;
using LunchAndLearn.Model.DTOs;

namespace LunchAndLearnService.Controllers
{
  [RoutePrefix("api/tracksession")]
  public class TrackSessionController : ApiController
  {
    private readonly ITrackSessionService _trackSessionService;

    public TrackSessionController(ITrackSessionService trackSessionService)
    {
      _trackSessionService = trackSessionService;
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
