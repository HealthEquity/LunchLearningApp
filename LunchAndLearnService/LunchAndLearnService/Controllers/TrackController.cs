using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using LunchAndLearn.Management;
using LunchAndLearn.Model;

namespace LunchAndLearnService.Controllers
{
  public class TrackController : ApiController
  {
    private readonly ILunchAndLearnManager _lunchAndLearnManager;

    public TrackController(ILunchAndLearnManager lunchAndLearnManager)
    {
      _lunchAndLearnManager = lunchAndLearnManager;
    }

    public TrackController()
    {
      _lunchAndLearnManager = new LunchAndLearnManager();
    }

    [HttpGet]
    [Route("all")]
    [ResponseType(typeof(List<Track>))]
    public IHttpActionResult GetAll()
    {
      var response = _lunchAndLearnManager.TrackManager.GetAll();
      return Ok(response);
    }

    [HttpGet]
    [Route("{id}")]
    [ResponseType(typeof(Track))]
    public IHttpActionResult Get(int id)
    {
      var response = _lunchAndLearnManager.TrackManager.Get(id);
      return Ok(response);
    }

    [HttpPost]
    [Route("create")]
    [ResponseType(typeof(OkResult))]
    public IHttpActionResult Create(Track track)
    {
      _lunchAndLearnManager.TrackManager.Create(track);
      return Ok();
    }

    [HttpPut]
    [Route("update")]
    [ResponseType(typeof(OkResult))]
    public IHttpActionResult Put(Track track)
    {
      _lunchAndLearnManager.TrackManager.Update(track);
      return Ok();
    }

    [HttpDelete]
    [Route("delete")]
    [ResponseType(typeof(OkResult))]
    public IHttpActionResult Delete(int id)
    {
      _lunchAndLearnManager.TrackManager.Delete(id);
      return Ok();
    }
  }
}
