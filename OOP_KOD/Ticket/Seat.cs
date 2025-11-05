namespace OOP_KOD
{
    // Modell för en sittplats med status, typ och grundpris.
    public class Seat
    {
        public int SeatId { get; }
        public int RowNumber { get; }
        public int SeatNumber { get; }
        public SeatType Type { get; }
        public SeatStatus Status { get; private set; } = SeatStatus.FREE;
        public double BasePrice { get; }

        // Skapar en ny stol med identitet, placering, typ och grundpris.
        public Seat(int seatId, int rowNumber, int seatNumber, SeatType type, double basePrice, string? color = null, bool? ecoPaintApproved = null)
        {
            SeatId = seatId;
            RowNumber = rowNumber;
            SeatNumber = seatNumber;
            Type = type;
            BasePrice = basePrice;
        }

        // Försöker reservera stolen om den är ledig.
        public bool Reserve()
        {
            if (Status != SeatStatus.FREE) return false;
            Status = SeatStatus.RESERVED;
            return true;
        }

        // Försöker boka stolen om den redan är reserverad.
        public bool Book()
        {
            if (Status != SeatStatus.RESERVED) return false;
            Status = SeatStatus.BOOKED;
            return true;
        }

        // Frigör stolen och sätter dess status till ledig.
        public void Release() => Status = SeatStatus.FREE;


        // Textrepresentation av stolens placering, typ och status.
        public override string ToString() => $"Rad {RowNumber}, Plats {SeatNumber} ({Type}) – {Status}";
    }
}