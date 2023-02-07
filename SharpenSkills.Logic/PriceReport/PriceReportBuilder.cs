using System;

namespace SharpenSkills.Logic
{
    public class PriceReportBuilder
    {
        public Product Product { get; private set; }
        public ITax Tax { get; private set; }

        public PriceReportBuilder ApplyProduct(Product product)
        {
            if (Product != null) return this;

            Product = product;
            return this;
        }

        public PriceReportBuilder ApplyTax(ITax tax)
        {
            if (Tax != null) return this;

            Tax = tax;
            return this;
        }

        public PriceReport Build() { return new PriceReport(this); }
    }
}
