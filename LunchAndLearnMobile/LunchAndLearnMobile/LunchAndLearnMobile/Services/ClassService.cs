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
  public class ClassService
  {
    private static HttpClient _client;

    //public static async Task RunAsync()
    //{
    //  // New code:
    //  client.BaseAddress = new Uri("http://localhost:8748/");
    //  client.DefaultRequestHeaders.Accept.Clear();
    //  client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

    //  //Console.ReadLine();
    //}

    public static async Task<IEnumerable<DbClass>> GetClasses()
    {
      List<DbClass> classes = new List<DbClass>();
      var uri = new Uri("http://10.0.2.2:8748/api/class/all");

      _client = new HttpClient();
      _client.MaxResponseContentBufferSize = 256000;
      //client.BaseAddress = new Uri("http://localhost:8748/");
      _client.DefaultRequestHeaders.Accept.Clear();
      _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

      HttpResponseMessage response = await _client.GetAsync(uri);
      if (response.IsSuccessStatusCode)
      {
        classes = await response.Content.ReadAsAsync<List<DbClass>>();
      }
      return classes;
    }
  }
}
