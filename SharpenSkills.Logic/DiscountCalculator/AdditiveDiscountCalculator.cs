using System.Collections.Generic;
using System.Linq;

namespace SharpenSkills.Logic
{
    public class AdditiveDiscountCalculator : IDiscountCalculator
    {
        public Money Apply(List<IDiscount> discounts, Money price)
        {
            return new Money(discounts.Sum(x => x.ApplyDiscount(price).Amount));
        }
    }
}
