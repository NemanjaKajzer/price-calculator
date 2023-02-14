namespace SharpenSkills.Logic
{
    public class DefaultTax : ITax
    {
        public Percentage Percentage { get; set;  } = new Percentage { Value = 0.2m };

        public Money ApplyTax(Money price)
        {
            return price * Percentage;
        }
    }
}
