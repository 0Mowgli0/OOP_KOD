using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_KOD.Interface.Booking_repository
{
    public class BookingRepository : IBookingRepository
    {
        // Lista över alla bokningar
        public List<Booking> bookings = new List<Booking>();

        // Sparar en ny bokning
        public void saveBooking(Booking booking)
        {
            bookings.Add(booking);
        }

        // Hämtar en bokning via ID
        public Booking getBooking(int id)
        {
            return bookings.Find(b => b.Id == id);
        }

        // Hämtar alla aktiva bokningar (enkelt: returnera alla)
        public List<Booking> getAllActiveBookings()
        {
            return bookings;
        }

        // Uppdaterar en bokning (ersätt objekt med samma Id)
        public void updateBooking(Booking booking)
        {
            var index = bookings.FindIndex(b => b.Id == booking.Id);
            if (index >= 0)
            {
                bookings[index] = booking;
            }
        }
    }
}
