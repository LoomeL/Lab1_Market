namespace Lab1_Market
{
    public class DumplingsMeat : ISemiFinishedFood
    {
        public string Name => "DumplingsMeat";
        public bool Proteins => true;
        public bool Fats => false;
        public bool Carbohydrates => false;
    }
}