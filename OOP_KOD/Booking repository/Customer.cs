using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_KOD.Interface.Booking_repository
{
    public class Customer
    {
        // Kundens grundinformation
        public int customerId;
        public string name;
        public string email;
        public string phone;

        // Skapar en ny bokning (kommer kopplas till Booking senare)
        public void createBooking()
        {
            // Här kan du lägga logik för att skapa en ny bokning
        }

        // Visar kundens bokningar
        public void showMyBookings()
        {
            // Här kan du lägga logik för att visa alla bokningar för denna kund
        }
    }
}
