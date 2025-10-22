namespace OOP_KOD;
public class BasePriceStrategy : IPriceStrategy
{
    public double CalculatePrice()
    {
        Console.WriteLine("Using BasePriceStrategy: Returning standard base price.");
        // Mock-implementation: returns a fixed base price.
        return 100.00;
    }
}