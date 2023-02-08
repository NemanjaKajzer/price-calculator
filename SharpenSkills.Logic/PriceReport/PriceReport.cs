namespace SharpenSkills.Logic
{
    public class PriceReport
    {
        public Money Price { get; private set; }
        public Money TaxTotal { get; private set; }
        public Money Total { get; private set; }
        public Money DiscountTotal { get; private set; }

        public PriceReport(IProduct product, ITax tax, IDiscount discount)
        {
            Price = product.Price;
            TaxTotal = product.Price * tax.Percentage;
            DiscountTotal = product.Price * discount.Percentage;
            Total = Price + TaxTotal - DiscountTotal;
        }
    }
}
