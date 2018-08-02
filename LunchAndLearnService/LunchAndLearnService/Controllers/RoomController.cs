using System;
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
  [Authorize]
  [RoutePrefix("api/room")]
  public class RoomController : ApiController
  {
    private readonly IRoomService _roomService;

    public RoomController(IRoomService roomService)
    {
      this._roomService = roomService;
    }

    [HttpGet]
    [Route("all")]
    [ResponseType(typeof(List<RoomDto>))]
    public IHttpActionResult GetAll()
    {
      List<RoomDto> rooms;
      using (_roomService)
      {
        rooms = _roomService.GetAll(); 
      }
      return Ok(rooms);
    }

    [HttpGet]
    [Route("{id}")]
    [ResponseType(typeof(RoomDto))]
    public IHttpActionResult Get(int id)
    {
      RoomDto room;
      using (_roomService)
      {
        room = _roomService.Get(id); 
      }
      return Ok(room);
    }

    [HttpPost]
    [Route("create")]
    [ResponseType(typeof(RoomDto))]
    public IHttpActionResult Post(RoomDto room)
    {
      using (_roomService)
      {
        var response = _roomService.Create(room);
        return Created(new Uri(Request.RequestUri, $"{response.RoomId}"), response);
      }
    }

    [HttpPut]
    [Route("update")]
    [ResponseType(typeof(RoomDto))]
    public IHttpActionResult Put(RoomDto room)
    {
      using (_roomService)
      {
        var response = _roomService.Update(room);
        return Ok(response);
      }
    }
    
    [HttpDelete]
    [Route("delete")]
    [ResponseType(typeof(OkResult))]
    public IHttpActionResult Delete(int id)
    {
      using (_roomService)
      {
        _roomService.Delete(id); 
      }
      return Ok();
    }
  }
}