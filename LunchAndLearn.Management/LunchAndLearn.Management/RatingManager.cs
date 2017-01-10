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
    public virtual Rating Create(Rating rating)
    {
      ValidateModel(rating);

      AddEntity(rating);

      return rating;
    }


    /// <summary>Get a rating</summary>
    public virtual Rating Get(int id)
    {
      return Context.Ratings.FirstOrDefault(al => al.RatingId == id);
    }

    public virtual List<Rating> GetAll()
    {
      return Context.Ratings.ToList();
    }
    /// <summary>Update existing rating</summary>
    public virtual void Update(Rating rating)
    {
      ValidateModel(rating);
      UpdateEntity(rating);
    }

    /// <summary>Delete rating</summary>
    public virtual void Delete(int id)
    {
      //DeleteEntity(new Rating());
    }
    // Getters


  }
}