using System;

namespace SharpenSkills.Logic
{
    public class Money : IMoney
    {
        public decimal Amount { get; set; }

        public Money()
        {
            Amount = 0;
        }

        public Money Add(params Money[] moneys)
        {
            var total = Amount;
            foreach (var money in moneys)
            {
                total += money.Amount;
            }

            return new Money { Amount = total };
        }

        public Money Subtract(params Money[] moneys)
        {
            var total = Amount;
            foreach (var money in moneys)
            {
                total -= money.Amount;
            }

            return new Money { Amount = total };
        }

        public Money Percent(Percentage percentage)
        {
            return new Money { Amount = Math.Round(Amount * percentage.Value, 2) };
        }

        public override string ToString()
        {
            return $"${Amount}";
        }
    }
}
