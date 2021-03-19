using RestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestAPI.Controllers
{
  [RoutePrefix("Doors")]
  public class DoorController : ApiController
  {
    [HttpGet]
    [Route("AllDoors")]
    public IHttpActionResult GetAll()
    {
      FakeDatabase fakeDatabase = new FakeDatabase();

      var c = fakeDatabase.GetAll();

      return Ok(c);

    }

    [HttpPost]
    [Route("LockDoor")]
    public IHttpActionResult Lock([FromBody] int Id)
    {
      FakeDatabase fakeDatabase = new FakeDatabase();

      fakeDatabase.Lock(Id);

      return Ok();

    }

    [HttpPost]
    [Route("CreateDoor")]
    public IHttpActionResult CreateDoor([FromBody] string name)
    {
      FakeDatabase fakeDatabase = new FakeDatabase();

      fakeDatabase.Add(name);

      return Ok();

    }

    [HttpPost]
    [Route("OpenDoor")]
    public IHttpActionResult Open([FromBody] int Id)
    {
      FakeDatabase fakeDatabase = new FakeDatabase();

      fakeDatabase.Open(Id);

      return Ok();

    }

    [HttpPost]
    [Route("UnLockDoor")]
    public IHttpActionResult UnLock([FromBody] int Id)
    {
      FakeDatabase fakeDatabase = new FakeDatabase();

      fakeDatabase.UnLock(Id);

      return Ok();

    }

    [HttpPost]
    [Route("CloseDoor")]
    public IHttpActionResult Close([FromBody] int Id)
    {
      FakeDatabase fakeDatabase = new FakeDatabase();

      fakeDatabase.Close(Id);

      return Ok();

    }

    [HttpPost]
    [Route("RemoveDoor")]
    public IHttpActionResult Remvove([FromBody] int Id)
    {
      FakeDatabase fakeDatabase = new FakeDatabase();

      fakeDatabase.Remove(Id);

      return Ok();

    }

  }
}
