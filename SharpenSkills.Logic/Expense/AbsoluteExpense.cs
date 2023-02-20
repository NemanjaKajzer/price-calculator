namespace SharpenSkills.Logic
{
    public class AbsoluteExpense : IExpense
    {
        public string Description { get; set; }
        public Money Amount { get; set; }

        public AbsoluteExpense(decimal amount, string description)
        {
            Amount = new Money(amount);
            Description = description;
        }

        public Money ApplyExpense(Money price)
        {
            return Amount;
        }

        public override string ToString()
        {
            return $"{Description} = {Amount}";
        }
    }
}
