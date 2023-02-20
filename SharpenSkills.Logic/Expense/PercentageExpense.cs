namespace SharpenSkills.Logic
{
    public class PercentageExpense : IExpense
    {
        public string Description { get; set; }
        public Percentage Amount { get; set; }

        public PercentageExpense(decimal amount, string description)
        {
            Amount = new Percentage { Value = amount};
            Description = description;
        }

        public Money ApplyExpense(Money price)
        {
            return price * Amount;
        }
    }
}
