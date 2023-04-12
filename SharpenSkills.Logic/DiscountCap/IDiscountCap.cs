namespace SharpenSkills.Logic
{
    public interface IDiscountCap
    {
        Money ApplyDiscountCap(Money discountTotal, Money price);
    }
}
