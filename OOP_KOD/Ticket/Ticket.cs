using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_KOD
{

    public class Ticket
    {
        public int TicketId { get; }
        public Event Event { get; }
        public Seat Seat { get; }
        public DateTime PurchaseDate { get; private set; }
        public IPriceStrategy? PriceStrategy { get; set; }

        // Om PriceStrategy är null använder vi Seat.BasePrice
        public double Price => PriceStrategy?.CalculatePrice() ?? Seat.BasePrice;

        public Ticket(int ticketId, Event @event, Seat seat, IPriceStrategy? priceStrategy = null)
        {
            TicketId = ticketId;
            Event = @event;
            Seat = seat;
            PriceStrategy = priceStrategy;
        }

        public double CalculatePrice() => Price;

        public string GenerateETicket()
        {
            PurchaseDate = DateTime.Now;
            return $"EBILJETT #{TicketId}: {Event.ShowDetails()} — Rad {Seat.RowNumber}, Plats {Seat.SeatNumber} — Pris: {Price:0.00} kr";
        }
    }
}
