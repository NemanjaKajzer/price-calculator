﻿using SharpenSkills.Logic;

namespace SharpenSkills.Tests
{
    public class PrecedenceFeature
    {
        [Test]
        public void When_DiscountBeforeTax_TaxShouldBeAppliedToDiscountedPrice()
        {
            var product = new Product
            {
                Name = "The Little Prince",
                Upc = "12345",
                Price = new Money(20.25m),
            };

            var discount = new Discount(0.15m);
            var selectiveDiscount = new SelectiveDiscount(0.07m, "12345");

            var expectedString = "Cost = $20.25\n" +
                                      "Tax = $3.77\n" +
                                      "Discounts = $4.24\n" +
                                      "TOTAL = $19.78";

            var calculator = new PriceCalculator()
                .WithDiscountAfterTax(discount)
                .WithDiscountBeforeTax(selectiveDiscount);

            var result = calculator.Calculate(product);

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedString, result.ToString());
        }
    }
}
