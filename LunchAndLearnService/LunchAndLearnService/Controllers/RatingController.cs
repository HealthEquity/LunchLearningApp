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
    private readonly IManagerClass<RatingDto> _ratingManager;

    public RatingController(IManagerClass<RatingDto> ratingManager)
    {
      _ratingManager = ratingManager;
    }

    [Route("all")]
    [HttpGet]
    [ResponseType(typeof(List<RatingDto>))]
    public IHttpActionResult GetAll()
    {
      List<RatingDto> ratings;
      using (_ratingManager)
      {
        ratings = _ratingManager.GetAll(); 
      }
      return Ok(ratings);
    }

    [Route("{id}")]
    [HttpGet]
    [ResponseType(typeof(RatingDto))]
    public IHttpActionResult Get(int id)
    {
      RatingDto rating;
      using (_ratingManager)
      {
        rating = _ratingManager.Get(id);
      }
      return Ok(rating);
    }

    [HttpPost]
    [Route("create")]
    [ResponseType(typeof(OkResult))]
    public IHttpActionResult Post(RatingDto rating)
    {
      using (_ratingManager)
      {
        _ratingManager.Create(rating);
      }
      return Ok();
    }

    [HttpPut]
    [Route("update")]
    [ResponseType(typeof(OkResult))]
    public IHttpActionResult Put(RatingDto rating)
    {
      using (_ratingManager)
      {
        _ratingManager.Update(rating); 
      }
      return Ok();
    }

    [HttpDelete]
    [Route("delete")]
    [ResponseType(typeof(OkResult))]
    public IHttpActionResult Delete(int id)
    {
      using (_ratingManager)
      {
        _ratingManager.Delete(id); 
      }
      return Ok();
    }
  }
}
