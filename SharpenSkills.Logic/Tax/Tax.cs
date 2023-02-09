﻿namespace SharpenSkills.Logic
{
    public class Tax : ITax
    {
        public Percentage Percentage { get; set; }

        public Tax(decimal value)
        {
            Percentage = new Percentage { Value = value };
        }
    }
}
