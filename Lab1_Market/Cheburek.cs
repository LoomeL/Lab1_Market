namespace Lab1_Market
{
    public class Cheburek : ISemiFinishedFood
    {
        public string Name => "Cheburek";
        public bool Proteins => false;
        public bool Fats => true;
        public bool Carbohydrates => false;
    }
}