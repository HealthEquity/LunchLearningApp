using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using LunchAndLearn.Management;
using LunchAndLearn.Management.Interfaces;
using LunchAndLearn.Model;
using LunchAndLearn.Model.DB_Models;
using LunchAndLearn.Model.DTOs;

namespace LunchAndLearnService.Controllers
{
  [RoutePrefix("api/room")]
  public class RoomController : ApiController
  {
    private readonly IManagerClass<RoomDto> _roomManager;

    public RoomController(IManagerClass<RoomDto> roomManager)
    {
      this._roomManager = roomManager;
    }

    [HttpGet]
    [Route("all")]
    [ResponseType(typeof(List<Room>))]
    public IHttpActionResult GetAll()
    {
      List<RoomDto> rooms;
      using (_roomManager)
      {
        rooms = _roomManager.GetAll(); 
      }
      return Ok(rooms);
    }

    [HttpGet]
    [Route("{id}")]
    [ResponseType(typeof(Room))]
    public IHttpActionResult Get(int id)
    {
      RoomDto room;
      using (_roomManager)
      {
        room = _roomManager.Get(id); 
      }
      return Ok(room);
    }

    [HttpPost]
    [Route("create")]
    [ResponseType(typeof(OkResult))]
    public IHttpActionResult Post(RoomDto room)
    {
      using (_roomManager)
      {
        _roomManager.Create(room);
      }
      return Ok();
    }

    [HttpPut]
    [Route("update")]
    [ResponseType(typeof(OkResult))]
    public IHttpActionResult Put(RoomDto room)
    {
      using (_roomManager)
      {
        _roomManager.Update(room); 
      }
      return Ok();
    }
    
    [HttpDelete]
    [Route("delete")]
    [ResponseType(typeof(OkResult))]
    public IHttpActionResult Delete(int id)
    {
      using (_roomManager)
      {
        _roomManager.Delete(id); 
      }
      return Ok();
    }
  }
}