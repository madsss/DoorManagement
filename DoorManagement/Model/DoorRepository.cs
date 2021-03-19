
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DoorManagement.Model
{
  public class DoorRepository
  {
    public List<DoorModel> PopulateDoorModels()
    {
      List<DoorModel> items = new List<DoorModel>();
      HttpClient client = new HttpClient();
      client.BaseAddress = new Uri("http://localhost:8662/");

      var responseTask = client.GetAsync("Doors/AllDoors");
      responseTask.Wait();

      var result = responseTask.Result;
      if (result.IsSuccessStatusCode)
      {
        string drs = result.Content.ReadAsStringAsync().Result;
        var s = JsonConvert.DeserializeObject<DoorModel[]>(drs);

        foreach (var d in s)
        {
          items.Add(d);
        }
      }

      return items;
    }

    public async Task OpenDoor(int id)
    {
      var apiBasicUri = "http://localhost:8662/";
      using (var client = new HttpClient())
      {
        client.BaseAddress = new Uri(apiBasicUri);
        var content = new StringContent(JsonConvert.SerializeObject(id), Encoding.UTF8, "application/json");
        var result = await client.PostAsync("Doors/OpenDoor", content);
        result.EnsureSuccessStatusCode();
      }
    }

    public async Task CloseDoor(int id)
    {
      var apiBasicUri = "http://localhost:8662/";
      using (var client = new HttpClient())
      {
        client.BaseAddress = new Uri(apiBasicUri);
        var content = new StringContent(JsonConvert.SerializeObject(id), Encoding.UTF8, "application/json");
        var result = await client.PostAsync("Doors/CloseDoor", content);
        result.EnsureSuccessStatusCode();
      }
    }
    public async Task UnlockDoor(int id)
    {
      var apiBasicUri = "http://localhost:8662/";
      using (var client = new HttpClient())
      {
        client.BaseAddress = new Uri(apiBasicUri);
        var content = new StringContent(JsonConvert.SerializeObject(id), Encoding.UTF8, "application/json");
        var result = await client.PostAsync("Doors/UnlockDoor", content);
        result.EnsureSuccessStatusCode();
      }
    }

    public async Task RemoveDoor(int id)
    {
      var apiBasicUri = "http://localhost:8662/";
      using (var client = new HttpClient())
      {
        client.BaseAddress = new Uri(apiBasicUri);
        var content = new StringContent(JsonConvert.SerializeObject(id), Encoding.UTF8, "application/json");
        var result = await client.PostAsync("Doors/RemoveDoor", content);
        result.EnsureSuccessStatusCode();
      }
    }
    public async Task LockDoor(int id)
    {
      var apiBasicUri = "http://localhost:8662/";

      using (var client = new HttpClient())
      {
        client.BaseAddress = new Uri(apiBasicUri);
        var content = new StringContent(JsonConvert.SerializeObject(id), Encoding.UTF8, "application/json");
        var result = await client.PostAsync("Doors/LockDoor", content);
        result.EnsureSuccessStatusCode();
      }

    }

    public async Task CreateDoor(string name)
    {
      var apiBasicUri = "http://localhost:8662/";

      using (var client = new HttpClient())
      {
        client.BaseAddress = new Uri(apiBasicUri);
        var content = new StringContent(JsonConvert.SerializeObject(name), Encoding.UTF8, "application/json");
        var result = await client.PostAsync("Doors/CreateDoor", content);
        result.EnsureSuccessStatusCode();
      }


    }
  }
}
