using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_KOD
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            // === Skapa platser (exempeldata) ===
            var seats = new List<Seat>
            {
                new Seat(1, 1, 1, SeatType.FOLDING, 250),
                new Seat(2, 1, 2, SeatType.FOLDING, 250),
                new Seat(3, 1, 3, SeatType.LUXURY_BOX, 500),
                new Seat(4, 2, 1, SeatType.BENCH, 175),
                new Seat(5, 2, 2, SeatType.BENCH, 175)
            };

            // === Arenor ===
            var arenas = new List<Arena>
            {
                new Arena(10, "Stora Arenan", "Betong", seats),
                new Arena(8,  "Lilla Arenan", "Trä",    seats)
            };

            // === Event (kopplade till ovan arenor) ===
            var events = new List<Event>
            {
                new Event(100, "Rock Night",      "The Codes",      DateTime.Today.AddDays(7),  arenas[0], true),
                new Event(101, "Pop Explosion",   "Neon Lights",    DateTime.Today.AddDays(10), arenas[1], true),
                new Event(102, "Metal Madness",   "Iron Fist",      DateTime.Today.AddDays(14), arenas[0], true),
                new Event(103, "Summer Beats",    "DJ Sunrise",     DateTime.Today.AddDays(21), arenas[1], true),
                new Event(104, "Classic Evening", "The Symphonics", DateTime.Today.AddDays(30), arenas[0], false),
                new Event(105, "Indie Vibes",     "The Echoes",     DateTime.Today.AddDays(45), arenas[1], true)
            };

            // =========================
            // YTTRE LOOP: välj event
            // =========================
            while (true)
            {
                Console.WriteLine("\n=== Välj event (0 = avsluta) ===");
                for (int i = 0; i < events.Count; i++)
                {
                    Console.WriteLine($"{i + 1}) {events[i].Name} @ {events[i].Arena.Name} ({events[i].Date:yyyy-MM-dd})");
                }
                Console.Write("Val: ");
                var evtInput = Console.ReadLine();

                if (evtInput == "0")
                    break; // avsluta hela programmet

                if (!int.TryParse(evtInput, out int eventNum) || eventNum < 1 || eventNum > events.Count)
                {
                    Console.WriteLine("Ogiltigt val.");
                    continue; // stanna i yttre menyn
                }

                var currentEvent = events[eventNum - 1];
                var currentArena = currentEvent.Arena;

                // =========================
                // INRE LOOP: jobba i valt event
                // =========================
                while (true)
                {
                    Console.WriteLine($"\n=== {currentEvent.Name} @ {currentArena.Name} ===");
                    Console.WriteLine("1) Visa platskarta");
                    Console.WriteLine("2) Lista lediga platser");
                    Console.WriteLine("3) Reservera plats via ID");
                    Console.WriteLine("4) Frigör plats via ID");
                    Console.WriteLine("5) Visa eventdetaljer");
                    Console.WriteLine("9) Byt event (tillbaka)");
                    Console.WriteLine("0) Avsluta programmet");
                    Console.Write("Välj: ");
                    var choice = Console.ReadLine();
                    Console.WriteLine();

                    if (choice == "0") return;      // avsluta helt
                    if (choice == "9") break;        // tillbaka till yttre loop (byt event)

                    switch (choice)
                    {
                        case "1":
                            Console.WriteLine("Platskarta (status):");
                            Console.WriteLine(currentArena.GetSeatMap());
                            break;

                        case "2":
                            var free = currentEvent.GetAvailableSeats()
                                                   .OrderBy(s => s.RowNumber)
                                                   .ThenBy(s => s.SeatNumber)
                                                   .ToList();
                            if (free.Count == 0)
                            {
                                Console.WriteLine("Inga lediga platser.");
                            }
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
                            {
                                Console.WriteLine("Ogiltigt ID.");
                                break;
                            }

                            var seatToReserve = currentArena.FindSeat(reserveId);
                            if (seatToReserve == null)
                            {
                                Console.WriteLine("Hittar ingen plats med det ID:t.");
                            }
                            else
                            {
                                Console.WriteLine(seatToReserve.Reserve()
                                    ? "Reservering lyckades."
                                    : "Kunde inte reservera (inte ledig).");
                                Console.WriteLine("Uppdaterad platskarta:");
                                Console.WriteLine(currentArena.GetSeatMap());
                            }
                            break;

                        case "4":
                            Console.Write("Ange plats-ID att frigöra: ");
                            if (!int.TryParse(Console.ReadLine(), out var releaseId))
                            {
                                Console.WriteLine("Ogiltigt ID.");
                                break;
                            }

                            var seatToRelease = currentArena.FindSeat(releaseId);
                            if (seatToRelease == null)
                            {
                                Console.WriteLine("Hittar ingen plats med det ID:t.");
                            }
                            else
                            {
                                seatToRelease.Release();
                                Console.WriteLine("Platsen är frigjord.");
                                Console.WriteLine("Uppdaterad platskarta:");
                                Console.WriteLine(currentArena.GetSeatMap());
                            }
                            break;

                        case "5":
                            Console.WriteLine("Eventdetaljer:");
                            Console.WriteLine(currentEvent.ShowDetails());
                            Console.WriteLine($"Inomhus: {(currentEvent.IsIndoors ? "ja" : "nej")}");
                            break;

                        default:
                            Console.WriteLine("Okänt val.");
                            break;
                    }
                }
                // hit kommer man när man valt "9) Byt event (tillbaka)"
            }

            Console.WriteLine("\nHej då!");
        }
    }
}
