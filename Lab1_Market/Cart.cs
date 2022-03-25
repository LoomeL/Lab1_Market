using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace Lab1_Market
{
    public class Cart<T> where T : IThing
    {
        public List<IThing> filteredThings = new();
        public List<T> cart = new();

        public void PrintThings()
        {
            if (typeof(T) == typeof(IThing))
            {
                filteredThings.Add(new Pen());
                filteredThings.Add(new Notebook());
            }
            else
            {
                foreach (IThing thing in U_Market.Things)
                {
                    if (thing is T) filteredThings.Add(thing);
                }
            }

            while (true)
            {
                Console.WriteLine("Main menu:");
                Console.WriteLine("1 - Add things to cart");
                Console.WriteLine("2 - Print cart");
                if (typeof(T) != typeof(IThing)) Console.WriteLine("3 - Balansing cart");

                int choose1 = Program.ReadLineOfRange(1, typeof(T) == typeof(IThing) ? 2 : 3);

                if (choose1 == 1)
                {
                    while (true)
                    {
                        Console.WriteLine("Select item to add to cart");
                        Console.WriteLine("0 - to main menu");

                        for (var i = 0; i < filteredThings.Count; i++)
                        {
                            Console.WriteLine(i + 1 + ". " + filteredThings[i].Name);
                        }

                        int choose = Program.ReadLineOfRange(0, filteredThings.Count);

                        if (choose == 0)
                        {
                            break;
                        }
                        else
                        {
                            cart.Add((T) filteredThings[choose - 1]);
                        }
                    }
                }
                else if (choose1 == 2)
                {
                    PrintCart();
                }
                else if (choose1 == 3)
                {
                    if (cart.Count == 0)
                    {
                        Console.WriteLine("Your cart empty");
                        continue;
                    }

                    Dictionary<string, int> cart1 = new();
                    cart1.Add("Proteins", 0);
                    cart1.Add("Fats", 0);
                    cart1.Add("Carbohydrates", 0);
                    List<KeyValuePair<string, int>> cart2 = cart1.ToList();

                    foreach (var thing1 in cart)
                    {
                        var thing = (IFood) thing1;
                        if (thing.Proteins) cart1["Proteins"] += 1;
                        if (thing.Fats) cart1["Fats"] += 1;
                        if (thing.Carbohydrates) cart1["Carbohydrates"] += 1;
                    }

                    int ii = 0;
                    foreach (var keyValuePair in cart1.OrderBy(pair => pair.Value).Reverse().ToList())
                    {
                        if (ii == 0)
                        {
                            ii = keyValuePair.Value;
                            continue;
                        }

                        bool hasBalancing = false;
                        List<T> lastCart = cart;
                        foreach (var thing1 in lastCart)
                        {
                            var thing = (IFood) thing1;
                            if ((bool) thing.GetType().GetProperty(keyValuePair.Key).GetValue(thing, null))
                            {
                                for (int i = 0; i < ii - keyValuePair.Value; i++)
                                {
                                    cart.Add((T) thing);
                                }

                                hasBalancing = true;
                                break;
                            }
                        }
                        if (hasBalancing) continue;
                        foreach (var thing1 in U_Market.Things)
                        {
                            if (thing1 is IFood)
                            {
                                var thing = (IFood) thing1;
                                if ((bool) thing.GetType().GetProperty(keyValuePair.Key).GetValue(thing, null))
                                {
                                    for (int i = 0; i < ii - keyValuePair.Value; i++)
                                    {
                                        cart.Add((T) thing);
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void PrintCart()
        {
            if (cart.Count == 0)
            {
                Console.WriteLine("Your cart empty");
                return;
            }

            Dictionary<T, int> cart1 = new();
            Console.Write("In your cart: ");
            foreach (T thing in cart)
            {
                if (!cart1.TryGetValue(thing, out int i))
                {
                    cart1.Add(thing, 1);
                }
                else
                {
                    cart1[thing] += 1;
                }
            }

            foreach (var keyValuePair in cart1)
            {
                Console.Write(keyValuePair.Value + " x " + keyValuePair.Key.Name + "; ");
            }

            Console.WriteLine("");
        }
    }
}