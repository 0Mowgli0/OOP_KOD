using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_KOD.Interface.Booking_repository
{
    public interface IBookable
    {
        // Boka något
        void book();

        // Avboka något
        void cancel();
    }
}
