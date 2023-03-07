using System.Collections.Generic;
using System.Linq;

namespace SharpenSkills.Logic {
    public class PriceCalculator : IPriceCalculator {
        public Money Price { get; private set; } = new Money();
        public Money TaxTotal { get; private set; } = new Money();
        public Money Total { get; private set; } = new Money();
        public Money DiscountTotal { get; private set; } = new Money();

        public IEnumerable<AbsoluteExpense> AppliedExpenses { get; private set; } = new List<AbsoluteExpense>();

        public PriceCalculator() { }

        public string Calculate(ConfigurationBuilder configuration, Product product) {
            var price = product.Price;

            var discountTotal = configuration.DiscountCalculator.Apply(configuration.DiscountsBeforeTax.Where(x => x.IsApplicable(product.Upc)), price);

            var discountedPriceBeforeTax = price - discountTotal;

            var taxTotal = configuration.Tax.ApplyTax(discountedPriceBeforeTax);

            discountTotal += configuration.DiscountCalculator.Apply(configuration.DiscountsAfterTax.Where(x => x.IsApplicable(product.Upc)), discountedPriceBeforeTax);

            var appliedExpenses = configuration.Expenses.Select(x => new AbsoluteExpense(x.ApplyExpense(price).Amount, x.Description));

            var expensesTotal = new Money(appliedExpenses.Sum(x => x.Amount.Amount));

            var total = price + taxTotal - discountTotal + expensesTotal;

            return $"Cost = {price}\n" +
                   $"Tax = {taxTotal}\n" +
                   (discountTotal == 0m ? string.Empty : $"Discounts = {discountTotal}\n") +
                   (appliedExpenses.Any() ? $"{string.Join("\n", appliedExpenses)}\n" : string.Empty) +
                   $"TOTAL = {total}";
        }

        public PriceCalculator(ConfigurationBuilder configuration, Product product) {
            Price = product.Price;

            DiscountTotal = configuration.DiscountCalculator.Apply(configuration.DiscountsBeforeTax.Where(x => x.IsApplicable(product.Upc)), Price);

            var discountedPriceBeforeTax = Price - DiscountTotal;

            TaxTotal = configuration.Tax.ApplyTax(discountedPriceBeforeTax);

            DiscountTotal += configuration.DiscountCalculator.Apply(configuration.DiscountsAfterTax.Where(x => x.IsApplicable(product.Upc)), discountedPriceBeforeTax);

            AppliedExpenses = configuration.Expenses.Select(x => new AbsoluteExpense(x.ApplyExpense(Price).Amount, x.Description));

            var expensesTotal = new Money(AppliedExpenses.Sum(x => x.Amount.Amount));

            Total = Price + TaxTotal - DiscountTotal + expensesTotal;
        }

        public override string ToString() {
            return $"Cost = {Price}\n" +
                   $"Tax = {TaxTotal}\n" +
                   (DiscountTotal == 0m ? string.Empty : $"Discounts = {DiscountTotal}\n") +
                   (AppliedExpenses.Any() ? $"{string.Join("\n", AppliedExpenses)}\n" : string.Empty) +
                   $"TOTAL = {Total}";
        }
    }
}
