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
}
