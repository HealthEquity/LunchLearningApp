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
      return Ok(_scheduleService.GetAll());
    }

    [HttpGet]
    [Route("{id}")]
    [ResponseType(typeof(ScheduleDto))]
    public IHttpActionResult Get(int id)
    {
      var schedule = _scheduleService.Get(id);
      
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
        var response = _scheduleService.Create(schedule);
        return Created(new Uri(Request.RequestUri, $"{response.ScheduleId}"), response);
    }

    [HttpPut]
    [Route("update")]
    [ResponseType(typeof(ScheduleDto))]
    public IHttpActionResult Put(ScheduleDto schedule)
    {
      var response = _scheduleService.Update(schedule);

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
      _scheduleService.Delete(id);
      return Ok();
    }

    [HttpGet]
    [Route("mobile/scheduleDetailsByDate")]
    [ResponseType(typeof(List<ScheduleDetailDto>))]
    public IHttpActionResult GetScheduleDetailsForSpecificDate(DateTime date)
    {
      return Ok(_scheduleService.GetDetailedSchedulesForSpecificDate(date));
    }

    [HttpGet]
    [Route("mobile/scheduleDetailsByScheduleId")]
    [ResponseType(typeof(ScheduleDetailDto))]
    public IHttpActionResult GetScheduleDetailsById(int scheduleId)
    {
      var scheduleDetail = _scheduleService.GetDetailedScheduleById(scheduleId);

      if (scheduleDetail != null)
      {
        return Ok(scheduleDetail);
      }

      return NotFound();
    }

    [HttpGet]
    [Route("mobile/scheduleDetailsForWeek/{dateTime}")]
    [ResponseType(typeof(List<ScheduleDetailDto>))]
    public IHttpActionResult GetDetailedSchedulesForWeek(DateTime dateTime)
    {
      return Ok(_scheduleService.GetDetailedSchedulesForWeek(dateTime));
    }

    protected override void Dispose(bool disposing)
    {
      _scheduleService.Dispose();
      base.Dispose(disposing);
    }
  }
}