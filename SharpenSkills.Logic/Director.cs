using System;

namespace SharpenSkills.Logic
{
    public class Director
    {
        public PriceReport Calculate(Product product, Tax tax)
        {
            product = product ?? new Product();
            tax = tax ?? new Tax();

            if (tax.Percentage < 0 || tax.Percentage > 100)
            {
                throw new ArgumentOutOfRangeException("Tax percentage");
            }

            var priceReportBuilder = new PriceReportBuilder();
            priceReportBuilder.Reset();
            priceReportBuilder.ApplyPrice(product.Price);
            priceReportBuilder.ApplyTax(tax.Percentage);
            priceReportBuilder.CalculateTotal();
            return priceReportBuilder.GetReport();
        }
    }
}
