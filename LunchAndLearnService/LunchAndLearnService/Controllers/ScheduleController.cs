using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using LunchAndLearn.Management;
using LunchAndLearn.Model;

namespace LunchAndLearnService.Controllers
{
  public class ScheduleController : ApiController
  {
    private ILunchAndLearnManager _lunchAndLearnManager;

    public ScheduleController(ILunchAndLearnManager lunchAndLearnManager)
    {
      _lunchAndLearnManager = lunchAndLearnManager;
    }

    public ScheduleController()
    {
      _lunchAndLearnManager = new LunchAndLearnManager();
    }

    [HttpGet]
    [Route("all")]
    [ResponseType(typeof(List<Schedule>))]
    public IHttpActionResult GetAll()
    {
      var response = _lunchAndLearnManager.ScheduleManager.GetAll();
      return Ok(response);
    }

    [HttpGet]
    [Route("{id}")]
    [ResponseType(typeof(Schedule))]
    public IHttpActionResult Get(int id)
    {
      var response = _lunchAndLearnManager.ScheduleManager.Get(id);
      return Ok(response);
    }

    [HttpPost]
    [Route("create")]
    [ResponseType(typeof(OkResult))]
    public IHttpActionResult Post(Schedule schedule)
    {
      _lunchAndLearnManager.ScheduleManager.Create(schedule);
      return Ok();
    }

    [HttpPut]
    [Route("update")]
    [ResponseType(typeof(OkResult))]
    public IHttpActionResult Put(Schedule schedule)
    {
      _lunchAndLearnManager.ScheduleManager.Update(schedule);
      return Ok();
    }

    [HttpDelete]
    [Route("delete")]
    [ResponseType(typeof(OkResult))]
    public OkResult Delete(int id)
    {
      _lunchAndLearnManager.ScheduleManager.Delete(id);
      return Ok();
    }
  }
}