using SharpenSkills.Logic;

namespace SharpenSkills.Tests
{
    internal class Seeder
    {
        public Product SetupProduct()
        {
            return new Product
            {
                Name = "The Little Prince",
                Upc = "12345",
                Price = new Money { Amount = 20.25m },
            };
        }

        public Tax SetupTax()
        {
            return new Tax
            {
                Percentage = new Percentage { Value = 0.21m },
            };
        }
    }
}
