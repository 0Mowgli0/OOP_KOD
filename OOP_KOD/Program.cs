using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_KOD
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            // Skapa platser
            var seats = new List<Seat>
            {
                new Seat(1, 1, 1, SeatType.FOLDING, 250),
                new Seat(2, 1, 2, SeatType.FOLDING, 250),
                new Seat(3, 1, 3, SeatType.LUXURY_BOX, 500),
                new Seat(4, 2, 1, SeatType.BENCH, 175),
                new Seat(5, 2, 2, SeatType.BENCH, 175)
            };

            // Arena + Event
            var arena = new Arena(10, "Stora Arenan", "Betong", seats);
            var evt = new Event(100, "Rock Night", "The Codes", DateTime.Today.AddDays(7), arena, true);



            while (true)
            {
                Console.WriteLine("\n=== Test: Arena / Plats / Event ===");
                Console.WriteLine("1) Visa platskarta");
                Console.WriteLine("2) Lista lediga platser");
                Console.WriteLine("3) Reservera plats via ID");
                Console.WriteLine("4) Frigör plats via ID");
                Console.WriteLine("5) Visa eventdetaljer");
                Console.WriteLine("0) Avsluta");
                Console.Write("Välj: ");
                var choice = Console.ReadLine();
                Console.WriteLine();

                if (choice == "0") break;

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Platskarta (status):");
                        Console.WriteLine(arena.GetSeatMap());
                        break;

                    case "2":
                        var free = evt.GetAvailableSeats()
                                      .OrderBy(s => s.RowNumber)
                                      .ThenBy(s => s.SeatNumber).ToList();
                        if (free.Count == 0) Console.WriteLine("Inga lediga platser.");
                        else
                        {
                            Console.WriteLine("Lediga platser:");
                            foreach (var s in free)
                                Console.WriteLine($"ID:{s.SeatId} — Rad {s.RowNumber}, Plats {s.SeatNumber} ({s.Type}) – {s.Status} – färg:{s.GetColor()}");
                        }
                        break;

                    case "3":
                        Console.Write("Ange plats-ID att reservera: ");
                        if (!int.TryParse(Console.ReadLine(), out var reserveId))
                        { Console.WriteLine("Ogiltigt ID."); break; }

                        var seatToReserve = arena.FindSeat(reserveId);
                        if (seatToReserve == null) Console.WriteLine("Hittar ingen plats med det ID:t.");
                        else
                        {
                            Console.WriteLine(seatToReserve.Reserve()
                                ? "Reservering lyckades."
                                : "Kunde inte reservera (inte ledig).");
                            Console.WriteLine("Uppdaterad platskarta:");
                            Console.WriteLine(arena.GetSeatMap());
                        }
                        break;

                    case "4":
                        Console.Write("Ange plats-ID att frigöra: ");
                        if (!int.TryParse(Console.ReadLine(), out var releaseId))
                        { Console.WriteLine("Ogiltigt ID."); break; }

                        var seatToRelease = arena.FindSeat(releaseId);
                        if (seatToRelease == null) Console.WriteLine("Hittar ingen plats med det ID:t.");
                        else
                        {
                            seatToRelease.Release();
                            Console.WriteLine("Platsen är frigjord.");
                            Console.WriteLine("Uppdaterad platskarta:");
                            Console.WriteLine(arena.GetSeatMap());
                        }
                        break;

                    case "5":
                        Console.WriteLine("Event:");
                        Console.WriteLine(evt.ShowDetails());
                        Console.WriteLine($"Inomhus: {(evt.IsIndoors ? "ja" : "nej")}");
                        break;

                    default:
                        Console.WriteLine("Okänt val.");
                        break;
                }
            }

            Console.WriteLine("\nHej då!");
        }
    }
}
