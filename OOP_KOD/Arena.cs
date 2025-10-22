using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_KOD;

public class Arena
{
    public int ArenaId { get; set; }
    public string Name { get; set; } = "";
    public string BuildingMaterial { get; set; } = "";
    public List<Seat> Seats { get; } = new();

    public Arena() { }

    public Arena(int arenaId, string name, string buildingMaterial, IEnumerable<Seat>? seats = null)
    {
        ArenaId = arenaId;
        Name = name ?? "";
        BuildingMaterial = buildingMaterial ?? "";
        if (seats != null) Seats.AddRange(seats);
    }

    public void ShowSeatingChart()
    {
        Console.WriteLine($"Platskarta för {Name}:");
        foreach (var seat in Seats.OrderBy(s => s.RowNumber).ThenBy(s => s.SeatNumber))
        {
            Console.WriteLine($"  {seat} – Färg: {seat.GetColor()}");
        }
    }

    public List<Seat> GetAvailableSeats()
        => Seats.Where(s => s.Status == SeatStatus.Available).ToList();

    public void AddSeat(Seat seat)
    {
        if (seat == null)
        {
            Console.WriteLine("Kan inte lägga till en null-plats.");
            return;
        }

        if (Seats.Any(s => s.SeatId == seat.SeatId))
        {
            Console.WriteLine($"Plats med id {seat.SeatId} finns redan.");
            return;
        }

        Seats.Add(seat);
        Console.WriteLine($"Plats lades till: Rad {seat.RowNumber}, Plats {seat.SeatNumber}.");
    }
}
