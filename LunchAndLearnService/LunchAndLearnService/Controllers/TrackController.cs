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
  [RoutePrefix("api/track")]
  public class TrackController : ApiController
  {
    private readonly IManagerClass<TrackDto> _trackManager;

    public TrackController(IManagerClass<TrackDto> trackManager)
    {
      _trackManager = trackManager;
    }

    [HttpGet]
    [Route("all")]
    [ResponseType(typeof(List<TrackDto>))]
    public IHttpActionResult GetAll()
    {
      List<TrackDto> tracks;
      using (_trackManager)
      {
        tracks = _trackManager.GetAll(); 
      }
      return Ok(tracks);
    }

    [HttpGet]
    [Route("{id}")]
    [ResponseType(typeof(TrackDto))]
    public IHttpActionResult Get(int id)
    {
      TrackDto track;
      using (_trackManager)
      {
        track = _trackManager.Get(id); 
      }
      return Ok(track);
    }

    [HttpPost]
    [Route("create")]
    [ResponseType(typeof(OkResult))]
    public IHttpActionResult Create(TrackDto track)
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
    public IHttpActionResult Put(TrackDto track)
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
