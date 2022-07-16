using System;
using System.Linq;
using WiredBrainCoffeeShop.DataAccess;

namespace WiredBrainCoffeeShopInfoTool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wired Brain Coffee Shop Info Tool");
            Console.WriteLine("Write help to list available commands");
            var coffeeShopDataProvider = new CoffeeShopDataProvider();
            while (true)
            {
                var line = Console.ReadLine();
                var coffeeShops = coffeeShopDataProvider.LoadCoffeeShops();
                if (string.Equals("help", line, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("> Available Coffee Shops commands: ");
                    foreach (var coffeeShop in coffeeShops)
                    {
                        Console.WriteLine($"> " + coffeeShop.Location);
                    }
                }
                else
                {
                    var foundCoffeeShops = coffeeShops
                        .Where (x => x.Location.StartsWith(line, StringComparison.OrdinalIgnoreCase)).ToList();
                    if (foundCoffeeShops.Count == 0)
                    {
                        Console.WriteLine($"> command '{line}' not found");
                    }
                    else if(foundCoffeeShops.Count == 1)
                    {
                        var coffeeShop = foundCoffeeShops.Single();
                        Console.WriteLine($"> Location: {coffeeShop.Location}");
                        Console.WriteLine($"> Beans in Stock: {coffeeShop.BeansInStockingInKg} kg ");
                    }
                    else
                    {
                        Console.WriteLine($"> Multiple matching coffee shop commands found");
                        foreach (var coffeType in foundCoffeeShops)
                        {
                            Console.WriteLine($"> {coffeType.Location}");
                        }
                    }


                }
            }
        }
                
                
    }
}
