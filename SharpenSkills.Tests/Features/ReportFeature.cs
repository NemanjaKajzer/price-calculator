using SharpenSkills.Logic;

namespace SharpenSkills.Tests
{
    public class ReportFeature
    {
        [Test]
        public void When_DiscountApplied_ReportShouldShowDiscountedAmount()
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

            var expectedString = "Cost = $20.25\n" +
                                      "Tax = $4.05\n" +
                                      "Discounts = $3.04\n" +
                                      "TOTAL = $21.26";

            Assert.IsNotNull(report);
            Assert.AreEqual(expectedString, report.ToString());
        }

        [Test]
        public void When_DiscountNotApplied_ReportShouldNotShowDiscountedAmount()
        {
            var product = new Product
            {
                Name = "The Little Prince",
                Upc = "12345",
                Price = new Money(20.25m),
            };

            var calculator = new PriceCalculator();

            var report = calculator.Calculate(product);

            var expectedString = "Cost = $20.25\n" +
                                      "Tax = $4.05\n" +
                                      "TOTAL = $24.30";

            Assert.IsNotNull(report);
            Assert.AreEqual(expectedString, report.ToString());
        }
    }
}
