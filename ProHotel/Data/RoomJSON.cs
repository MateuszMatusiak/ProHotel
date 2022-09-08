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
	public bool? balcony { get; set; } = false;
	public bool? bath { get; set; } = false;
	public bool? coffee { get; set; } = false;
	public bool? desk { get; set; } = false;
	public bool? disabled_accessible { get; set; } = false;
	public bool? fridge { get; set; } = false;
	public bool? kids_beds { get; set; } = false;
	public bool? kitchen { get; set; } = false;
	public bool? laundry { get; set; } = false;
	public bool? safe { get; set; } = false;
	public bool? sightseeing { get; set; } = false;
	public bool? sofa { get; set; } = false;
	public bool? tea { get; set; } = false;
	public bool? toilet { get; set; } = false;
	public bool? tv { get; set; } = false;
	public bool? washing_mashine { get; set; } = false;

    public List<(string name, bool value)> GetAddons()
    {
        var props = GetType().GetProperties();
        var addons = new List<(string name, bool value)>();
        foreach (var prop in props)
        {
            bool value = (bool)prop.GetValue(this)!;
            if (value == false)
                continue;
            string name = prop.Name;
            addons.Add((name, value));
        }
        return addons;
    }
}

public class Image
{
	public string? image_content { get; set; }
	public string? image_name { get; set; }
}