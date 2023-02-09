namespace SharpenSkills.Logic
{
    public class DefaultDiscount : IDiscount
    {
        public Percentage Percentage { get; set; } = new Percentage { Value = 0m };
    }
}
