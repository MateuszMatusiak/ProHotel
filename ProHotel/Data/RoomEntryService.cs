using System.Net;
using System.Text.Json;

namespace ProHotel.Data;

public class RoomEntryService
{
	public Task<Room[]> GetRooms()
	{
		String URL = "http://localhost:8080/v1/rooms";
		String json = new WebClient().DownloadString(URL).Trim();
		Console.WriteLine(json);
		
		RoomJson[]? roomsJson = JsonSerializer.Deserialize<RoomJson[]>(json);
		int size = roomsJson.Length;
		Room[] res = new Room[size];
		for (int i = 0; i < size; ++i)
		{
			RoomJson roomJson = roomsJson[i];
		// 	res[i] = new Room(roomJson.images[0].image_content, roomJson.room_number.ToString(), roomJson.area,
		// 		roomJson.bed_count_1p, roomJson.bed_count_2p, roomJson.addons.tv, roomJson.variant, roomJson.price);
		// }
			res[i] = new Room(roomJson.images[0].image_content, roomJson.room_number.ToString(), (float)roomJson.area,
				(int)roomJson.bed_count_1p, (int)roomJson.bed_count_2p, (bool)roomJson.addons.tv, (string)roomJson.variant, (float)roomJson.price);
		}
		return Task.FromResult(res);
	}
	
	// public async Task<Room[]> GetRooms()
	// {
	// 	using HttpClient client = new()
	// 	{
	// 		BaseAddress = new Uri("http://localhost:8080/v1")
	// 	};
	// 	try
	// 	{
	// 		var roomsJson = await client.GetStringAsync("/rooms");
	// 		Console.WriteLine("CHUJ");
	// 		Console.WriteLine(roomsJson);
	// 	}
	// 	catch (Exception e)
	// 	{
	// 		Console.WriteLine("CHUJ W DUPIE CHLUPIE");
	// 	}

		
		// if (roomsJson != null)
		// {
			// int size = roomsJson.rooms.Length;
			// Room[] res = new Room[size];
			// for (int i = 0; i < size; ++i)
			// {
			// 	RoomJson roomJson = roomsJson.rooms[i];
			// 	res[i] = new Room(roomJson.images[0].image_content, roomJson.room_number.ToString(), (float)roomJson.area,
			// 		(int)roomJson.bed_count_1p, (int)roomJson.bed_count_2p, (bool)roomJson.addons.tv, (string)roomJson.variant, (float)roomJson.price);
			// }
			//
			// return await Task.FromResult(res);
		// }

	// 	return null;
	// }
}