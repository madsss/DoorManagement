using DoorManagement.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorManagement.ViewModel
{
  public class DoorVM
  {
    private ObservableCollection<DoorModel> myDoors { get; set; }

    public DoorVM()
    {
      myDoors = new ObservableCollection<DoorModel>();
      DoorModel d = new DoorModel(1, "Door 1", "Close", "Locked", false, true);
      myDoors.Add(d);
      //DoorModel d2 = new DoorModel() { Title = "Door No 1", ImageData = @"Images/CloseDoor.png" };
      //Doors.Add(d);
      //DoorModel d3 = new DoorModel() { Title = "Door No 1", ImageData = @"Images/OpenDoor.jpg" };
      //Doors.Add(d);
      DoorRepository allDoors = new DoorRepository();
      var doors = allDoors.PopulateDoorModels();
      foreach (var dr in doors)
        myDoors.Add(dr);
    }

  }
}
