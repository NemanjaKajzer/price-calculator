using System;

namespace SharpenSkills.Logic
{
    public class PriceReportBuilder
    {
        private PriceReport Report { get; set; }

        public void Reset() { Report = new PriceReport(); }

        public void ApplyPrice(decimal price)
        {
            Report.Price = Math.Round(price, 2);
        }

        public void ApplyTax(decimal taxPct)
        {
            Report.Tax = Math.Round(Report.Price * taxPct / 100, 2);
        }

        public void CalculateTotal()
        {
            Report.Total = Report.Price + Report.Tax;
        }

        public PriceReport GetReport() { return Report; }
    }
}
