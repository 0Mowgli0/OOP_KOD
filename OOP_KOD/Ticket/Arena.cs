using OOP_KOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_KOD
{
    public class Arena
    {
        public int ArenaId { get; }
        public string Name { get; }
        public string BuildingMaterial { get; }
        public List<Seat> Seats { get; } = new();


        public Arena(int arenaId, string name, string buildingMaterial, IEnumerable<Seat>? seats = null)
        {
            ArenaId = arenaId;
            Name = name;
            BuildingMaterial = buildingMaterial;
            if (seats != null) Seats.AddRange(seats);
        }


        public IEnumerable<Seat> GetFreeSeats() => Seats.Where(s => s.Status == SeatStatus.FREE);
        public Seat? FindSeat(int seatId) => Seats.FirstOrDefault(s => s.SeatId == seatId);


        public string GetSeatMap()
        {
            // Enkel textkarta rad för rad
            var byRow = Seats
            .GroupBy(s => s.RowNumber)
            .OrderBy(g => g.Key)
            .Select(g => $"Rad {g.Key}: " + string.Join(", ", g.OrderBy(s => s.SeatNumber).Select(s => $"{s.SeatNumber}-{s.Status}")));
            return string.Join(System.Environment.NewLine, byRow);
        }
    }
}
