namespace OOP_KOD;

public class PriceCalculator
{
    private IPriceStrategy _strategy;
    public PriceCalculator(IPriceStrategy initialStrategy) => _strategy = initialStrategy;
    public void SetStrategy(IPriceStrategy newStrategy) => _strategy = newStrategy;
    
    // Calls the parameterless CalculatePrice
    public double GetPrice() => _strategy.CalculatePrice(); 
}