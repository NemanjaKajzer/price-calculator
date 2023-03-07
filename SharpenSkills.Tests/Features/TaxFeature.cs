using SharpenSkills.Logic;

namespace SharpenSkills.Tests
{
    public class TaxFeature
    {
        private Product _product { get; set; }
        private Tax _tax { get; set; }

        [SetUp]
        public void Setup()
        {
            _product = new Product
            {
                Name = "The Little Prince",
                Upc = "12345",
                Price = new Money(20.25m),
            };

            _tax = new Tax(0.21m);
        }

        [Test]
        public void When_OnlyPriceSpecified_DefaultTaxShouldBeApplied()
        {
            var builder = new ConfigurationBuilder();
            var report = builder
                .WithProduct(_product)
                .Build();

            Assert.IsNotNull(report);
            Assert.AreEqual("$20.25", report.Price.ToString());
            Assert.AreEqual("$24.30", report.Total.ToString());
        }

        [Test]
        public void When_PriceAndTaxSpecified_CustomTaxShouldBeApplied()
        {
            var builder = new ConfigurationBuilder();

            var report = builder
                .WithProduct(_product)
                .WithTax(_tax)
                .Build();

            Assert.IsNotNull(report);
            Assert.AreEqual("$20.25", report.Price.ToString());
            Assert.AreEqual("$24.50", report.Total.ToString());
        }
    }
}