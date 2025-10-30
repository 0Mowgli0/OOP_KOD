namespace OOP_KOD
{
    // Minimal, enkel Seat
    public class Seat
    {
        public int SeatId { get; }
        public int RowNumber { get; }
        public int SeatNumber { get; }
        public SeatType Type { get; }
        public SeatStatus Status { get; private set; } = SeatStatus.FREE;
        public double BasePrice { get; }

        public Seat(int seatId, int rowNumber, int seatNumber, SeatType type, double basePrice, string? color = null, bool? ecoPaintApproved = null)
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

        public bool Book()
        {
            if (Status != SeatStatus.RESERVED) return false;
            Status = SeatStatus.BOOKED;
            return true;
        }

        public void Release() => Status = SeatStatus.FREE;

        public string GetColor() => Status switch
        {
            SeatStatus.FREE => "grön",
            SeatStatus.RESERVED => "gul",
            SeatStatus.BOOKED => "röd",
            _ => "grå"
        };

        public override string ToString() => $"Rad {RowNumber}, Plats {SeatNumber} ({Type}) – {Status}";
    }
}