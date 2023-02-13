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
    }
}
