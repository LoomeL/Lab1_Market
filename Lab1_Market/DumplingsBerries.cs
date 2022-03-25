namespace Lab1_Market
{
    public class DumplingsBerries : ISemiFinishedFood
    {
        public string Name => "DumplingsBerries";
        public bool Proteins => false;
        public bool Fats => false;
        public bool Carbohydrates => true;
    }
}