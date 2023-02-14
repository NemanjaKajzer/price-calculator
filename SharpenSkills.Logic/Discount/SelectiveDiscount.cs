namespace SharpenSkills.Logic
{
    public class SelectiveDiscount : IDiscount
    {
        public Percentage Percentage { get; set; }
        public string Upc { get; }
        public bool IsBeforeTax { get; }

        public SelectiveDiscount(decimal value, string upc, bool isBeforeTax)
        {
            Percentage = new Percentage { Value = value };
            Upc = upc;
            IsBeforeTax = isBeforeTax;
        }

        public bool IsApplicable(string upc)
        {
            return (Upc.Equals(string.Empty) || Upc.Equals(upc)) && Percentage.Value > 0;
        }

        public Money ApplyDiscount(Money price)
        {
            return price * Percentage;
        }
    }
}
