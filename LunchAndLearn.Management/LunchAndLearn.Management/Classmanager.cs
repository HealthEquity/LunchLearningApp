using LunchAndLearn.Data;
using LunchAndLearn.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchAndLearn.Management
{
  public class ClassManager : BaseManager, ILunchAndLearnRepository<Class, int>
  {
    public ClassManager() { }

    public ClassManager(LunchAndLearnContext context)
        : base(context)
    {
    }


    // CRUD

    /// <summary>Create a new class</summary>
    public void Create(Class lClass)
    {
      ValidateModel(lClass);
      AddEntity(lClass);
    }


    /// <summary>Get a Class</summary>
    public virtual Class Get(int id)
    {
      return Context.Classes.First(al => al.ClassId == id);
    }

    public virtual List<Class> GetAll()
    {
      return Context.Classes.ToList();
    }
    /// <summary>Update existing class</summary>
    public void Update(Class lClass)
    {
      ValidateModel(lClass);
      UpdateEntity(lClass);
    }

    /// <summary>Delete class</summary>
    public void Delete(int id)
    {
      //DeleteEntity(new Class());
    }


    // Getters


  }
}
