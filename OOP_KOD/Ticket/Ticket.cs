using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_KOD
{
    // Klass som representerar en biljett till ett event
    public class Ticket
    {
        // Egenskaper för biljettens ID, event, sittplats, köptid och eventuell prissättningsstrategi
        public int TicketId { get; }
        public Event Event { get; }
        public Seat Seat { get; }
        public DateTime PurchaseDate { get; private set; }
        public IPriceStrategy? PriceStrategy { get; set; }

        // Om ingen prissättningsstrategi finns används sittplatsens grundpris
        public double Price => PriceStrategy?.CalculatePrice() ?? Seat.BasePrice;

        // Konstruktorn skapar en biljett och kan ta emot en valfri prissättningsstrategi
        public Ticket(int ticketId, Event @event, Seat seat, IPriceStrategy? priceStrategy = null)
        {
            TicketId = ticketId;
            Event = @event;
            Seat = seat;
            PriceStrategy = priceStrategy;
        }

        // Returnerar biljettens pris
        public double CalculatePrice() => Price;

        // Genererar en textbaserad e-biljett och sätter inköpsdatumet till nuvarande tid
        public string GenerateETicket()
        {
            PurchaseDate = DateTime.Now;
            return $"EBILJETT #{TicketId}: {Event.ShowDetails()} — Rad {Seat.RowNumber}, Plats {Seat.SeatNumber} — Pris: {Price:0.00} kr";
        }
    }
}
