namespace SharpenSkills.Logic
{
    public interface IPriceCalculator
    {
        string Calculate(ConfigurationBuilder configuration, Product product);
    }
}
