using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Lab1_Market
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> categories = new()
            {
                "Snacks",
                "HealthyFood",
                "SemiFinishedFood",
                "All food"
            };

            Console.WriteLine("Welcome to U-Market!");
            Console.WriteLine("Please choose category:");
            for (var i = 0; i < categories.Count; i++)
                Console.WriteLine(i + 1 + ". " + categories[i]);

            int choose = ReadLineOfRange(1, categories.Count);

            Console.WriteLine("You select: " + categories[choose - 1].ToLower());

            switch (choose)
            {
                case 1:
                    new Cart<ISnacks>().PrintThings();
                    break;

                case 2:
                    new Cart<IHealthyFood>().PrintThings();
                    break;

                case 3:
                    new Cart<ISemiFinishedFood>().PrintThings();
                    break;

                case 4:
                    new Cart<IFood>().PrintThings();
                    break;
            }
        }

        public static int ReadLineOfRange(int f, int s)
        {
            while (true)
            {
                string line = Console.ReadLine();
                if (line != null && Regex.IsMatch(line, "[0-9]"))
                {
                    int i = Convert.ToInt32(line);
                    if (f <= i && i <= s)
                    {
                        return i;
                    }
                }

                Console.WriteLine($"Enter an integer from {f} to {s}");
            }
        }
    }
}