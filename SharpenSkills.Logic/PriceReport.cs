using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpenSkills.Logic
{
    public class PriceReport
    {
        public decimal Price { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }

        public PriceReport()
        {
            Price = 0;
            Tax = 0;
            Total = 0;
        }
    }
}
