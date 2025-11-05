using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace OOP_KOD
{
    // Hanterar sitskarta, lediga platser och bokningsåtgärder för ett event
    public class EventManager
    {
        public string GetSeatMap(Event evt) => evt.Arena.GetSeatMap();

        public List<Seat> GetFreeSeats(Event evt) =>
            evt.GetAvailableSeats()
               .OrderBy(s => s.RowNumber)
               .ThenBy(s => s.SeatNumber)
               .ToList();

        // Försök reservera en plats; returnera true om lyckad
        public bool ReserveSeat(Event evt, int seatId)
        {
            var seat = evt.Arena.FindSeat(seatId);
            return seat != null && seat.Reserve();
        }

        // Frigör en plats
        public bool ReleaseSeat(Event evt, int seatId)
        {
            var seat = evt.Arena.FindSeat(seatId);
            if (seat == null) return false;
            seat.Release();
            return true;
        }

        // Hämta detaljer för ett event
        public string GetEventDetails(Event evt) => evt.ShowDetails();
    }
}
