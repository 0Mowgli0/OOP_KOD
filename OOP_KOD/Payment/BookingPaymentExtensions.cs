using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_KOD;          
using OOP_KOD.Payment;    

namespace OOP_KOD.Payment
{
    public static class BookingPaymentExtensions
    {
        public static void PayDirect(this Booking booking, IPriceStrategy strategy)
        {
            var amount = new PriceCalculator(strategy).GetPrice();
            new DirectPayment(amount).Pay();
        }

        public static void PayInvoice(this Booking booking, IPriceStrategy strategy)
        {
            var amount = new PriceCalculator(strategy).GetPrice();
            new Invoice(amount).Pay();
        }
    }
}

