using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace DoorManagement.Model
{
  public class DoorModel
  {
    public int Id { get; set; }
    public string Name { get; set; }

    public string OCState { get; set; }

    public string LockState { get; set; }

    public bool IsOpen { get; set; }

    public bool IsLock { get; set; }

    private string _ImageData;

    public DoorModel(int id, string name, string oCState, string lockState, bool isOpen, bool isLock)
    {
      Id = id;
      Name = name;
      OCState = oCState;
      LockState = lockState;
      IsOpen = isOpen;
      IsLock = isLock;
    }

    public string ImageData
    {
      get { return this._ImageData; }
      set { this._ImageData = value; }
    }
  }
}
