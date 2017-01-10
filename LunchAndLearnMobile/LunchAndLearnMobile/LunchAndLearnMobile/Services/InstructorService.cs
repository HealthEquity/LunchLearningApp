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
  public class InstructorService
  {
    private static HttpClient client = new HttpClient();

    public static async Task RunAsync()
    {
      // New code:
      client.BaseAddress = new Uri("http://localhost:8748/");
      client.DefaultRequestHeaders.Accept.Clear();
      client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

      //Console.ReadLine();
    }

    public static async Task<IEnumerable<Instructor>> GetInstructors()
    {
      List<Instructor> instructors = new List<Instructor>();
      HttpResponseMessage response = await client.GetAsync("api/instructor/all");
      if (response.IsSuccessStatusCode)
      {
        //classes = await response.Content.ReadAsAsync<List<DbClass>>();
      }
      return instructors;
    }
  }
}
