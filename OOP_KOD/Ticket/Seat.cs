using OOP_KOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_KOD
{
    public class Seat
    {
        // Fields (English), behavior names in English
        public int SeatId { get; }
        public int RowNumber { get; }
        public int SeatNumber { get; }
        public SeatType Type { get; }
        public SeatStatus Status { get; private set; } = SeatStatus.FREE;
        public double BasePrice { get; }


        public Seat(int seatId, int rowNumber, int seatNumber, SeatType type, double basePrice)
        {
            SeatId = seatId;
            RowNumber = rowNumber;
            SeatNumber = seatNumber;
            Type = type;
            BasePrice = basePrice;
        }


        public bool Reserve()
        {
            if (Status != SeatStatus.FREE) return false;
            Status = SeatStatus.RESERVED;
            return true;
        }


        public void Release()
        {
            Status = SeatStatus.FREE;
        }


        /* public void Book()
         {
             Status = SeatStatus.BOOKED; Vet ej om denna ska vara här?
         }*/


        // Only used for console/UI coloring text in Swedish
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


        public override string ToString() => $"Rad {RowNumber}, Plats {SeatNumber} ({Type}) – {Status}";
    }
}
