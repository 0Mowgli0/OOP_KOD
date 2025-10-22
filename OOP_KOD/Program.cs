using System;

namespace OOP_KOD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Arena + seat (bara för att visa att modellen är hel)
            var arena = new Arena(1, "Borlänge Arena", true, "Tegel");
            var seat1 = new Seat(1, "A", "1", 1);
            arena.AddSeat(seat1);
            Console.WriteLine($"Arena: {arena.Name}");
            Console.WriteLine($"Antal platser i arenan: {arena.Seats.Count}");

            // Booking + states
            var booking = new Booking(1001, "Namn");
            Console.WriteLine($"Status nu: {booking.Status.Name}");

            // Bekräfta
            booking.Confirm();
            Console.WriteLine($"Status efter Confirm(): {booking.Status.Name}");

            // Avboka (visa transition – i verkligheten kanske du inte får avboka efter bekräftelse)
            booking.Cancel();
            Console.WriteLine($"Status efter Cancel(): {booking.Status.Name}");
            
            
        }
    }
}