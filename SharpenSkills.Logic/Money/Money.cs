namespace SharpenSkills.Logic
{
    public class Money : IMoney
    {
        public decimal Amount { get; set; }
        //public Currency Currency { get; set; }

        public Money()
        {
            Amount = 0;
        }

        public override string ToString()
        {
            return $"${Amount}";
        }
    }
}
