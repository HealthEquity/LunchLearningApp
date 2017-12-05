using LunchAndLearn.Management;
using LunchAndLearn.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using LunchAndLearn.Management.Interfaces;
using LunchAndLearn.Model.DB_Models;
using LunchAndLearn.Model.DTOs;

namespace LunchAndLearnService.Controllers
{
  [RoutePrefix("api/artifact")]
  public class ArtifactController : ApiController
  {
    private readonly IArtifactService _artifactService;

    public ArtifactController(IArtifactService artifactService)
    {
      _artifactService = artifactService;
    }

    // GET api/artifact
    [HttpGet]
    [Route("all")]
    [ResponseType(typeof(List<ArtifactDto>))]
    public IHttpActionResult GetAll()
    {
      List<ArtifactDto> allArtifacts;
      using (_artifactService)
      {
        allArtifacts = _artifactService.GetAll();
      }
      return this.Ok(allArtifacts);
    }

    [HttpGet]
    [Route("{id}")]
    [ResponseType(typeof(ArtifactDto))]
    public IHttpActionResult Get(int id)
    {
      ArtifactDto artifactToReturn;
      using (_artifactService)
      {
        artifactToReturn = _artifactService.Get(id);
      }
      return this.Ok(artifactToReturn);
    }

    [HttpPost]
    [Route("create")]
    [ResponseType(typeof(ArtifactDto))]
    public IHttpActionResult Post(ArtifactDto ClassToCreate)
    {
      using (_artifactService)
      {
        var response = _artifactService.Create(ClassToCreate);
        if (response != null)
        {
          return Created(new Uri(Request.RequestUri, $"{response.ArtifactId}"), response);
        }
        return InternalServerError();
      }
    }

    [HttpPut]
    [Route("update")]
    [ResponseType(typeof(ArtifactDto))]
    public IHttpActionResult Put(ArtifactDto artifactToBeUpdated)
    {
      using (_artifactService)
      {
        var response = _artifactService.Update(artifactToBeUpdated);
        return Ok(response);
      }
    }

    [HttpDelete]
    [Route("delete")]
    [ResponseType(typeof(OkResult))]
    public IHttpActionResult Delete(int id)
    {
      using (_artifactService)
      {
        _artifactService.Delete(id); 
      }
      return Ok();
    }
  }
}