using System;

namespace SharpenSkills.Logic
{
    public class Percentage : IPercentage
    {
        private decimal _value;
        public decimal Value { get => _value; set => SetValue(value); }

        public void SetValue(decimal value)
        {
            if (value < 0 || value > 1)
            {
                throw new ArgumentOutOfRangeException("Percentage value");
            }

            _value = value;
        }

        public override string ToString()
        {
            return $"{_value * 100}%";
        }
    }
}
