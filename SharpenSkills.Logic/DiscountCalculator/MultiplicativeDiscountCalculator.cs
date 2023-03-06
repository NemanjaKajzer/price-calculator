using System.Collections.Generic;
using System.Linq;

namespace SharpenSkills.Logic
{
    public class MultiplicativeDiscountCalculator : IDiscountCalculator
    {
        public Money Apply(IEnumerable<IDiscount> discounts, Money price)
        {
            return discounts.Aggregate(new Money(0m), (total, discount) => total += discount.ApplyDiscount(price - total));
        }
    }
}
