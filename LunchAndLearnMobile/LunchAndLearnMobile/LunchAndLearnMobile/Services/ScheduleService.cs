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

    public static async Task<IEnumerable<Schedule>> GetSchedules()
    {
      List<Schedule> schedules = new List<Schedule>();
      _client = CreateHttpClient();

      HttpResponseMessage response = await _client.GetAsync("api/schedule/all");
      if (response.IsSuccessStatusCode)
      {
        schedules = await response.Content.ReadAsAsync<List<Schedule>>();
      }
      return schedules;
    }
  }
}
