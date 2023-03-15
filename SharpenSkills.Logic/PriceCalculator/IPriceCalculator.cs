namespace SharpenSkills.Logic
{
    public interface IPriceCalculator
    {
        PriceReport Calculate(Product product);
    }
}
