using System.Net;
using System.Text.Json;

namespace ProHotel.Data;

public class Room
{
	public string? ImageUrl {get; set;}
	public string? Name {get; set;}
	public float? Space {get; set;}
	public int? Seats {get; set;}
	public int? Beds {get; set;}
	public bool? Breakfast {get; set;}
	public string? Variant {get; set;}
	public float? PricePerDay {get; set;}

	public Room(string imageUrl = null, string name = null, float space = default, int seats = default,
		int beds = default, bool breakfast = default, string variant = null, float pricePerDay = default)
	{
		this.ImageUrl = imageUrl;
		this.Name = name;
		this.Space = space;
		this.Seats = seats;
		this.Beds = beds;
		this.Breakfast = breakfast;
		this.Variant = variant;
		this.PricePerDay = pricePerDay;
	}

	public Room()
	{
		this.ImageUrl = "images/pic.jpg";
		this.Name = "Dupa";
		this.Space = 69.0f;
		this.Seats = 4;
		this.Beds = 2;
		this.Breakfast = false;
		this.Variant = "Twoja stara";
		this.PricePerDay = 420.0f;
	}
	// public static Task<Room[]> getRooms()
	// {
	// 	String URL = "http://localhost:8080/v1/rooms";
	// 	String json = new WebClient().DownloadString(URL);
	// 	RoomsJson? roomsJson = JsonSerializer.Deserialize<RoomsJson>(json);
	// 	int size = roomsJson.rooms.Length;
	// 	Room[] res = new Room[size];
	// 	for (int i = 0; i < size; ++i)
	// 	{
	// 		RoomJson roomJson = roomsJson.rooms[i];
	// 		res[i] = new Room(roomJson.images[0].image_content, roomJson.room_number.ToString(), roomJson.area,
	// 			roomJson.bed_count_1p, roomJson.bed_count_2p, roomJson.addons.tv, roomJson.variant, roomJson.price);
	// 	}
	//
	// 	Console.WriteLine("CHUJ");
	// 	Console.WriteLine(res);
	// 	return Task.FromResult(res);
	// }
}