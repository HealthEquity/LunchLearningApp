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
  [RoutePrefix("api/ratinghash")]
  public class RatingHashController : ApiController
  {
    private readonly IRatingHashService _ratingHashService;

    public RatingHashController(IRatingHashService ratingHashService)
    {
      _ratingHashService = ratingHashService;
    }
      
    [Route("all")]
    [HttpGet]
    [ResponseType(typeof(List<RatingHashDto>))]
    public IHttpActionResult GetAll()
    {
      List<RatingHashDto> ratingHashes;
      using (_ratingHashService)
      {
        ratingHashes = _ratingHashService.GetAll(); 
      }
      return Ok(ratingHashes);
    }

    [Route("{id}")]
    [HttpGet]
    [ResponseType(typeof(RatingHashDto))]
    public IHttpActionResult Get(int id)
    {
      RatingHashDto ratingHash;
      using (_ratingHashService)
      {
        ratingHash = _ratingHashService.Get(id);
      }
      return Ok(ratingHash);
    }

    [HttpPost]
    [Route("create")]
    [ResponseType(typeof(RatingHashDto))]
    public IHttpActionResult Post(RatingHashDto ratingHash)
    {
      using (_ratingHashService)
      {
        var response = _ratingHashService.Create(ratingHash);
        return Created(new Uri(Request.RequestUri, $"{response.Value}"), response);
      }
    }

    [HttpPut]
    [Route("update")]
    [ResponseType(typeof(RatingHashDto))]
    public IHttpActionResult Put(RatingHashDto rating)
    {
      using (_ratingHashService)
      {
        var response = _ratingHashService.Update(rating);
        return Ok(response);
      }
    }

    [HttpDelete]
    [Route("delete")]
    [ResponseType(typeof(OkResult))]
    public IHttpActionResult Delete(int id)
    {
      using (_ratingHashService)
      {
        _ratingHashService.Delete(id); 
      }
      return Ok();
    }
  }
}
