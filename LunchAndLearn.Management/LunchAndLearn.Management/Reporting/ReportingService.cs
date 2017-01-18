using System;
using LunchAndLearn.Data.Interfaces;
using LunchAndLearn.Management.Interfaces.Reporting;
using LunchAndLearn.Model.DTOs.ReportingDTOs;

namespace LunchAndLearn.Management.Reporting
{
  public class ReportingService : IReportingService
  {
    private readonly IRatingRepository _ratingRepository;
    public ReportingService(IRatingRepository ratingRepository)
    {
      _ratingRepository = ratingRepository;
    }

    public OverallInstructorRatingDTO GetAverageRatingForInstructor(int instructorId)
    {
      throw new NotImplementedException();
    }


    #region Disposal
    private bool _disposed = false;

    protected virtual void Dispose(bool disposing)
    {
      if (!this._disposed)
      {
        if (disposing)
        {
          _ratingRepository.Dispose();
        }
      }
      this._disposed = true;
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }
    #endregion
  }
}
