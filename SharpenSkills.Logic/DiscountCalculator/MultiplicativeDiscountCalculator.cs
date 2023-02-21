using System.Collections.Generic;
using System.Linq;

namespace SharpenSkills.Logic
{
    public class MultiplicativeDiscountCalculator : IDiscountCalculator
    {
        public Money Apply(List<IDiscount> discounts, Money price, string upc, Money discountTotal)
        {
            discounts.Where(x => x.IsApplicable(upc))
                .ToList()
                .ForEach(x => discountTotal += x.ApplyDiscount(price - discountTotal));

            return discountTotal;
        }
    }
}
