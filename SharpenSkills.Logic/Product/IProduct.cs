namespace SharpenSkills.Logic
{
    public interface IProduct
    {
        string Name { get; set; }
        string Upc { get; set; }
        Money Price { get; set; }
    }
}
