using System.Collections.Generic;
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
  [RoutePrefix("api/schedule")]
  public class ScheduleController : ApiController
  {
    private IManagerClass<ScheduleDto> _scheduleManager;

    public ScheduleController(IManagerClass<ScheduleDto> scheduleManager)
    {
      _scheduleManager = scheduleManager;
    }

    [HttpGet]
    [Route("all")]
    [ResponseType(typeof(List<ScheduleDto>))]
    public IHttpActionResult GetAll()
    {
      List<ScheduleDto> schedules;
      using (_scheduleManager)
      {
        schedules = _scheduleManager.GetAll();
      }
      return Ok(schedules);
    }

    [HttpGet]
    [Route("{id}")]
    [ResponseType(typeof(ScheduleDto))]
    public IHttpActionResult Get(int id)
    {
      ScheduleDto schedule;
      using (_scheduleManager)
      {
        schedule = _scheduleManager.Get(id); 
      }
      return Ok(schedule);
    }

    [HttpPost]
    [Route("create")]
    [ResponseType(typeof(OkResult))]
    public IHttpActionResult Post(ScheduleDto schedule)
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
    public IHttpActionResult Put(ScheduleDto schedule)
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