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
        public List<IExpense> Expenses { get; private set; } = new List<IExpense>();

        public PriceReport(IProduct product, ITax tax, List<IDiscount> discountsAfterTax, List<IDiscount> discountsBeforeTax, List<IExpense> expenses)
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

            var expensesTotal = new Money(0m);
            expenses.ForEach(x =>
            {
                expensesTotal += x.ApplyExpense(Price);
                Expenses.Add(x);
            });

            Total = Price + TaxTotal - DiscountTotal + expensesTotal;
        }

        public override string ToString()
        {
            var discountStr = DiscountTotal == 0m ? string.Empty : $"\nDiscounts = {DiscountTotal}";
            var expensesStr = string.Empty;
            Expenses.ForEach(x => { expensesStr += $"{x.Description} = {x.ApplyExpense(Price)}\n"; });

            return $"Cost = {Price}\n" +
                   $"Tax = {TaxTotal}" +
                   $"{discountStr}\n" +
                   $"{expensesStr}" +
                   $"TOTAL = {Total}";
        }
    }
}
