using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_KOD
{
    public class BasePriceStrategy : IPriceStrategy
    {
        public double CalculatePrice()
        {
            Console.WriteLine("Using BasePriceStrategy: Returning standard base price.");
            // Mock-implementation: returns a fixed base price.
            return 100.00;
        }
    }
}

