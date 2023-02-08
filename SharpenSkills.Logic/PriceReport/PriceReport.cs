namespace SharpenSkills.Logic
{
    public class PriceReport
    {
        public Money Price { get; private set; }
        public Money TaxTotal { get; private set; }
        public Money Total { get; private set; }

        public PriceReport(Product product, ITax tax)
        {
            Price = product.Price;
            TaxTotal = product.Price * tax.Percentage;
            Total = Price + TaxTotal;
        }
    }
}
