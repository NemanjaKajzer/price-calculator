﻿using System.Collections.Generic;
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

        public PriceReport(IProduct product, ITax tax, List<IDiscount> discountsAfterTax, List<IDiscount> discountsBeforeTax, List<IExpense> expenses)
        {
            Price = product.Price;

            DiscountTotal = new Money(discountsBeforeTax.Where(x => x.IsApplicable(product.Upc))
                .Sum(x => x.ApplyDiscount(Price).Amount));

            var discountedPriceBeforeTax = Price - DiscountTotal;

            TaxTotal = tax.ApplyTax(discountedPriceBeforeTax);

            DiscountTotal += new Money(discountsAfterTax.Where(x => x.IsApplicable(product.Upc))
                .Sum(x => x.ApplyDiscount(discountedPriceBeforeTax).Amount));

            AppliedExpenses = expenses.Select(x => new AbsoluteExpense(x.ApplyExpense(Price).Amount, x.Description)).ToList();

            var expensesTotal = new Money(AppliedExpenses.Sum(x => x.Amount.Amount));

            Total = Price + TaxTotal - DiscountTotal + expensesTotal;
        }

        public override string ToString()
        {
            var discountStr = DiscountTotal == 0m ? string.Empty : $"\nDiscounts = {DiscountTotal}";

            var expensesStr = AppliedExpenses.Count == 0 ? string.Empty : AppliedExpenses.Select(x => x.ToString())
                .Aggregate((joined, expense) => $"{joined}\n{expense}\n");

            return $"Cost = {Price}\n" +
                   $"Tax = {TaxTotal}" +
                   $"{discountStr}\n" +
                   $"{expensesStr}" +
                   $"TOTAL = {Total}";
        }
    }
}
