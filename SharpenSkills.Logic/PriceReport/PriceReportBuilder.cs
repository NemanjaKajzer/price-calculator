using System;

namespace SharpenSkills.Logic
{
    public class PriceReportBuilder
    {
        public Product Product { get; set; }
        public ITax Tax { get; set; }

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

        public PriceReport Build() { return new PriceReport(this); }
    }
}
