namespace ProHotel.Data;

public class Room
{
	public string ImageUrl {get; set;}
	public string Name {get; set;}
	public float Space {get; set;}
	public int Seats {get; set;}
	public int Beds {get; set;}
	public string Variant {get; set;}
	public float PricePerDay {get; set;}
    public Addons Addons { get; set; }

    public Room(RoomJson roomJson)
    {
        ImageUrl = roomJson.images?[0].image_content ?? "";
        Name = roomJson.room_number?.ToString() ?? "";
        Space = roomJson.area ?? 0;
        Seats = roomJson.bed_count_1p ?? 0;
        Beds = roomJson.bed_count_2p ?? 0;
        Variant = roomJson.variant ?? "";
        PricePerDay = roomJson.price ?? 0;
        Addons = roomJson.addons ?? new Addons();
    }
}