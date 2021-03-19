using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Models
{
  /// <summary>
  /// this is fake implementation of database
  /// </summary>
  public class FakeDatabase
  {
    public static List<DoorModel> Doors { get; set; }
    public FakeDatabase()
    {
      //load some intial doors
      if (Doors == null)
      {
        Doors = new List<DoorModel>();
        Doors.Add(new DoorModel(1, "Door 1", "Close", "Locked", false, true));
        Doors.Add(new DoorModel(2, "Door 2", "Open", "Locked", true, true));
        Doors.Add(new DoorModel(3, "Door 3", "Open", "Locked", true, true));
        Doors.Add(new DoorModel(4, "Door 4", "Close", "UnLocked", false, false));
        Doors.Add(new DoorModel(5, "Door 5", "Close", "Locked", false, true));
        Doors.Add(new DoorModel(6, "Door 6", "Open", "Locked", true, true));
        Doors.Add(new DoorModel(7, "Door 7", "Open", "Locked", true, true));
        Doors.Add(new DoorModel(8, "Door 8", "Open", "UnLocked", true, false));
      }
    }

    internal void Add(string doorName)
    {
      System.Random random = new System.Random();
      Doors.Add(new DoorModel(random.Next(), doorName, "Open", "UnLocked", true, false));
    }
    /// <summary>
    ///  Lock the door only when it is closed
    /// </summary>
    /// <param name="Id"></param>
    public void Lock(int Id)
    {
      var d = Doors.Find(x => x.Id == Id);
      if (d.IsOpen == false)
      {
        d.IsLock = true;
        d.LockState = "Locked";
      }

    }
    /// <summary>
    ///  Open the door only when it is unlocked
    /// </summary>
    /// <param name="Id"></param>
    public void Open(int Id)
    {
      var d = Doors.Find(x => x.Id == Id);
      if (d.IsLock == false)
      {
        d.IsOpen = true;
        d.OCState = "Open";
      }
    }

    /// <summary>
    ///  remove a door
    /// </summary>
    /// <param name="id"></param>
    internal void Remove(int id)
    {
      var d = Doors.Find(x => x.Id == id);
      Doors.Remove(d);
    }

    /// <summary>
    ///  unlock a door when it is locked
    /// </summary>
    /// <param name="Id"></param>
    public void UnLock(int Id)
    {
      var d = Doors.Find(x => x.Id == Id);
      if (d.IsLock == true)
      {
        d.IsLock = false;
        d.LockState = "UnLocked";
      }

    }

    /// <summary>
    ///  close door when it is open
    /// </summary>
    /// <param name="Id"></param>
    public void Close(int Id)
    {
      var d = Doors.Find(x => x.Id == Id);
      if (d.IsOpen == true)
      {
        d.IsOpen = false;
        d.OCState = "Close";
      }

    }

    /// <summary>
    ///  get the list of all the doors
    /// </summary>
    /// <returns></returns>
    public List<DoorModel> GetAll()
    {

      return Doors;
    }

  }
}