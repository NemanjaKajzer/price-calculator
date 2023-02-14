namespace SharpenSkills.Logic
{
    public class Discount : IDiscount
    {
        public Percentage Percentage { get; set; }
        public bool IsBeforeTax { get; }

        public Discount(decimal value, bool isBeforeTax)
        {
            Percentage = new Percentage { Value = value };
            IsBeforeTax = isBeforeTax;
        }

        public bool IsApplicable(string upc)
        {
            return true;
        }

        public Money ApplyDiscount(Money price)
        {
            return price * Percentage;
        }
    }
}
