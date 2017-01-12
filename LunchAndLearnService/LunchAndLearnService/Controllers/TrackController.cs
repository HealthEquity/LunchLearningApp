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

namespace LunchAndLearnService.Controllers
{
  [RoutePrefix("api/track")]
  public class TrackController : ApiController
  {
    private readonly IManagerClass<Track> _trackManager;

    public TrackController(IManagerClass<Track> trackManager)
    {
      _trackManager = trackManager;
    }

    [HttpGet]
    [Route("all")]
    [ResponseType(typeof(List<Track>))]
    public IHttpActionResult GetAll()
    {
      List<Track> tracks;
      using (_trackManager)
      {
        tracks = _trackManager.GetAll(); 
      }
      return Ok(tracks);
    }

    [HttpGet]
    [Route("{id}")]
    [ResponseType(typeof(Track))]
    public IHttpActionResult Get(int id)
    {
      Track track;
      using (_trackManager)
      {
        track = _trackManager.Get(id); 
      }
      return Ok(track);
    }

    [HttpPost]
    [Route("create")]
    [ResponseType(typeof(OkResult))]
    public IHttpActionResult Create(Track track)
    {
      using (_trackManager)
      {
        _trackManager.Create(track); 
      }
      return Ok();
    }

    [HttpPut]
    [Route("update")]
    [ResponseType(typeof(OkResult))]
    public IHttpActionResult Put(Track track)
    {
      using (_trackManager)
      {
        _trackManager.Update(track); 
      }
      return Ok();
    }

    [HttpDelete]
    [Route("delete")]
    [ResponseType(typeof(OkResult))]
    public IHttpActionResult Delete(int id)
    {
      using (_trackManager)
      {
        _trackManager.Delete(id); 
      }
      return Ok();
    }
  }
}
