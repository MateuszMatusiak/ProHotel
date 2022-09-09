
public class SearchRoomJSON
{
public int area_from { get; set; }
public int area_to { get; set; }
public bool balcony { get; set; }
public bool bath { get; set; }
public int bed_count_1p_from { get; set; }
public int bed_count_1p_to { get; set; }
public int bed_count_2p_from { get; set; }
public int bed_count_2p_to { get; set; }
public int bed_count_c_from { get; set; }
public int bed_count_c_to { get; set; }
public int capacity_from { get; set; }
public int capacity_to { get; set; }
public bool coffee { get; set; }
public string date_from { get; set; }
public string date_to { get; set; }
public bool desk { get; set; }
public bool disabled_accessible { get; set; }
public bool fridge { get; set; }
public bool iron { get; set; }
public bool kids_beds { get; set; }
public bool kitchen { get; set; }
public bool laundry { get; set; }
public float price_from { get; set; }
public float price_to { get; set; }
public bool safe { get; set; }
public bool sightseeing { get; set; }
public bool sofa { get; set; }
public bool tea { get; set; }
public bool toilet { get; set; }
public bool tv { get; set; }
public string variant { get; set; }
public bool washing_mashine { get; set; }

public SearchRoomJSON(int areaFrom, int areaTo, bool balcony, bool bath, int bedCount1PFrom, int bedCount1PTo, int bedCount2PFrom, int bedCount2PTo, int bedCountCFrom, int bedCountCTo, int capacityFrom, int capacityTo, bool coffee, string dateFrom, string dateTo, bool desk, bool disabledAccessible, bool fridge, bool iron, bool kidsBeds, bool kitchen, bool laundry, float priceFrom, float priceTo, bool safe, bool sightseeing, bool sofa, bool tea, bool toilet, bool tv, string variant, bool washingMashine)
{
	area_from = areaFrom;
	area_to = areaTo;
	this.balcony = balcony;
	this.bath = bath;
	bed_count_1p_from = bedCount1PFrom;
	bed_count_1p_to = bedCount1PTo;
	bed_count_2p_from = bedCount2PFrom;
	bed_count_2p_to = bedCount2PTo;
	bed_count_c_from = bedCountCFrom;
	bed_count_c_to = bedCountCTo;
	capacity_from = capacityFrom;
	capacity_to = capacityTo;
	this.coffee = coffee;
	date_from = dateFrom;
	date_to = dateTo;
	this.desk = desk;
	disabled_accessible = disabledAccessible;
	this.fridge = fridge;
	this.iron = iron;
	kids_beds = kidsBeds;
	this.kitchen = kitchen;
	this.laundry = laundry;
	price_from = priceFrom;
	price_to = priceTo;
	this.safe = safe;
	this.sightseeing = sightseeing;
	this.sofa = sofa;
	this.tea = tea;
	this.toilet = toilet;
	this.tv = tv;
	this.variant = variant;
	washing_mashine = washingMashine;
}
}
