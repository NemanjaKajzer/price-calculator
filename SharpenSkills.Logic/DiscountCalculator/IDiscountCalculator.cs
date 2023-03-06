using System.Collections.Generic;

namespace SharpenSkills.Logic
{
    public interface IDiscountCalculator
    {
        Money Apply(IEnumerable<IDiscount> discounts, Money price);
    }
}
