using System;

namespace SharpenSkills.Logic
{
    public class Director
    {
        private readonly PriceReportBuilder _resultBuilder;

        //public Director(PriceReportBuilder resultBuilder)
        //{
        //    _resultBuilder = resultBuilder;
        //}

        public PriceReport CreatePriceReport(Product product, Tax tax)
        {
            product = product != null ? product : new Product();
            tax = tax != null ? tax : new Tax();

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
