namespace ProHotel.Data;

public class OptionEntryService
{
	public Task<Option[]> GetForecastAsync()
	{
		Option e1 = new();
		Option e2 = new();
		Option e3 = new();
		
		var tempList = new List<string>{"a","b","c"};

		e1.name = "Name1";
		e2.name = "Name2";
		e3.name = "Name3";

		e1.values = tempList;
		e2.values = tempList;
		e3.values = tempList;

		return Task.FromResult(new[] {e1, e2, e3});
	}
}