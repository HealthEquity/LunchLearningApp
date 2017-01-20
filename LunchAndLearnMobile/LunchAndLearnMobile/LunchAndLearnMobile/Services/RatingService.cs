using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchAndLearnMobile.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
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
        string ratingJson = JsonConvert.SerializeObject(rating);
        var ratingData = new StringContent(ratingJson, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await _client.PostAsync("api/rating/create", ratingData);
        if (response.IsSuccessStatusCode)
        {
          createdRating = await response.Content.ReadAsAsync<Rating>();
        }
        return createdRating;
      }
      catch (Exception ex)
      {
        var message = ex.Message;
        throw;
      }
    }
   }

}
