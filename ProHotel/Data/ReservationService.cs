
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json;
namespace ProHotel.Data;

public class ReservationService
{
    const string Url = "http://localhost:8080/v1/reserve(";
    HttpClient client = new();
    
    public Task<bool> GetReservationsAsync(ReservationData data)
    {
        var jsonData = JsonSerializer.Serialize(data);
        var payLoad = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var json = client.PutAsync($"{Url}{data.room_id})", payLoad).Result.Content.ReadAsStringAsync().Result;
        return Task.FromResult(json == "\"OK\"\n");
    }
    
    public class ClientId
    {
        public int? client_id { get; set; }
        [Required]
        public string? name { get; set; }
        [Required]
        public string? surname { get; set; }
        [Required]
        public double? telephone { get; set; }

        public static ClientId Empty => new ()
        {
            client_id = 1,
            name = "name",
            surname = "surname",
            telephone = 123456789
        };
    }

    public class ReservationData
    {
        public ClientId? client_id { get; set; }
        public string? from { get; set; }
        public int? room_id { get; set; }
        public string? to { get; set; }
        
        public static ReservationData Empty => new ReservationData()
        {
            client_id = ClientId.Empty,
            from = "01-01-2021",
            room_id = 1,
            to = "01-01-2021"
        };
    }
}