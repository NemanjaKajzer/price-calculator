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
            TaxTotal = tax.ApplyTax(product.Price);
            discounts.Where(x => x.IsApplicable(product.Upc))
                .ToList()
                .ForEach(x => DiscountTotal += x.ApplyDiscount(product));
            Total = Price + TaxTotal - DiscountTotal;
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
