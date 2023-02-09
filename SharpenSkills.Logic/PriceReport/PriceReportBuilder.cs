using System;

namespace SharpenSkills.Logic
{
    public class PriceReportBuilder
    {

        public IProduct Product { get; private set; }
        public ITax Tax { get; private set; } = new DefaultTax();
        public IDiscount Discount { get; private set; } = new DefaultDiscount();

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
        public PriceReportBuilder ApplyDiscount(IDiscount discount)
        {
            Discount = discount;
            return this;
        }

        public PriceReport Build()
        {
            if (Product == null)
            {
                throw new NullReferenceException("Product not specified!");
            }

            return new PriceReport(Product, Tax, Discount);
        }
    }
}
