using System;
using System.Collections.Generic;

namespace SharpenSkills.Logic
{
    public class PriceReportBuilder
    {

        public IProduct Product { get; private set; }
        public ITax Tax { get; private set; } = new DefaultTax();
        public List<IDiscount> Discounts { get; private set; } = new List<IDiscount> { new DefaultDiscount() };

        public PriceReportBuilder ApplyProduct(Product product)
        {
            Product = product;
            return this;
        }

        public PriceReportBuilder ApplyTax(ITax tax)
        {
            Tax = tax;
            return this;
        }
        public PriceReportBuilder ApplyDiscount(Discount discount)
        {
            Discounts.Add(discount);
            return this;
        }

        public PriceReport Build()
        {
            if (Product == null)
            {
                throw new NullReferenceException("Product not specified!");
            }

            return new PriceReport(Product, Tax, Discounts);
        }
    }
}
