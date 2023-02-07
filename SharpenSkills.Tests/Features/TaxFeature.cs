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
            var seeder = new Seeder();

            _product = seeder.SetupProduct();
            _tax = seeder.SetupTax();
        }

        [Test]
        public void When_OnlyPriceSpecified_DefaultTaxShouldBeApplied()
        {
            var builder = new PriceReportBuilder();
            var report = builder
                .ApplyProduct(_product)
                .Build();


            Assert.IsNotNull(report);
            Assert.AreEqual(20.25, report.Price.Amount);
            Assert.AreEqual(24.30, report.Total.Amount);
        }

        [Test]
        public void When_PriceAndTaxSpecified_CustomTaxShouldBeApplied()
        {
            var builder = new PriceReportBuilder();

            var report = builder
                .ApplyProduct(_product)
                .ApplyTax(_tax)
                .Build();

            Assert.IsNotNull(report);
            Assert.AreEqual(20.25, report.Price.Amount);
            Assert.AreEqual(24.50, report.Total.Amount);
        }
    }
}