namespace SharpenSkills.Logic.DiscountCap
{
    public class PercentageDiscountCap : IDiscountCap
    {
        public Percentage Percentage { get; set; }

        public PercentageDiscountCap(decimal value)
        {
            Percentage = new Percentage { Value = value };
        }
        public Money ApplyDiscountCap(Money discountTotal, Money price)
        {
            if (Percentage.Value == 0) return discountTotal;

            var absoluteAmount = price * Percentage;
            return discountTotal <= absoluteAmount ? discountTotal : absoluteAmount;
        }
    }
}
