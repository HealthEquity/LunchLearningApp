using LunchAndLearn.Data;
using LunchAndLearn.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LunchAndLearn.Management
{
  public class RatingManager : BaseManager, ILunchAndLearnRepository<Rating, int>
  {
    public RatingManager() { }

    public RatingManager(LunchAndLearnContext context)
        : base(context)
    {
    }


    // CRUD

    /// <summary>Create a new rating</summary>
    public void Create(Rating rating)
    {
      ValidateModel(rating);

      AddEntity(rating);
    }


    /// <summary>Get a rating</summary>
    public Rating Get(int id)
    {
      return Context.Ratings.Where(al => al.RatingId == id).First();
    }

    public List<Rating> GetAll()
    {
      return Context.Ratings.ToList();
    }
    /// <summary>Update existing rating</summary>
    public void Update(Rating rating)
    {
      ValidateModel(rating);
      UpdateEntity(rating);
    }

    /// <summary>Delete rating</summary>
    public void Delete(int id)
    {
      //DeleteEntity(new Rating());
    }
    // Getters


  }
}