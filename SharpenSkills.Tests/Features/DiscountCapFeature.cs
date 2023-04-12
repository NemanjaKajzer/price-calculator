using SharpenSkills.Logic;
using SharpenSkills.Logic.DiscountCap;

namespace SharpenSkills.Tests
{
    public class DiscountCapFeature
    {
        [Test]
        public void When_DiscountGreaterThanPercentageCap_CapPercentageOfOriginalPriceShouldBeUsedAsDiscountTotal()
        {
            var tax = new Tax(0.21m);

            var discount = new Discount(0.15m);
            var selectiveDiscount = new SelectiveDiscount(0.07m, "12345");

            var cap = new PercentageDiscountCap(0.2m);

            var product = new Product
            {
                Name = "The Little Prince",
                Upc = "12345",
                Price = new Money(20.25m),
            };

            var calculator = new PriceCalculator()
                .WithTax(tax)
                .WithDiscountAfterTax(discount)
                .WithDiscountAfterTax(selectiveDiscount)
                .WithDiscountCap(cap);

            var report = calculator.Calculate(product);

            var expectedString = "Cost = $20.25\n" +
                                      "Tax = $4.25\n" +
                                      "Discounts = $4.05\n" +
                                      "TOTAL = $20.45";

            Assert.IsNotNull(report);
            Assert.AreEqual(expectedString, report.ToString());
        }

        [Test]
        public void When_DiscountGreaterThanAbsoluteCap_CapValueShouldBeUsedAsDiscountTotal()
        {
            var tax = new Tax(0.21m);

            var discount = new Discount(0.15m);
            var selectiveDiscount = new SelectiveDiscount(0.07m, "12345");

            var cap = new AbsoluteDiscountCap(4.00m);

            var product = new Product
            {
                Name = "The Little Prince",
                Upc = "12345",
                Price = new Money(20.25m),
            };

            var calculator = new PriceCalculator()
                .WithTax(tax)
                .WithDiscountAfterTax(discount)
                .WithDiscountAfterTax(selectiveDiscount)
                .WithDiscountCap(cap);

            var report = calculator.Calculate(product);

            var expectedString = "Cost = $20.25\n" +
                                      "Tax = $4.25\n" +
                                      "Discounts = $4.00\n" +
                                      "TOTAL = $20.50";

            Assert.IsNotNull(report);
            Assert.AreEqual(expectedString, report.ToString());
        }

        [Test]
        public void When_DiscountLessThanPercentageCap_OriginalDiscountTotalShouldBeApplied()
        {
            var tax = new Tax(0.21m);

            var discount = new Discount(0.15m);
            var selectiveDiscount = new SelectiveDiscount(0.07m, "12345");

            var cap = new PercentageDiscountCap(0.3m);

            var product = new Product
            {
                Name = "The Little Prince",
                Upc = "12345",
                Price = new Money(20.25m),
            };

            var calculator = new PriceCalculator()
                .WithTax(tax)
                .WithDiscountAfterTax(discount)
                .WithDiscountAfterTax(selectiveDiscount)
                .WithDiscountCap(cap);

            var report = calculator.Calculate(product);

            var expectedString = "Cost = $20.25\n" +
                                      "Tax = $4.25\n" +
                                      "Discounts = $4.46\n" +
                                      "TOTAL = $20.04";

            Assert.IsNotNull(report);
            Assert.AreEqual(expectedString, report.ToString());
        }
    }
}
