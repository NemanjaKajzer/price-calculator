namespace SharpenSkills.Logic
{
    public class Discount : IDiscount
    {
        public Percentage Percentage { get; set; }
        public string Upc { get; } = string.Empty;

        public Discount(decimal value)
        {
            Percentage = new Percentage { Value = value };
        }

        public Discount(decimal value, string upc)
        {
            Percentage = new Percentage { Value = value };
            Upc = upc;
        }

        public bool IsApplicable(string upc)
        {
            return (Upc.Equals(string.Empty) || Upc.Equals(upc)) && Percentage.Value > 0;
        }

        public Money Apply(IProduct product)
        {
            if (!IsApplicable(product.Upc))
                return new Money(0m);
            
            return product.Price * Percentage;
        }
    }
}
