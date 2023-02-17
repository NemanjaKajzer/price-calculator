namespace SharpenSkills.Logic
{
    public interface IDiscount
    {
        Percentage Percentage { get; set; }

        bool IsApplicable(string upc);
        Money ApplyDiscount(Money price);
    }
}
