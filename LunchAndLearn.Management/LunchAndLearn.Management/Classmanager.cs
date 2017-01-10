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
    public virtual Class Create(Class lClass)
    {
      ValidateModel(lClass);
      AddEntity(lClass);
      return lClass;
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
    public virtual void Update(Class lClass)
    {
      ValidateModel(lClass);
      UpdateEntity(lClass);
    }

    /// <summary>Delete class</summary>
    public virtual void Delete(int id)
    {
      DeleteEntity(new Class());
    }
  }
}
