using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_KOD
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public Event Event { get; set; }
        public Seat Seat { get; set; }
        public double Price { get; private set; }
        public DateTime PurchaseDate { get; private set; }

        public Ticket(int ticketId, Event evt, Seat seat)
        {
            TicketId = ticketId;
            Event = evt;
            Seat = seat;
            PurchaseDate = DateTime.Now;
        }

        // UML: beräknaPris()
        public double CalculatePrice()
        {
            // Ingen strategi i UML: använd baspris från platsen rakt av.
            Price = Seat.BasePrice;
            return Price;
        }

        // UML: genereraEBiljett()
        public void GenerateETicket()
        {
            Console.WriteLine("E-biljett genererad:");
            Console.WriteLine($"  Biljett-ID: {TicketId}");
            Console.WriteLine($"  Köpt: {PurchaseDate:yyyy-MM-dd HH:mm}");
            Console.WriteLine($"  Evenemang: {Event.Name} – {Event.Artist}");
            Console.WriteLine($"  Datum: {Event.Date:yyyy-MM-dd HH:mm}");
            Console.WriteLine($"  Arena: {Event.Arena.Name}");
            Console.WriteLine($"  Plats: Rad {Seat.RowNumber}, Plats {Seat.SeatNumber}");
            Console.WriteLine($"  Pris: {Price:C}");
        }
    }
}
