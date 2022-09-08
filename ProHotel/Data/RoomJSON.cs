public class RoomsJson
{
	public RoomJson[] rooms { get; set; }
}

public class RoomJson
{
	public Addons? addons { get; set; }
	public int? area { get; set; }
	public int? bed_count_1p { get; set; }
	public int? bed_count_2p { get; set; }
	public int? bed_count_c { get; set; }
	public int? capacity { get; set; }
	public Image[]? images { get; set; }
	public int? price { get; set; }
	public int? room_number { get; set; }
	public string? variant { get; set; }
}

public class Addons
{
	public bool? balcony { get; set; }
	public bool? bath { get; set; }
	public bool? coffee { get; set; }
	public bool? desk { get; set; }
	public bool? disabled_accessible { get; set; }
	public bool? fridge { get; set; }
	public bool? kids_beds { get; set; }
	public bool? kitchen { get; set; }
	public bool? laundry { get; set; }
	public bool? safe { get; set; }
	public bool? sightseeing { get; set; }
	public bool? sofa { get; set; }
	public bool? tea { get; set; }
	public bool? toilet { get; set; }
	public bool? tv { get; set; }
	public bool? washing_mashine { get; set; }
}

public class Image
{
	public string? image_content { get; set; }
	public string? image_name { get; set; }
}