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
  [RoutePrefix("api/rating")]
  public class RatingController : ApiController
  {
    private readonly ILunchAndLearnManager _lunchAndLearnManager;

    public RatingController(ILunchAndLearnManager lunchAndLearnManager)
    {
      _lunchAndLearnManager = lunchAndLearnManager;
    }

    public RatingController()
    {
      _lunchAndLearnManager = new LunchAndLearnManager();
    }

    [Route("all")]
    [HttpGet]
    [ResponseType(typeof(List<Rating>))]
    public IHttpActionResult GetAll()
    {
      var response = _lunchAndLearnManager.RatingManager.GetAll();
      return Ok(response);
    }

    [Route("{id}")]
    [HttpGet]
    [ResponseType(typeof(Rating))]
    public IHttpActionResult Get(int id)
    {
      var response = _lunchAndLearnManager.RatingManager.Get(id);
      return Ok(response);
    }
  }
}
