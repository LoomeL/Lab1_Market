namespace Lab1_Market
{
    public class OliveOil : IHealthyFood
    {
        public string Name => "OliveOil";
        public bool Proteins => false;
        public bool Fats => true;
        public bool Carbohydrates => false;
    }
}