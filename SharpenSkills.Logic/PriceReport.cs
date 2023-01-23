using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpenSkills.Logic
{
    public class PriceReport
    {
        //public string Name { get; set; }
        //public int Upc { get; set; }
        public double Price { get; set; }
        public double Tax { get; set; }
        //public double Discount { get; set; }
        public double Total { get; set; }

        public PriceReport()
        {
            Price = 0;
            Tax = 0;
            Total = 0;
        }
    }
}
