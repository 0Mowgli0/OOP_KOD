using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_KOD;

public class Event
{
    public int EventId { get; set; }
    public string Name { get; set; } = "";
    public string Artist { get; set; } = "";
    public DateTime Date { get; set; }
    public Arena Arena { get; set; } = new();
    public bool IsIndoors { get; set; }

    public void ShowDetails()
    {
        Console.WriteLine("Evenemangsdetaljer:");
        Console.WriteLine($"  Namn: {Name}");
        Console.WriteLine($"  Artist: {Artist}");
        Console.WriteLine($"  Datum: {Date:yyyy-MM-dd HH:mm}");
        Console.WriteLine($"  Arena: {Arena.Name}");
        Console.WriteLine($"  Inomhus: {(IsIndoors ? "ja" : "nej")}");
    }

    public List<Seat> GetAvailableSeats()
        => Arena.GetAvailableSeats();
}