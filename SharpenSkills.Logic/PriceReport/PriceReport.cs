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

        public PriceReport(IProduct product, ITax tax, List<IDiscount> discountsAfterTax, List<IDiscount> discountsBeforeTax)
        {
            Price = product.Price;

            discountsBeforeTax.Where(x => x.IsApplicable(product.Upc))
                .ToList()
                .ForEach(x => DiscountTotal += x.ApplyDiscount(Price));

            var discountedPriceBeforeTax = Price - DiscountTotal;

            TaxTotal = tax.ApplyTax(discountedPriceBeforeTax);

            discountsAfterTax.Where(x => x.IsApplicable(product.Upc))
                .ToList()
                .ForEach(x => DiscountTotal += x.ApplyDiscount(discountedPriceBeforeTax));

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
