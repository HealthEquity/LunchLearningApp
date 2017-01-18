using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchAndLearnMobile.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace LunchAndLearnMobile.Services
{
  public class RatingService : BaseService
  {
    private static HttpClient _client;

    public static async Task<Rating> SubmitRating(Rating rating)
    {
      try
      {
        var createdRating = new Rating();
        _client = CreateHttpClient();
        HttpResponseMessage response = await _client.PostAsJsonAsync("api/rating/create", rating);
        if (response.IsSuccessStatusCode)
        {
          createdRating = await response.Content.ReadAsAsync<Rating>();
        }
        return createdRating;
      }
      catch (Exception)
      {

        throw;
      }
    }
  }
}
