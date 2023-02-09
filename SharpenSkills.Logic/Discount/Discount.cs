namespace SharpenSkills.Logic
{
    public class Discount : IDiscount
    {
        public Percentage Percentage { get; set; }

        public Discount(decimal value)
        {
            Percentage = new Percentage { Value = value };
        }
    }
}
