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

        public List<AbsoluteExpense> AppliedExpenses { get; private set; } = new List<AbsoluteExpense>();

        public PriceReport(IProduct product, ITax tax, List<IDiscount> discountsAfterTax, List<IDiscount> discountsBeforeTax, List<IExpense> expenses, IDiscountCalculator discountCalculator)
        {
            Price = product.Price;

            DiscountTotal = discountCalculator.Apply(discountsBeforeTax.Where(x => x.IsApplicable(product.Upc)), Price);

            var discountedPriceBeforeTax = Price - DiscountTotal;

            TaxTotal = tax.ApplyTax(discountedPriceBeforeTax);

            DiscountTotal += discountCalculator.Apply(discountsAfterTax.Where(x => x.IsApplicable(product.Upc)), discountedPriceBeforeTax);

            AppliedExpenses = expenses.Select(x => new AbsoluteExpense(x.ApplyExpense(Price).Amount, x.Description))
                .ToList();

            var expensesTotal = new Money(AppliedExpenses.Sum(x => x.Amount.Amount));

            Total = Price + TaxTotal - DiscountTotal + expensesTotal;
        }

        public override string ToString()
        {
            var discountStr = DiscountTotal == 0m ? string.Empty : $"\nDiscounts = {DiscountTotal}";

            var expensesStr = AppliedExpenses.Any() ? AppliedExpenses.Select(x => x.ToString())
                .Aggregate((joined, expense) => $"{joined}\n{expense}\n") : string.Empty;

            return $"Cost = {Price}\n" +
                   $"Tax = {TaxTotal}\n" +
                   (DiscountTotal == 0m ? string.Empty : $"Discounts = {DiscountTotal}\n") +
                   (AppliedExpenses.Any() ? $"{string.Join("\n", AppliedExpenses)}\n" : string.Empty) +
                   $"TOTAL = {Total}";
        }
    }
}
