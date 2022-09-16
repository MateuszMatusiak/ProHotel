using System.Text;
using System.Text.Json;

namespace ProHotel.Data;

public class RoomEntryService
{
	const string Url = "http://localhost:8080/v1/rooms";
	const string UrlRandom = "http://localhost:8080/v1/rooms_random";

	public Task<Room[]> GetRooms(bool random = false)
	{
		string json = new HttpClient().GetStringAsync(random ? UrlRandom : Url).Result;

		var roomsJson = JsonSerializer.Deserialize<RoomJson[]>(json);
		if (roomsJson == null)
			return Task.FromResult(Array.Empty<Room>());

		int size = roomsJson.Length;
		var res = new Room[size];
		for (int i = 0; i < size; ++i)
		{
			res[i] = new Room(roomsJson[i]);
		}

		return Task.FromResult(res);
	}

	public Task<Room> GetRoom(int id)
	{
		string json = new HttpClient().GetStringAsync($"{Url}({id})").Result;
		var roomsJson = JsonSerializer.Deserialize<RoomJson>(json) ?? new RoomJson();
		return Task.FromResult(new Room(roomsJson));
	}

    public Task<Room[]> GetRooms(SearchRoomJSON searchRoomJson)
    {
        using (var client = new HttpClient())
        {
            Console.WriteLine("4: " + searchRoomJson);
            var endpoint = new Uri("http://localhost:8080/v1/free");
            var newPostJson = JsonSerializer.Serialize(searchRoomJson);
            
            
            var payLoad = new StringContent(newPostJson, Encoding.UTF8, "application/json");
            var json = client.PostAsync(endpoint, payLoad).Result.Content.ReadAsStringAsync().Result;
            
            var roomsJson = JsonSerializer.Deserialize<RoomJson[]>(json);
            if (roomsJson == null)
                return Task.FromResult(Array.Empty<Room>());

            int size = roomsJson.Length;
            var res = new Room[size];
            for (int i = 0; i < size; ++i)
            {
                res[i] = new Room(roomsJson[i]);
            }

            return Task.FromResult(res);
            
        }
    }
}