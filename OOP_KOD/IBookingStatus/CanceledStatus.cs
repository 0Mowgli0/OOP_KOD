using OOP_KOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_KOD
{
    public sealed class CanceledStatus : IBookingStatus
    {
        public void HandleBooking(Booking booking)
        {

        }

        public bool CanBeConfirmed() => false;
    }
}
