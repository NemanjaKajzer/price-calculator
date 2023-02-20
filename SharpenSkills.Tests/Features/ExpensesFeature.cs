using SharpenSkills.Logic;

namespace SharpenSkills.Tests
{
    public class ExpensesFeature
    {
        [Test]
        public void When_AbsoluteAndPercentageCostsSpecified_BothShouldBeApplied()
        {
            var tax = new Tax(0.21m);
            var discount = new Discount(0.15m);
            var selectiveDiscount = new SelectiveDiscount(0.07m, "12345");
            var product = new Product
            {
                Name = "The Little Prince",
                Upc = "12345",
                Price = new Money(20.25m),
            };
            var packagingExpense = new PercentageExpense(0.01m, "Packaging");
            var transportExpense = new AbsoluteExpense(2.2m, "Transport");

            var builder = new PriceReportBuilder();
            var report = builder
                .WithProduct(product)
                .WithTax(tax)
                .WithDiscountAfterTax(discount)
                .WithDiscountAfterTax(selectiveDiscount)
                .WithExpense(packagingExpense)
                .WithExpense(transportExpense)
                .Build();

            var expectedString = "Cost = $20.25\n" +
                                      "Tax = $4.25\n" +
                                      "Discounts = $4.46\n" +
                                      "Packaging = $0.20\n" +
                                      "Transport = $2.2\n" +
                                      "TOTAL = $22.44";

            Assert.IsNotNull(report);
            Assert.AreEqual(expectedString, report.ToString());
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

            var builder = new PriceReportBuilder();

            var report = builder
                .WithProduct(product)
                .WithTax(tax)
                .Build();

            var expectedString = "Cost = $20.25\n" +
                                      "Tax = $4.25\n" +
                                      "TOTAL = $24.50";

            Assert.IsNotNull(report);
            Assert.AreEqual(expectedString, report.ToString());
        }
    }
}
