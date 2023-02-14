namespace SharpenSkills.Logic
{
    public class SelectiveDiscount : IDiscount
    {
        public Percentage Percentage { get; set; }
        public string Upc { get; }

        public SelectiveDiscount(decimal value, string upc)
        {
            Percentage = new Percentage { Value = value };
            Upc = upc;
        }

        public bool IsApplicable(string upc)
        {
            return (Upc.Equals(string.Empty) || Upc.Equals(upc)) && Percentage.Value > 0;
        }

        public Money ApplyDiscount(IProduct product)
        {
            return product.Price * Percentage;
        }
    }
}
