using System.Text;
using System.Text.Json;

namespace ProHotel.Data;

public class RoomEntryService
{
	const string Url = "http://localhost:8080/v1/rooms";
	const string UrlRandom = "http://localhost:8080/v1/rooms_random";
	private SeasonJSON[] seasons;
	private int actualDiscount = 0;

	public RoomEntryService()
	{
		int actualMonth = DateTime.Now.Month;
		SeasonJSON? actualSeason = null;
		seasons = GetSeasons();
		foreach (var t in seasons)
		{
			if (actualMonth >= t.to.Month) continue;
			actualSeason = t;
			break;
		}

		actualDiscount = actualSeason?.price ?? 0;
	}

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
			res[i].PricePerDay *= (100.0f + actualDiscount) / 100.0f;
			res[i].PricePerDay = (float) Math.Round(res[i].PricePerDay, 2);
		}

		return Task.FromResult(res);
	}

	public Task<Room> GetRoom(int id)
	{
		string json = new HttpClient().GetStringAsync($"{Url}({id})").Result;
		var roomsJson = JsonSerializer.Deserialize<RoomJson>(json) ?? new RoomJson();
		var res = new Room(roomsJson);
		res.PricePerDay *= (100.0f + actualDiscount) / 100.0f;
		res.PricePerDay = (float) Math.Round(res.PricePerDay, 2);
		return Task.FromResult(res);
	}

	public Task<Room[]> GetRooms(SearchRoomJSON searchRoomJson)
	{
		using var client = new HttpClient();
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
			res[i].PricePerDay *= (100.0f + actualDiscount) / 100.0f;
			res[i].PricePerDay = (float) Math.Round(res[i].PricePerDay, 2);
		}

		return Task.FromResult(res);
	}

	public SeasonJSON[] GetSeasons()
	{
		using var client = new HttpClient();
		var endpoint = new Uri("http://localhost:8080/v1/seasons");

		var json = client.GetStringAsync(endpoint).Result;

		var seasonsJson = JsonSerializer.Deserialize<SeasonJSON[]>(json);
		if (seasonsJson == null)
			return Array.Empty<SeasonJSON>();
		return seasonsJson;
	}
}