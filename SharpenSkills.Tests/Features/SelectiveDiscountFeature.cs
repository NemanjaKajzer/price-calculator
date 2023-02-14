using SharpenSkills.Logic;

namespace SharpenSkills.Tests
{
    public class SelectiveDiscountFeature
    {
        [Test]
        public void When_SelectiveDiscountHasSameUpc_DiscountShouldBeApplied()
        {
            var discount = new Discount(0.15m);
            var selectiveDiscount = new Discount(0.07m, "12345");
            var product = new Product
            {
                Name = "The Little Prince",
                Upc = "12345",
                Price = new Money(20.25m),
            };

            var builder = new PriceReportBuilder();
            var report = builder
                .WithProduct(product)
                .WithDiscount(discount)
                .WithDiscount(selectiveDiscount)
                .Build();

            var expectedString = "Cost = $20.25\n" +
                                       "Tax = $4.05\n" +
                                       "Discounts = $4.46\n" +
                                       "TOTAL = $19.84";

            Assert.IsNotNull(report);
            Assert.AreEqual(expectedString, report.ToString());
        }

        [Test]
        public void When_SelectiveDiscountHasDifferentUpc_DiscountShouldNotBeApplied()
        {
            var product = new Product
            {
                Name = "The Little Prince",
                Upc = "12345",
                Price = new Money(20.25m),
            };

            var tax = new Tax(0.21m);

            var discount = new Discount(0.15m);
            var selectiveDiscount = new Discount(0.07m, "789");

            var builder = new PriceReportBuilder();
            var report = builder
                .WithProduct(product)
                .WithTax(tax)
                .WithDiscount(discount)
                .WithDiscount(selectiveDiscount)
                .Build();

            var expectedString = "Cost = $20.25\n" +
                                       "Tax = $4.25\n" +
                                       "Discounts = $3.04\n" +
                                       "TOTAL = $21.46";

            Assert.IsNotNull(report);
            Assert.AreEqual(expectedString, report.ToString());
        }
    }
}
