namespace SharpenSkills.Logic
{
    public class Product : IProduct
    {
        public string Name { get; set; }
        public string Upc { get; set; }
        public Money Price { get; set; }
    }
}
