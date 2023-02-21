using System.Collections.Generic;
using System.Linq;

namespace SharpenSkills.Logic
{
    public class AdditiveDiscountCalculator : IDiscountCalculator
    {
        public Money Apply(List<IDiscount> discounts, Money price, string upc, Money discountTotal)
        {
            return new Money(discounts.Where(x => x.IsApplicable(upc))
                .Sum(x => x.ApplyDiscount(price).Amount));
        }
    }
}
