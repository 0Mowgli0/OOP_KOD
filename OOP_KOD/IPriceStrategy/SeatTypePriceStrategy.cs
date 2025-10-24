using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_KOD
{
    // Enum for the types of seats
    public enum SeatingType
    {
        Standard,
        VIP,
        Balcony
    }

    public class SeatingTypePriceStrategy : IPriceStrategy
    {
        // The 'Map<SittplatsTyp, double> priser' field, now a Dictionary.
        private readonly Dictionary<SeatingType, double> _prices;
        private readonly SeatingType _selectedType;

        public SeatingTypePriceStrategy(SeatingType selectedType)
        {
            _selectedType = selectedType;
            _prices = new Dictionary<SeatingType, double>
        {
            { SeatingType.Standard, 100.00 },
            { SeatingType.VIP, 250.00 },
            { SeatingType.Balcony, 150.00 }
        };
        }

        public double CalculatePrice()
        {
            // Use TryGetValue or the indexer; here we use the indexer for simplicity, 
            // assuming the type always exists in the dictionary.
            if (_prices.TryGetValue(_selectedType, out double price))
            {
                Console.WriteLine($"Using SeatingTypePriceStrategy: Price for {_selectedType} is {price:F2}");
                return price;
            }

            // Default case if type is somehow missing
            return 0.0;
        }
    }
}
