using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using LunchAndLearnMobile.Models;

namespace LunchAndLearnMobile.Services
{
  public class InstructorService : BaseService
  {
    private static HttpClient _client;

    public static async Task<IEnumerable<Instructor>> GetInstructors()
    {
      List<Instructor> instructors = new List<Instructor>();
      _client = CreateHttpClient();
      HttpResponseMessage response = await _client.GetAsync("api/instructor/all");
      if (response.IsSuccessStatusCode)
      {
        instructors = await response.Content.ReadAsAsync<List<Instructor>>();
      }
      return instructors;
    }
  }
}
