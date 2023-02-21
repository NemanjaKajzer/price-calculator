using System.Collections.Generic;

namespace SharpenSkills.Logic
{
    public interface IDiscountCalculator
    {
        Money Apply(List<IDiscount> discounts, Money price, string upc, Money discountTotal);
    }
}
