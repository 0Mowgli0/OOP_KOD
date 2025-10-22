namespace OOP_KOD;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

public class CombinedPriceStrategy : IPriceStrategy
{
    // The 'List<IPrisStrategi> strategier' field.
    private readonly List<IPriceStrategy> _strategies;

    public CombinedPriceStrategy()
    {
        _strategies = new List<IPriceStrategy>();
    }

    public void AddStrategy(IPriceStrategy strategy)
    {
        _strategies.Add(strategy);
    }

    public double CalculatePrice()
    {
        Console.WriteLine("\n--- Using CombinedPriceStrategy: Summing up prices from sub-strategies ---");

        double totalPrice = 0.0;

        foreach (var strategy in _strategies)
        {
            // The combined strategy sums the results of all sub-strategies.
            // This could also be a sequence (e.g., base + discount + tax).
            totalPrice += strategy.CalculatePrice();
        }

        Console.WriteLine($"Total Combined Price: {totalPrice:F2}");
        return totalPrice;
    }
}