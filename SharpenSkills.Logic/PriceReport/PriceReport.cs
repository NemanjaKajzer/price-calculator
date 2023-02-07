namespace SharpenSkills.Logic
{
    public class PriceReport
    {
        public Money Price { get; private set; }
        public Money TaxTotal { get; private set; }
        public Money Total { get; private set; }

        public PriceReport()
        {
            Price = new Money();
            TaxTotal = new Money();
            Total = new Money();
        }

        public PriceReport(Product product, ITax tax)
        {
            SetProduct(product);
            SetTaxTotal(product, tax);
            SetTotal();
        }

        public void SetProduct(Product product)
        {
            Price = product.Price;
        }

        public void SetTaxTotal(Product product, ITax tax)
        {
            TaxTotal = product.Price * tax.Percentage;
        }

        private void SetTotal()
        {
            Total = Price + TaxTotal;
        }
    }
}
