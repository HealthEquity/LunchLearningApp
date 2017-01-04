using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using LunchAndLearn.Management;
using LunchAndLearn.Model;

namespace LunchAndLearnService.Controllers
{
  public class RoomController : ApiController
  {
    private readonly ILunchAndLearnManager _lunchAndLearnManager;

    public RoomController(ILunchAndLearnManager lunchAndLearnManager)
    {
      this._lunchAndLearnManager = lunchAndLearnManager;
    }

    public RoomController()
    {
      _lunchAndLearnManager = new LunchAndLearnManager();
    }

    [HttpGet]
    [Route("all")]
    [ResponseType(typeof(List<Room>))]
    public IHttpActionResult GetAll()
    {
      var response = _lunchAndLearnManager.RoomManager.GetAll();
      return Ok(response);
    }

    [HttpGet]
    [Route("{id}")]
    [ResponseType(typeof(Room))]
    public IHttpActionResult Get(int id)
    {
      var response = _lunchAndLearnManager.RoomManager.Get(id);
      return Ok(response);
    }

    [HttpPost]
    [Route("create")]
    [ResponseType(typeof(OkResult))]
    public IHttpActionResult Post(Room room)
    {
      _lunchAndLearnManager.RoomManager.Create(room);
      return Ok();
    }

    [HttpPut]
    [Route("update")]
    [ResponseType(typeof(OkResult))]
    public IHttpActionResult Put(Room room)
    {
      _lunchAndLearnManager.RoomManager.Update(room);
      return Ok();
    }
    
    [HttpDelete]
    [Route("delete")]
    [ResponseType(typeof(OkResult))]
    public IHttpActionResult Delete(int id)
    {
      _lunchAndLearnManager.RoomManager.Delete(id);
      return Ok();
    }
  }
}