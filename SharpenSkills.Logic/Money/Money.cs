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

        public static Money operator +(Money left, Money right)
        {
            return new Money { Amount = left.Amount + right.Amount };
        }

        public static Money operator -(Money left, Money right)
        {
            return new Money { Amount = left.Amount - right.Amount };
        }

        public static Money operator *(Money left, decimal right)
        {
            return new Money { Amount = Math.Round(left.Amount * right, 2) };
        }

        public static Money operator *(Money left, Percentage right)
        {
            return new Money { Amount = Math.Round(left.Amount * right.Value, 2) };
        }

        public static Money operator /(Money left, decimal right)
        {
            return new Money { Amount = Math.Round(left.Amount / right, 2) };
        }

        public Money Percent(Percentage percentage)
        {
            return new Money { Amount = Math.Round(Amount * percentage.Value, 2) };
        }

        public static bool operator ==(Money left, Money right)
        {
            return left.Amount == right.Amount;
        }

        public static bool operator !=(Money left, Money right)
        {
            return left.Amount != right.Amount;
        }

        public override string ToString()
        {
            return $"${Amount}";
        }

        public override bool Equals(object obj)
        {
            return obj is Money money &&
                   Amount == money.Amount;
        }

        public override int GetHashCode()
        {
            return -602769199 + Amount.GetHashCode();
        }
    }
}
