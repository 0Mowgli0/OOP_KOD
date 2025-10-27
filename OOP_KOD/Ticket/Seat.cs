using OOP_KOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_KOD
{
    // Klass som representerar en sittplats på arenan
    public class Seat
    {
        // Egenskaper för platsens ID, rad, nummer, typ, status och grundpris
        public int SeatId { get; }
        public int RowNumber { get; }
        public int SeatNumber { get; }
        public SeatType Type { get; }
        public SeatStatus Status { get; private set; } = SeatStatus.FREE;
        public double BasePrice { get; }

        // Konstruktorn skapar en ny sittplats med angivna värden
        public Seat(int seatId, int rowNumber, int seatNumber, SeatType type, double basePrice)
        {
            SeatId = seatId;
            RowNumber = rowNumber;
            SeatNumber = seatNumber;
            Type = type;
            BasePrice = basePrice;
        }

        // Försöker reservera platsen om den är ledig
        public bool Reserve()
        {
            if (Status != SeatStatus.FREE) return false;
            Status = SeatStatus.RESERVED;
            return true;
        }

        // Släpper platsen så att den blir ledig igen
        public void Release()
        {
            Status = SeatStatus.FREE;
        }

        /* 
        // Bokar platsen permanent (kommenterad bort – kan aktiveras vid behov)
        public void Book()
        {
            Status = SeatStatus.BOOKED;
        }
        */

        // Returnerar färg baserat på platsens status (används för konsol-/UI-visning)
        public string GetColor()
        {
            return Status switch
            {
                SeatStatus.FREE => "grön",
                SeatStatus.RESERVED => "gul",
                SeatStatus.BOOKED => "röd",
                _ => "grå"
            };
        }

        // Returnerar en textbeskrivning av platsen
        public override string ToString() => $"Rad {RowNumber}, Plats {SeatNumber} ({Type}) – {Status}";
    }
}
