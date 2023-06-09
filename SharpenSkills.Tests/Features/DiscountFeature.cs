﻿using SharpenSkills.Logic;

namespace SharpenSkills.Tests
{
    public class DiscountFeature
    {
        [Test]
        public void When_OnlyDiscountSpecified_DefaultTaxAndDiscountShouldBeApplied()
        {
            var product = new Product
            {
                Name = "The Little Prince",
                Upc = "12345",
                Price = new Money(20.25m),
            };

            var discount = new Discount(0.15m);

            var calculator = new PriceCalculator()
                .WithDiscountAfterTax(discount);

            var report = calculator.Calculate(product);

            Assert.IsNotNull(report);
            Assert.AreEqual("$20.25", report.Price.ToString());
            Assert.AreEqual("$21.26", report.Total.ToString());
        }
    }
}
