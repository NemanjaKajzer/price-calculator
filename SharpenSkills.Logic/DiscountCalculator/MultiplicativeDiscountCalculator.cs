using System.Collections.Generic;

namespace SharpenSkills.Logic
{
    public class MultiplicativeDiscountCalculator : IDiscountCalculator
    {
        public Money Apply(List<IDiscount> discounts, Money price)
        {
            var discountTotal = new Money(0m);

            discounts.ForEach(x => discountTotal += x.ApplyDiscount(price - discountTotal));

            return discountTotal;
        }
    }
}
