namespace SharpenSkills.Logic
{
    public class DefaultDiscount : IDiscount
    {
        public Percentage Percentage { get; set; } = new Percentage { Value = 0m };
        public string Upc { get; } = string.Empty;

        public bool IsApplicable(string upc)
        {
            return true;
        }

        public Money ApplyDiscount(IProduct product)
        {
            return new Money(0m);
        }
    }
}
