using System;
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

      if (schedule != null)
      {
        return Ok(schedule);
      }

      return NotFound();
    }

    [HttpPost]
    [Route("create")]
    [ResponseType(typeof(ScheduleDto))]
    public IHttpActionResult Post(ScheduleDto schedule)
    {
      using (_scheduleService)
      {
        var response = _scheduleService.Create(schedule);
        return Created(new Uri(Request.RequestUri, $"{response.ScheduleId}"), response);
      }
    }

    [HttpPut]
    [Route("update")]
    [ResponseType(typeof(ScheduleDto))]
    public IHttpActionResult Put(ScheduleDto schedule)
    {
      ScheduleDto response;
      using (_scheduleService)
      {
        response = _scheduleService.Update(schedule);
      }

      if (response != null)
      {
        return Ok(response);
      }

      return NotFound();
    }

    [HttpDelete]
    [Route("{id}")]
    [ResponseType(typeof(OkResult))]
    public IHttpActionResult Delete(int id)
    {
      using (_scheduleService)
      {
          _scheduleService.Delete(id);
      }
      return Ok();
    }

    [HttpGet]
    [Route("mobile/scheduleDetailsByDate")]
    [ResponseType(typeof(List<ScheduleDetailDto>))]
    public IHttpActionResult GetScheduleDetailsForSpecificDate(DateTime date)
    {
      List<ScheduleDetailDto> scheduleDetailList;
      using (_scheduleService)
      {
        scheduleDetailList = _scheduleService.GetDetailedSchedulesForSpecificDate(date);
      }
      return Ok(scheduleDetailList);
    }

    [HttpGet]
    [Route("mobile/scheduleDetailsByScheduleId")]
    [ResponseType(typeof(ScheduleDetailDto))]
    public IHttpActionResult GetScheduleDetailsById(int scheduleId)
    {
      ScheduleDetailDto scheduleDetail;
      using (_scheduleService)
      {
        scheduleDetail = _scheduleService.GetDetailedScheduleById(scheduleId);
      }
      if (scheduleDetail != null)
      {
        return Ok(scheduleDetail);
      }

      return NotFound();
    }
  }
}