using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace OOP_KOD
{
    public class EventManager
    {
        public string GetSeatMap(Event evt) => evt.Arena.GetSeatMap();

        public List<Seat> GetFreeSeats(Event evt) =>
            evt.GetAvailableSeats()
               .OrderBy(s => s.RowNumber)
               .ThenBy(s => s.SeatNumber)
               .ToList();

        public bool ReserveSeat(Event evt, int seatId)
        {
            var seat = evt.Arena.FindSeat(seatId);
            return seat != null && seat.Reserve();
        }

        public bool ReleaseSeat(Event evt, int seatId)
        {
            var seat = evt.Arena.FindSeat(seatId);
            if (seat == null) return false;
            seat.Release();
            return true;
        }

        public string GetEventDetails(Event evt) => evt.ShowDetails();
    }
}
