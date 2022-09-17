
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json;
namespace ProHotel.Data;

public class ReservationService
{
    const string Url = "http://localhost:8080/v1/reserve(1)";
    HttpClient client = new();
    
    public Task<Reservation> GetReservationsAsync(ReservationData data)
    {
        Console.WriteLine("GetReservationsAsync");
        var jsonData = JsonSerializer.Serialize(data);
        Console.WriteLine(jsonData);
        var payLoad = new StringContent(jsonData, Encoding.UTF8, "application/json");
        Console.WriteLine(payLoad);
        var json = client.PostAsync(Url, payLoad).Result.Content.ReadAsStringAsync().Result;
        
        Console.WriteLine(json);
        var reservation = JsonSerializer.Deserialize<Reservation>(json);
        
        return Task.FromResult(reservation ?? new Reservation());
    }
    
    public record Reservation
    {
        
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