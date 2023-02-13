using System.Collections.Generic;
using System.Linq;

namespace SharpenSkills.Logic
{
    public class PriceReport
    {
        public Money Price { get; private set; } = new Money();
        public Money TaxTotal { get; private set; } = new Money();
        public Money Total { get; private set; } = new Money();
        public Money DiscountTotal { get; private set; } = new Money();

        public PriceReport(IProduct product, ITax tax, List<IDiscount> discounts)
        {
            Price = product.Price;
            TaxTotal = product.Price * tax.Percentage;
            ApplyDiscounts(product, discounts);
            Total = Price + TaxTotal - DiscountTotal;
        }

        public void ApplyDiscounts(IProduct product, List<IDiscount> discounts)
        {
            var applicableDiscounts = discounts.Where(x => (x.Upc.Equals(product.Upc) || x.Upc.Equals(string.Empty)) && x.Percentage.Value > 0);

            foreach (var discount in applicableDiscounts)
            {
                DiscountTotal +=  product.Price * discount.Percentage;
            }
        }

        public override string ToString()
        {
            var discountStr = DiscountTotal == 0m ? string.Empty : $"\nDiscounts = {DiscountTotal}";

            return $"Cost = {Price}\n" +
                    $"Tax = {TaxTotal}{discountStr}\n" +
                    $"TOTAL = {Total}";
        }
    }
}
