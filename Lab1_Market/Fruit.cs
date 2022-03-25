namespace Lab1_Market
{
    public class Fruit : IHealthyFood
    {
        public string Name => "Fruit";
        public bool Proteins => false;
        public bool Fats => false;
        public bool Carbohydrates => true;
    }
}