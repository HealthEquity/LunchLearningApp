using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using LunchAndLearn.Management;
using LunchAndLearn.Management.Interfaces;
using LunchAndLearn.Model;
using LunchAndLearn.Model.DB_Models;

namespace LunchAndLearnService.Controllers
{
  [RoutePrefix("api/schedule")]
  public class ScheduleController : ApiController
  {
    private IManagerClass<Schedule> _scheduleManager;

    public ScheduleController(IManagerClass<Schedule> scheduleManager)
    {
      _scheduleManager = scheduleManager;
    }

    [HttpGet]
    [Route("all")]
    [ResponseType(typeof(List<Schedule>))]
    public IHttpActionResult GetAll()
    {
      List<Schedule> schedules;
      using (_scheduleManager)
      {
        schedules = _scheduleManager.GetAll();
      }
      return Ok(schedules);
    }

    [HttpGet]
    [Route("{id}")]
    [ResponseType(typeof(Schedule))]
    public IHttpActionResult Get(int id)
    {
      Schedule schedule;
      using (_scheduleManager)
      {
        schedule = _scheduleManager.Get(id); 
      }
      return Ok(schedule);
    }

    [HttpPost]
    [Route("create")]
    [ResponseType(typeof(OkResult))]
    public IHttpActionResult Post(Schedule schedule)
    {
      using (_scheduleManager)
      {
        _scheduleManager.Create(schedule); 
      }
      return Ok();
    }

    [HttpPut]
    [Route("update")]
    [ResponseType(typeof(OkResult))]
    public IHttpActionResult Put(Schedule schedule)
    {
      using (_scheduleManager)
      {
        _scheduleManager.Update(schedule); 
      }
      return Ok();
    }

    [HttpDelete]
    [Route("delete")]
    [ResponseType(typeof(OkResult))]
    public OkResult Delete(int id)
    {
      using (_scheduleManager)
      {
        _scheduleManager.Delete(id); 
      }
      return Ok();
    }
  }
}