namespace Lab1_Market
{
    public class ChocolateBar : ISnacks
    {
        public string Name => "ChocolateBar";
        public bool Proteins => false;
        public bool Fats => false;
        public bool Carbohydrates => true;
    }
}