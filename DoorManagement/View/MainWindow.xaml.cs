using DoorManagement.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DoorManagement
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    ObservableCollection<DoorModel> items = new ObservableCollection<DoorModel>();

    public MainWindow()
    {
      InitializeComponent();
      items.Clear();
      PopulateDataItems();
      doorListView.ItemsSource = items;
    }

    private void btnLoadData_Click(object sender, RoutedEventArgs e)
    {
      // Reset the doors Collection
      items.Clear();
      // Populate the doors Collection
      PopulateDataItems();
      // Bind the doors Collection to the List Box
      doorListView.ItemsSource = items;
    }

    public void RelaodDoors()
    {
      // Reset the doors Collection
      items.Clear();
      // Populate the doors Collection
      PopulateDataItems();
      // Bind the doors Collection to the List Box
      doorListView.ItemsSource = items;
    }

    private void btnAddDoor_Click(object sender, RoutedEventArgs e)
    {
      var dname = NewDoorName.Text;
      var ad = new DoorRepository();
      var c = ad.CreateDoor(dname);
      NewDoorName.Text = string.Empty;
      RelaodDoors();
    }

    private void PopulateDataItems()
    {
      var ad = new DoorRepository();
      var c = ad.PopulateDoorModels();
      foreach (var i in c)
        items.Add(i);
    }

  }

}

