using System;
using LunchAndLearn.Model.DTOs.ReportingDTOs;

namespace LunchAndLearn.Management.Interfaces.Reporting
{
  public interface IReportingService : IDisposable
  {
    OverallInstructorRatingDTO GetAverageRatingForInstructor(int instructorId);
  }
}