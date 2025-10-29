using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;

namespace OOP_KOD
{
    public static class SeedData
    {
        public static List<Event> CreateEvents()
        {
            var seats = new List<Seat>
            {
                new Seat(1, 1, 1, SeatType.FOLDING, 250),
                new Seat(2, 1, 2, SeatType.FOLDING, 250),
                new Seat(3, 1, 3, SeatType.LUXURY_BOX, 500),
                new Seat(4, 2, 1, SeatType.BENCH, 175),
                new Seat(5, 2, 2, SeatType.BENCH, 175)
            };

            var arenas = new List<Arena>
            {
                new Arena(10, "Stora Arenan", "Betong", seats),
                new Arena(8,  "Lilla Arenan", "Trä",    seats)
            };

            var events = new List<Event>
            {
                new Event(100, "Rock Night",      "The Codes",      DateTime.Today.AddDays(7),  arenas[0], true),
                new Event(101, "Pop Explosion",   "Neon Lights",    DateTime.Today.AddDays(10), arenas[1], true),
                new Event(102, "Metal Madness",   "Iron Fist",      DateTime.Today.AddDays(14), arenas[0], true),
                new Event(103, "Summer Beats",    "DJ Sunrise",     DateTime.Today.AddDays(21), arenas[1], true),
                new Event(104, "Classic Evening", "The Symphonics", DateTime.Today.AddDays(30), arenas[0], false),
                new Event(105, "Indie Vibes",     "The Echoes",     DateTime.Today.AddDays(45), arenas[1], true)
            };

            return events;
        }
    }
}

