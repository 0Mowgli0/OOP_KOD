using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOP_KOD
{
    public class Menu
    {
        private readonly List<Event> _events;
        private readonly EventManager _manager = new EventManager();

        public Menu(List<Event> events) => _events = events;

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("\n=== Välj event (0 = avsluta) ===");
                for (int i = 0; i < _events.Count; i++)
                    Console.WriteLine($"{i + 1}) {_events[i].Name} @ {_events[i].Arena.Name} ({_events[i].Date:yyyy-MM-dd})");
                Console.Write("Val: ");
                var evtInput = Console.ReadLine();

                if (evtInput == "0") break;

                if (!int.TryParse(evtInput, out int eventNum) || eventNum < 1 || eventNum > _events.Count)
                {
                    Console.WriteLine("Ogiltigt val.");
                    continue;
                }

                var currentEvent = _events[eventNum - 1];
                EventLoop(currentEvent);
            }
        }

        private void EventLoop(Event currentEvent)
        {
            var currentArena = currentEvent.Arena;

            while (true)
            {
                Console.WriteLine($"\n=== {currentEvent.Name} @ {currentArena.Name} ===");
                Console.WriteLine("1) Visa platskarta");
                Console.WriteLine("2) Lista lediga platser");
                Console.WriteLine("3) Reservera plats via ID");
                Console.WriteLine("4) Avresarvera via ID");
                Console.WriteLine("5) Visa eventdetaljer");
                Console.WriteLine("6) Visa pris på evenemang");
                Console.WriteLine("9) Byt event (tillbaka)");
                Console.WriteLine("0) Avsluta programmet");
                Console.Write("Välj: ");
                var choice = Console.ReadLine();
                Console.WriteLine();

                if (choice == "0") Environment.Exit(0);
                if (choice == "9") break;

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Platskarta (status):");
                        Console.WriteLine(_manager.GetSeatMap(currentEvent));
                        break;

                    case "2":
                        var free = _manager.GetFreeSeats(currentEvent);
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
                        {
                            Console.WriteLine("Ogiltigt ID.");
                            break;
                        }
                        Console.WriteLine(_manager.ReserveSeat(currentEvent, reserveId)
                            ? "Reservering lyckades."
                            : "Kunde inte reservera (inte ledig/saknas).");
                        Console.WriteLine("Uppdaterad platskarta:");
                        Console.WriteLine(_manager.GetSeatMap(currentEvent));
                        break;

                    case "4":
                        Console.Write("Ange plats-ID att frigöra: ");
                        if (!int.TryParse(Console.ReadLine(), out var releaseId))
                        {
                            Console.WriteLine("Ogiltigt ID.");
                            break;
                        }
                        Console.WriteLine(_manager.ReleaseSeat(currentEvent, releaseId)
                            ? "Platsen är frigjord."
                            : "Hittar ingen plats med det ID:t.");
                        Console.WriteLine("Uppdaterad platskarta:");
                        Console.WriteLine(_manager.GetSeatMap(currentEvent));
                        break;

                    case "5":
                        Console.WriteLine("Eventdetaljer:");
                        Console.WriteLine(_manager.GetEventDetails(currentEvent));
                        Console.WriteLine($"Inomhus: {(currentEvent.IsIndoors ? "ja" : "nej")}");
                        break;

                    case "6": Console.WriteLine("Prisdetaljer:");


                    default:
                        Console.WriteLine("Okänt val.");
                        break;
                }
            }
        }
    }
}
