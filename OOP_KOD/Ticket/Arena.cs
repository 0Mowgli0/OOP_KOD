using OOP_KOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_KOD
{
    // Klass som representerar en arena med sittplatser
    public class Arena
    {
        // Egenskaper för arenans ID, namn, byggmaterial och lista med sittplatser
        public int ArenaId { get; }
        public string Name { get; }
        public string BuildingMaterial { get; }
        public List<Seat> Seats { get; } = new();

        // Konstruktorn skapar en ny arena och kan ta emot en lista med sittplatser
        public Arena(int arenaId, string name, string buildingMaterial, IEnumerable<Seat>? seats = null)
        {
            ArenaId = arenaId;
            Name = name;
            BuildingMaterial = buildingMaterial;
            if (seats != null) Seats.AddRange(seats);
        }

        // Hämtar alla lediga sittplatser
        public IEnumerable<Seat> GetFreeSeats() => Seats.Where(s => s.Status == SeatStatus.FREE);

        // Hittar en specifik sittplats utifrån dess ID
        public Seat? FindSeat(int seatId) => Seats.FirstOrDefault(s => s.SeatId == seatId);

        // Skapar en enkel textkarta över alla sittplatser rad för rad
        public string GetSeatMap()
        {
            var byRow = Seats
                .GroupBy(s => s.RowNumber)
                .OrderBy(g => g.Key)
                .Select(g => $"Rad {g.Key}: " + string.Join(", ", g.OrderBy(s => s.SeatNumber).Select(s => $"{s.SeatNumber}-{s.Status}")));
            return string.Join(System.Environment.NewLine, byRow);
        }
    }
}
