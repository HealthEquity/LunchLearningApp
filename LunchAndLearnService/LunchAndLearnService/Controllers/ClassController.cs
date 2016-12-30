using LunchAndLearn.Management;
using LunchAndLearn.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace LunchAndLearnService.Controllers
{
  [RoutePrefix("api/class")]
  public class ClassController : ApiController
  {
    readonly ILunchAndLearnManager _lunchAndLearnManager;

    public ClassController()
    {
      _lunchAndLearnManager = new LunchAndLearnManager();
    }

    // GET api/class
    [HttpGet]
    [Route("all")]
    [ResponseType(typeof(ICollection<Class>))]
    public virtual IHttpActionResult GetAll()
    {
      var classes = _lunchAndLearnManager.ClassManager.GetAll();
      return this.Ok(classes);
    }

    [HttpGet]
    [Route("{id}")]
    [ResponseType(typeof(ICollection<Class>))]
    public virtual IHttpActionResult Get(int id)
    {
      var dbClass = _lunchAndLearnManager.ClassManager.Get(id);
      return this.Ok(dbClass);
    }

    // POST api/ticket
    public void Post([FromBody]string value)
    {
    }

    // PUT api/class/5
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE api/class/5
    public void Delete(int id)
    {
    }
  }
}