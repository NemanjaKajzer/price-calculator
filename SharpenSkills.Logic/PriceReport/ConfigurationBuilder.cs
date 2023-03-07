using System;
using System.Collections.Generic;

namespace SharpenSkills.Logic
{
    public class ConfigurationBuilder
    {
        public IProduct Product { get; private set; }
        public ITax Tax { get; private set; } = new DefaultTax();
        public List<IDiscount> DiscountsAfterTax { get; private set; } = new List<IDiscount> { new DefaultDiscount() };
        public List<IDiscount> DiscountsBeforeTax { get; private set; } = new List<IDiscount>() ;
        public List<IExpense> Expenses { get; private set; } = new List<IExpense>();
        public IDiscountCalculator DiscountCalculator { get; private set; } = new AdditiveDiscountCalculator();

        public ConfigurationBuilder WithProduct(Product product)
        {
            Product = product;
            return this;
        }

        public ConfigurationBuilder WithTax(ITax tax)
        {
            Tax = tax;
            return this;
        }

        public ConfigurationBuilder WithDiscountAfterTax(IDiscount discount)
        {
            DiscountsAfterTax.Add(discount);
            return this;
        }

        public ConfigurationBuilder WithDiscountBeforeTax(IDiscount discount)
        {
            DiscountsBeforeTax.Add(discount);
            return this;
        }
        public ConfigurationBuilder WithExpense(IExpense expense)
        {
            Expenses.Add(expense);
            return this;
        }

        public ConfigurationBuilder WithMultiplicativeDiscounts()
        {
            DiscountCalculator = new MultiplicativeDiscountCalculator();
            return this;
        }

        public Configuration Build()
        {
            if (Product == null)
            {
                throw new NullReferenceException("Product not specified!");
            }

            return new Configuration(Product, Tax, DiscountsAfterTax, DiscountsBeforeTax, Expenses, DiscountCalculator);
        }
    }
}
