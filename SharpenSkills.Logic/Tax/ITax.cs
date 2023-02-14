namespace SharpenSkills.Logic
{
    public interface ITax
    {
        Percentage Percentage { get; set; }

        Money ApplyTax(Money price);
    }
}
