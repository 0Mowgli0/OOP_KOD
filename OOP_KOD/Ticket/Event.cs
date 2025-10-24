using OOP_KOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_KOD
{
    public class Event
    {
        public int EventId { get; }
        public string Name { get; }
        public string Artist { get; }
        public DateTime Date { get; }
        public Arena Arena { get; }
        public bool IsIndoors { get; }

        public Event(int eventId, string name, string artist, DateTime date, Arena arena, bool isIndoors)
        {
            EventId = eventId;
            Name = name;
            Artist = artist;
            Date = date;
            Arena = arena;
            IsIndoors = isIndoors;
        }

        public string ShowDetails()
            => $"{Name} – {Artist} ({Date:yyyy-MM-dd}) på {Arena.Name}";

        public IEnumerable<Seat> GetAvailableSeats()
            => Arena.GetFreeSeats();
    }
}
