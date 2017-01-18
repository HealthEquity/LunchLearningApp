using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using LunchAndLearn.Management.Interfaces.Reporting;
using LunchAndLearn.Model.DTOs.ReportingDTOs;

namespace LunchAndLearnService.Controllers
{
  [RoutePrefix("api/reporting")]
  public class ReportingController : ApiController
  {
    private readonly IReportingService _reportingService;

    public ReportingController(IReportingService reportingService)
    {
      _reportingService = reportingService;
    }

    [HttpGet]
    [Route("rating/instructor/{instructorId}/overall")]
    [ResponseType(typeof(OverallInstructorRatingDTO))]
    public IHttpActionResult GetAverageRatingForInstructor(int instructorId)
    {
      OverallInstructorRatingDTO response;
      using (_reportingService)
      {
        response = _reportingService.GetAverageRatingForInstructor(instructorId);
      }
      if (response != null)
      {
        return Ok(response);
      }

      return NotFound();
    }
  }
}
