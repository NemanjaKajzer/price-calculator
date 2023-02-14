namespace SharpenSkills.Logic
{
    public interface IDiscount
    {
        Percentage Percentage { get; set; }
        string Upc { get; }

        bool IsApplicable(string upc);
        Money Apply(IProduct product);
    }
}
