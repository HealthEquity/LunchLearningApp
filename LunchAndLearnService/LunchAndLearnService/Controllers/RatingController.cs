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
  [RoutePrefix("api/rating")]
  public class RatingController : ApiController
  {
    private readonly IRatingService _ratingService;

    public RatingController(IRatingService ratingService)
    {
      _ratingService = ratingService;
    }

    [Route("all")]
    [HttpGet]
    [ResponseType(typeof(List<RatingDto>))]
    public IHttpActionResult GetAll()
    {
      List<RatingDto> ratings;
      using (_ratingService)
      {
        ratings = _ratingService.GetAll(); 
      }
      return Ok(ratings);
    }

    [Route("{id}")]
    [HttpGet]
    [ResponseType(typeof(RatingDto))]
    public IHttpActionResult Get(int id)
    {
      RatingDto rating;
      using (_ratingService)
      {
        rating = _ratingService.Get(id);
      }
      return Ok(rating);
    }

    [HttpPost]
    [Route("create")]
    [ResponseType(typeof(OkResult))]
    public IHttpActionResult Post(RatingDto rating)
    {
      using (_ratingService)
      {
        _ratingService.Create(rating);
      }
      return Ok();
    }

    [HttpPut]
    [Route("update")]
    [ResponseType(typeof(OkResult))]
    public IHttpActionResult Put(RatingDto rating)
    {
      using (_ratingService)
      {
        _ratingService.Update(rating); 
      }
      return Ok();
    }

    [HttpDelete]
    [Route("delete")]
    [ResponseType(typeof(OkResult))]
    public IHttpActionResult Delete(int id)
    {
      using (_ratingService)
      {
        _ratingService.Delete(id); 
      }
      return Ok();
    }
  }
}
