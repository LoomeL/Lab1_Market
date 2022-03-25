namespace Lab1_Market
{
    public class Chicken : IHealthyFood
    {
        public string Name => "Chicken";
        public bool Proteins => true;
        public bool Fats => false;
        public bool Carbohydrates => false;
    }
}