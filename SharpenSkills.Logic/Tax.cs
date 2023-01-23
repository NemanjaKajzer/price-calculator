namespace SharpenSkills.Logic
{
    public class Tax
    {
        public double Percentage { get; set; }

        public Tax()
        {
            // default percentage is applied when creating new Tax object
            Percentage = 20;
        }
    }
}
