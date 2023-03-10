using System.Collections.Generic;
using System.Linq;

namespace SharpenSkills.Logic
{
    public class PriceCalculator : IPriceCalculator
    {
        public ITax Tax { get; private set; } = new DefaultTax();
        public List<IDiscount> DiscountsAfterTax { get; private set; } = new List<IDiscount> { new DefaultDiscount() };
        public List<IDiscount> DiscountsBeforeTax { get; private set; } = new List<IDiscount>();
        public List<IExpense> Expenses { get; private set; } = new List<IExpense>();
        public IDiscountCalculator DiscountCalculator { get; private set; } = new AdditiveDiscountCalculator();

        public PriceCalculator WithTax(ITax tax)
        {
            Tax = tax;
            return this;
        }

        public PriceCalculator WithDiscountAfterTax(IDiscount discount)
        {
            DiscountsAfterTax.Add(discount);
            return this;
        }

        public PriceCalculator WithDiscountBeforeTax(IDiscount discount)
        {
            DiscountsBeforeTax.Add(discount);
            return this;
        }
        public PriceCalculator WithExpense(IExpense expense)
        {
            Expenses.Add(expense);
            return this;
        }

        public PriceCalculator WithMultiplicativeDiscounts()
        {
            DiscountCalculator = new MultiplicativeDiscountCalculator();
            return this;
        }

        public PriceReport Calculate(Product product)
        {
            var price = product.Price;

            var discountTotal = DiscountCalculator.Apply(DiscountsBeforeTax.Where(x => x.IsApplicable(product.Upc)), price);

            var discountedPriceBeforeTax = price - discountTotal;

            var taxTotal = Tax.ApplyTax(discountedPriceBeforeTax);

            discountTotal += DiscountCalculator.Apply(DiscountsAfterTax.Where(x => x.IsApplicable(product.Upc)), discountedPriceBeforeTax);

            var appliedExpenses = Expenses.Select(x => new AbsoluteExpense(x.ApplyExpense(price).Amount, x.Description));

            var expensesTotal = new Money(appliedExpenses.Sum(x => x.Amount.Amount));

            var total = price + taxTotal - discountTotal + expensesTotal;

            return new PriceReport(price, taxTotal, total, discountTotal, appliedExpenses);
        }
    }
}
