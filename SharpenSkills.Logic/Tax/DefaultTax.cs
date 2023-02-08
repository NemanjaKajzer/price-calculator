namespace SharpenSkills.Logic
{
    public class DefaultTax : ITax
    {
        public Percentage Percentage { get; set;  } = new Percentage { Value = 0.2m };
    }
}
