using System.Collections.Generic;

namespace Lab1_Market
{
    public static class U_Market
    {
        public static List<IThing> Things { get; } = new()
        {
            new Pen(),
            new Notebook(),
            new ChocolateBar(),
            new Crisps(),
            new BalykCheese(),
            new Chicken(),
            new OliveOil(),
            new Fruit(),
            new DumplingsMeat(),
            new Cheburek(),
            new DumplingsBerries()
        };
    }
}