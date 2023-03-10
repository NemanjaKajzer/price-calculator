using SharpenSkills.Logic;

namespace SharpenSkills.Tests
{
    public class TaxFeature
    {
        [Test]
        public void When_OnlyPriceSpecified_DefaultTaxShouldBeApplied()
        {
            var product = new Product
            {
                Name = "The Little Prince",
                Upc = "12345",
                Price = new Money(20.25m),
            };

            var calculator = new PriceCalculator();
            var report = calculator.Calculate(product);

            Assert.IsNotNull(report);
            Assert.AreEqual("$20.25", report.Price.ToString());
            Assert.AreEqual("$24.30", report.Total.ToString());
        }

        [Test]
        public void When_PriceAndTaxSpecified_CustomTaxShouldBeApplied()
        {
            var product = new Product
            {
                Name = "The Little Prince",
                Upc = "12345",
                Price = new Money(20.25m),
            };

            var tax = new Tax(0.21m);

            var calculator = new PriceCalculator()
                .WithTax(tax);

            var report = calculator.Calculate(product);

            Assert.IsNotNull(report);
            Assert.AreEqual("$20.25", report.Price.ToString());
            Assert.AreEqual("$24.50", report.Total.ToString());
        }
    }
}