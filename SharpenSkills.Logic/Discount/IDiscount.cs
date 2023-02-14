namespace SharpenSkills.Logic
{
    public interface IDiscount
    {
        Percentage Percentage { get; set; }
        bool IsBeforeTax { get; }

        bool IsApplicable(string upc);
        Money ApplyDiscount(Money price);
    }
}
