using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace LunchAndLearnMobile
{
  public class DbClass
  {
    static HttpClient client = new HttpClient();

    public static async Task RunAsync()
    {
      // New code:
      client.BaseAddress = new Uri("http://localhost:55268/");
      client.DefaultRequestHeaders.Accept.Clear();
      client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

      Console.ReadLine();
    }

    public static async Task<List<DbClass>> GetClasses()
    {
      List<DbClass> classes = new List<DbClass>();
      HttpResponseMessage response = await client.GetAsync("api/class/all");
      if (response.IsSuccessStatusCode)
      {
        classes = await response.Content.ReadAsAsync<List<DbClass>>();
      }
      return classes;
    }
  }
}

