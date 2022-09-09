namespace ProHotel.Data;

public class Room
{
	public string ImageUrl { get; set; }
	public string RoomNumber { get; set; }
	public float Space { get; set; }
	public int Beds1Person { get; set; }
	public int Beds2Person { get; set; }
	public int BedsChildren { get; set; }
	public int Beds { get; set; }
	public string Variant { get; set; }
	public float PricePerDay { get; set; }
	public List<string> Addons { get; set; }

	public Room(RoomJson roomJson)
	{
		if(roomJson == null) return;

		ImageUrl = roomJson.images?[0].image_content ?? "";
		RoomNumber = roomJson.room_number?.ToString() ?? "";
		Space = roomJson.area ?? 0;
		Beds1Person = roomJson.bed_count_1p ?? 0;
		Beds2Person = roomJson.bed_count_2p ?? 0;
		BedsChildren = roomJson.bed_count_c ?? 0;
		Beds = Beds1Person + Beds2Person;
		Variant = roomJson.variant ?? "";
		PricePerDay = roomJson.price ?? 0;
		Addons = roomJson.addons?.GetAddons() ?? new List<string>();
	}
}