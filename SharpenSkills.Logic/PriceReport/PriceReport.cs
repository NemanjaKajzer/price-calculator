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

        public IEnumerable<AbsoluteExpense> AppliedExpenses { get; private set; } = new List<AbsoluteExpense>();

        public PriceReport(Money price, Money taxTotal, Money total, Money discountTotal, IEnumerable<AbsoluteExpense> appliedExpenses)
        {
            Price = price;
            TaxTotal = taxTotal;
            Total = total;
            DiscountTotal = discountTotal;
            AppliedExpenses = appliedExpenses;
        }

        public override string ToString()
        {
            return $"Cost = {Price}\n" +
                   $"Tax = {TaxTotal}\n" +
                   (DiscountTotal == 0m ? string.Empty : $"Discounts = {DiscountTotal}\n") +
                   (AppliedExpenses.Any() ? $"{string.Join("\n", AppliedExpenses)}\n" : string.Empty) +
                   $"TOTAL = {Total}";
        }
    }
}
