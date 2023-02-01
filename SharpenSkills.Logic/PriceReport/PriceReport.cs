using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpenSkills.Logic
{
    public class PriceReport
    {
        public Money Price { get; set; }
        public Money TaxTotal { get; set; }
        public Money Total { get; set; }

        public PriceReport()
        {
            Price = new Money();
            TaxTotal = new Money();
            Total = new Money();
        }

        public void SetProduct(Product product)
        {
            Price = product.Price;
            ApplyDefaultTax();
        }

        private void ApplyDefaultTax()
        {
            var defaultTax = new DefaultTax();

            TaxTotal = new Money { Amount = Price.Amount * defaultTax.Percentage.Value };
        }

        public void SetCustomTax(ITax tax)
        {
            if (tax == null) return;

            TaxTotal = new Money { Amount = Math.Round(Price.Amount * tax.Percentage.Value, 2) };
        }

        private void SetTotal()
        {
            Total = new Money { Amount = Price.Amount + TaxTotal.Amount };
        }

        public PriceReport(PriceReportBuilder builder)
        {
            SetProduct(builder.Product);
            SetCustomTax(builder.Tax);
            SetTotal();
        }
    }
}
