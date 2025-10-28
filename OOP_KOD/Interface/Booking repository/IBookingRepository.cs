using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_KOD.Interface.Booking_repository
{
    public interface IBookingRepository
    {
        // Sparar en ny bokning
        void saveBooking(Booking booking);

        // Hämtar en bokning via ID
        Booking getBooking(int id);

        // Hämtar alla aktiva bokningar
        List<Booking> getAllActiveBookings();

        // Uppdaterar en bokning
        void updateBooking(Booking booking);
    }
}
