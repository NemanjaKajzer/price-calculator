namespace SharpenSkills.Logic
{
    public class Currency : ICurrency
    {
        public string IsoCode { get; set; }
        public string Symbol { get; set; }

        public override string ToString()
        {
            return Symbol;
        }
    }
}
