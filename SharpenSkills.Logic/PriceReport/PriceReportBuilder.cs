using System;
using System.Collections.Generic;

namespace SharpenSkills.Logic
{
    public class PriceReportBuilder
    {
        public IProduct Product { get; private set; }
        public ITax Tax { get; private set; } = new DefaultTax();
        public List<IDiscount> DiscountsAfterTax { get; private set; } = new List<IDiscount> { new DefaultDiscount() };
        public List<IDiscount> DiscountsBeforeTax { get; private set; } = new List<IDiscount>() ;


        public PriceReportBuilder WithProduct(Product product)
        {
            Product = product;
            return this;
        }

        public PriceReportBuilder WithTax(ITax tax)
        {
            Tax = tax;
            return this;
        }

        public PriceReportBuilder WithDiscountAfterTax(IDiscount discount)
        {
            DiscountsAfterTax.Add(discount);
            return this;
        }

        public PriceReportBuilder WithDiscountBeforeTax(IDiscount discount)
        {
            DiscountsBeforeTax.Add(discount);
            return this;
        }

        public PriceReport Build()
        {
            if (Product == null)
            {
                throw new NullReferenceException("Product not specified!");
            }

            return new PriceReport(Product, Tax, DiscountsAfterTax, DiscountsBeforeTax);
        }
    }
}
