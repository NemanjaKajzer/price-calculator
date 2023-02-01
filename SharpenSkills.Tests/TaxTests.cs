using SharpenSkills.Logic;

namespace SharpenSkills.Tests
{
    public class PriceReportTests
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
                Price = new Money { Amount = 20.25m },
            };

            _tax = new Tax
            {
                Percentage = new Percentage { Value = 0.21m },
            };
        }

        [Test]
        public void When_OnlyPriceSpecified_DefaultTaxShouldBeApplied()
        {
            var builder = new PriceReportBuilder();
            var report = builder.ApplyProduct(_product)
                .Build();


            Assert.IsNotNull(report);
            Assert.AreEqual(20.25, report.Price.Amount);
            Assert.AreEqual(24.30, report.Total.Amount);
        }

        [Test]
        public void When_PriceAndTaxSpecified_CustomTaxShouldBeApplied()
        {
            var builder = new PriceReportBuilder();

            var report = builder.ApplyProduct(_product)
                .ApplyTax(_tax)
                .Build();

            Assert.IsNotNull(report);
            Assert.AreEqual(20.25, report.Price.Amount);
            Assert.AreEqual(24.50, report.Total.Amount);
        }
    }
}