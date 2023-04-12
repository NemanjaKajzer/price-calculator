namespace SharpenSkills.Logic.DiscountCap
{
    public class AbsoluteDiscountCap : IDiscountCap
    {
        public Money Amount { get; set; }

        public AbsoluteDiscountCap(decimal amount)
        {
            Amount = new Money(amount);
        }

        public Money ApplyDiscountCap(Money discountTotal, Money price)
        {
            return Amount == 0 || discountTotal <= Amount ? discountTotal : Amount;
        }
    }
}
