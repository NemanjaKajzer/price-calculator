using SharpenSkills.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
