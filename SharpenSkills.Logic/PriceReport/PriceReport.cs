namespace SharpenSkills.Logic
{
    public class PriceReport
    {
        public Money Price { get; private set; }
        public Money TaxTotal { get; private set; }
        public Money DiscountTotal { get; private set; }
        public Money Total { get; private set; }

        public PriceReport()
        {
            Price = new Money();
            TaxTotal = new Money();
            DiscountTotal = new Money();
            Total = new Money();
        }

        public PriceReport(IProduct product, ITax tax, IDiscount discount)
        {
            SetProduct(product);
            SetTaxTotal(product, tax);
            SetDiscountTotal(product, discount);
            SetTotal();
        }

        public void SetProduct(IProduct product)
        {
            Price = product.Price;
        }

        public void SetDiscountTotal(IProduct product, IDiscount discount)
        {
            DiscountTotal = product.Price * discount.Percentage;
        }

        public void SetTaxTotal(IProduct product, ITax tax)
        {
            TaxTotal = product.Price * tax.Percentage;
        }

        private void SetTotal()
        {
            Total = Price + TaxTotal - DiscountTotal;
        }
    }
}
