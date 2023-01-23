using SharpenSkills.Logic;

namespace SharpenSkills.Tests
{
    public class Tests
    {
        private Product _product { get; set; }
        private Tax _tax { get; set; }

        [SetUp]
        public void Setup()
        {
            _product = new Product()
            {
                Name = "The Little Prince",
                Upc = 12345,
                Price = 20.25,
            };

            _tax = new Tax
            {
                Percentage = 21,
            };
        }

        [Test]
        public void When_OnlyPriceSpecified_ReportShouldBeCorrect()
        {
            var director = new Director();

            var report = director.CreatePriceReport(_product, null);

            Assert.IsNotNull(report);
            Assert.AreEqual(20.25, report.Price);
            Assert.AreEqual(24.30, report.Total);
        }

        [Test]
        public void When_PriceAndTaxSpecified_ReportShouldBeCorrect()
        {
            var director = new Director();

            var report = director.CreatePriceReport(_product, _tax);

            Assert.IsNotNull(report);
            Assert.AreEqual(20.25, report.Price);
            Assert.AreEqual(24.50, report.Total);
        }

        [Test]
        public void When_TaxOutOfRange_ShouldThrowArgumentOutOfRangeException()
        {
            var director = new Director();

            var tax = new Tax
            {
                Percentage = -25,
            };

            Assert.Throws<ArgumentOutOfRangeException>(() => director.CreatePriceReport(_product, tax));
        }
    }
}