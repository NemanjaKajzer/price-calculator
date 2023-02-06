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

            TaxTotal = Price.Percent(defaultTax.Percentage);
        }

        public void SetCustomTax(ITax tax)
        {
            if (tax == null) return;

            TaxTotal = Price.Percent(tax.Percentage);
        }

        private void SetTotal()
        {
            Total = Price.Add(TaxTotal);
        }

        public PriceReport(PriceReportBuilder builder)
        {
            SetProduct(builder.Product);
            SetCustomTax(builder.Tax);
            SetTotal();
        }
    }
}
