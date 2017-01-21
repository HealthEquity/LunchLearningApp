using System;
using LunchAndLearn.Data.Interfaces;
using LunchAndLearn.Management.Interfaces.Reporting;
using LunchAndLearn.Model.DTOs.ReportingDTOs;

namespace LunchAndLearn.Management.Reporting
{
  public class ReportingService : IReportingService
  {
    private readonly IUnitOfWork _unitOfWork;
    public ReportingService(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
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
          _unitOfWork.Dispose();
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
