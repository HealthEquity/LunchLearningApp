using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchAndLearnMobile.Models;
using System.Net.Http;
using System.Net.Http.Headers;

namespace LunchAndLearnMobile.Services
{
  public class ScheduleService : BaseService
  {
    private static HttpClient _client;

    public static async Task<IEnumerable<Schedule>> GetSchedulesByDate(DateTime date)
    {
      try
      {
        List<Schedule> schedules = new List<Schedule>();
        _client = CreateHttpClient();
        HttpResponseMessage response = await _client.GetAsync("api/schedule/mobile/scheduleDetailsByDate?date=" + date);
        if (response.IsSuccessStatusCode)
        {
          schedules = await response.Content.ReadAsAsync<List<Schedule>>();
        }
        return schedules;
      }
      catch (Exception ex)
      {
        var message = ex.Message;
        throw;
      }
    }

    public static async Task<Schedule> GetScheduleDetailsById(int scheduleId)
    {
      try
      {
        Schedule schedule = new Schedule();
        _client = CreateHttpClient();

        HttpResponseMessage response = await _client.GetAsync("api/schedule/mobile/scheduleDetailsByScheduleId?scheduleId=" + scheduleId);
        if (response.IsSuccessStatusCode)
        {
          schedule = await response.Content.ReadAsAsync<Schedule>();
        }
        return schedule;
      }
      catch (Exception ex)
      {
        var message = ex.Message;
        throw;
      }
    }
  }
}
