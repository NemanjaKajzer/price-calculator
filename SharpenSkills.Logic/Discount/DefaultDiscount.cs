namespace SharpenSkills.Logic
{
    public class DefaultDiscount : IDiscount
    {
        public Percentage Percentage { get; set; } = new Percentage { Value = 0m };
        public string Upc { get; } = string.Empty;

        public Money Apply(IProduct product)
        {
            return new Money(0m);
        }

        public bool IsApplicable(string upc)
        {
            return false;
        }
    }
}
