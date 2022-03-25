namespace Lab1_Market
{
    public interface IFood : IThing
    {
        bool Proteins { get; }
        bool Fats { get; } 
        bool Carbohydrates { get; }
    }
}