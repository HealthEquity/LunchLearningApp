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
  public class BaseService
  {
    private static HttpClient _client;

    public static HttpClient CreateHttpClient()
    {
      _client = new HttpClient { BaseAddress = new Uri("http:/lunchandlearnapi-healthequity.com/") };
      _client.DefaultRequestHeaders.Accept.Clear();
      _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
      return _client;
    }

  }
}
