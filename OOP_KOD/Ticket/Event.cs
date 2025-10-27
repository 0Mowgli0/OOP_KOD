using OOP_KOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_KOD
{
    // Klass som representerar ett evenemang på en arena
    public class Event
    {
        // Egenskaper för eventets ID, namn, artist, datum, arena och om det är inomhus
        public int EventId { get; }
        public string Name { get; }
        public string Artist { get; }
        public DateTime Date { get; }
        public Arena Arena { get; }
        public bool IsIndoors { get; }

        // Konstruktorn skapar ett nytt event med angivna värden
        public Event(int eventId, string name, string artist, DateTime date, Arena arena, bool isIndoors)
        {
            EventId = eventId;
            Name = name;
            Artist = artist;
            Date = date;
            Arena = arena;
            IsIndoors = isIndoors;
        }

        // Returnerar en kort beskrivning av eventet
        public string ShowDetails()
            => $"{Name} – {Artist} ({Date:yyyy-MM-dd}) på {Arena.Name}";

        // Hämtar alla lediga sittplatser via arenan
        public IEnumerable<Seat> GetAvailableSeats()
            => Arena.GetFreeSeats();
    }
}
