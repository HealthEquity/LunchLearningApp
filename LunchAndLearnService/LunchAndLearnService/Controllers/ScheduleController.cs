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
    private readonly IScheduleService _scheduleService;

    public ScheduleController(IScheduleService scheduleService)
    {
      _scheduleService = scheduleService;
    }

    [HttpGet]
    [Route("all")]
    [ResponseType(typeof(List<ScheduleDto>))]
    public IHttpActionResult GetAll()
    {
      List<ScheduleDto> schedules;
      using (_scheduleService)
      {
        schedules = _scheduleService.GetAll();
      }
      return Ok(schedules);
    }

    [HttpGet]
    [Route("{id}")]
    [ResponseType(typeof(ScheduleDto))]
    public IHttpActionResult Get(int id)
    {
      ScheduleDto schedule;
      using (_scheduleService)
      {
        schedule = _scheduleService.Get(id); 
      }
      return Ok(schedule);
    }

    [HttpPost]
    [Route("create")]
    [ResponseType(typeof(OkResult))]
    public IHttpActionResult Post(ScheduleDto schedule)
    {
      using (_scheduleService)
      {
        _scheduleService.Create(schedule); 
      }
      return Ok();
    }

    [HttpPut]
    [Route("update")]
    [ResponseType(typeof(OkResult))]
    public IHttpActionResult Put(ScheduleDto schedule)
    {
      using (_scheduleService)
      {
        _scheduleService.Update(schedule); 
      }
      return Ok();
    }

    [HttpDelete]
    [Route("delete")]
    [ResponseType(typeof(OkResult))]
    public OkResult Delete(int id)
    {
      using (_scheduleService)
      {
        _scheduleService.Delete(id); 
      }
      return Ok();
    }
  }
}