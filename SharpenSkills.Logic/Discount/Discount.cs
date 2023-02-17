namespace SharpenSkills.Logic
{
    public class Discount : IDiscount
    {
        public Percentage Percentage { get; set; }

        public Discount(decimal value)
        {
            Percentage = new Percentage { Value = value };
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
