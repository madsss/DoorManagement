using DoorManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DoorManagement.View
{
  /// <summary>
  /// Interaction logic for UserControl1.xaml
  /// </summary>
  public partial class DoorControl : UserControl
  {
    #region Constructor

    /// <summary>
    /// The ItemTemplateControl constructor
    /// </summary>
    public DoorControl()
    {
      InitializeComponent();
    }

    #endregion

    #region Control Loaded Event Handler

    private void UserControl_Loaded(object sender, RoutedEventArgs e)
    {

    }

    #endregion

    private async void Button_Click_Open(object sender, RoutedEventArgs e)
    {
      var s = sender as System.Windows.Controls.Button;
      var dr = s.CommandParameter as DoorModel;
      if (dr.IsLock)
        MessageBox.Show("First Unlock the Door");
      else
      {
        var sd = new DoorRepository();
        await sd.OpenDoor(int.Parse(dr.Id.ToString()));
      }
      MainWindow win = (MainWindow)Window.GetWindow(this);
      win.RelaodDoors();

    }

    private async void Button_Click_Lock(object sender, RoutedEventArgs e)
    {
      var s = sender as System.Windows.Controls.Button;
      var dr = s.CommandParameter as DoorModel;
      if (dr.IsOpen)
        MessageBox.Show("First Close the Door");
      else
      {
        var sd = new DoorRepository();
        await sd.LockDoor(int.Parse(dr.Id.ToString()));
      }
      MainWindow win = (MainWindow)Window.GetWindow(this);
      win.RelaodDoors();
    }

    private async void Button_Click_Close(object sender, RoutedEventArgs e)
    {
      var s = sender as System.Windows.Controls.Button;
      var dr = s.CommandParameter as DoorModel;
      if (!dr.IsOpen)
        MessageBox.Show("First open the Door");
      else
      {
        var sd = new DoorRepository();

        await sd.CloseDoor(int.Parse(dr.Id.ToString()));
      }
      MainWindow win = (MainWindow)Window.GetWindow(this);
      win.RelaodDoors();
    }

    private async void Button_Click_Unlock(object sender, RoutedEventArgs e)
    {
      var s = sender as System.Windows.Controls.Button;
      var dr = s.CommandParameter as DoorModel;
      if (dr.IsOpen && !dr.IsLock)
        MessageBox.Show("First Close and Lock the Door");
      else
      {
        var sd = new DoorRepository();
        await sd.UnlockDoor(int.Parse(dr.Id.ToString()));
      }
      MainWindow win = (MainWindow)Window.GetWindow(this);
      win.RelaodDoors();
    }

    private async void Button_Click_Remove(object sender, RoutedEventArgs e)
    {
      var s = sender as System.Windows.Controls.Button;
      var dr = s.CommandParameter as DoorModel;

      var sd = new DoorRepository();
      await sd.RemoveDoor(int.Parse(dr.Id.ToString()));

      MainWindow win = (MainWindow)Window.GetWindow(this);
      win.RelaodDoors();
    }
  }
}
