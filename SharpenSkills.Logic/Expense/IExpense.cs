namespace SharpenSkills.Logic
{
    public interface IExpense
    {
        string Description { get; set; }

        Money ApplyExpense(Money price);
    }
}
