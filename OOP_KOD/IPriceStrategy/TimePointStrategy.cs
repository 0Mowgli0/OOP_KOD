using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_KOD
{
    public class TimePointPriceStrategy : IPriceStrategy
    {
        // The 'faktor' field from your UML, now called 'factor'.
        private readonly double _factor;

        public TimePointPriceStrategy(double factor)
        {
            _factor = factor;
        }

        public double CalculatePrice()
        {
            // Assume a base price is needed for calculation.
            const double basePrice = 100.00;
            double price = basePrice * _factor;
            Console.WriteLine($"Using TimePointPriceStrategy: Base Price * Factor ({_factor:F2}) = {price:F2}");
            return price;
        }
    }
}
