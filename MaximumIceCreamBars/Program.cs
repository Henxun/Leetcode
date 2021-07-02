using System;

namespace MaximumIceCreamBars
{
    class Program
    {
        static void Main(string[] args)
        {
            var costs = new int[]
            {
                1,3,2,4,1
            };
            int coins = 7;
            Console.WriteLine(MaxIceCream(costs, coins));
        }

        static int MaxIceCream(int[] costs, int coins)
        {
            Array.Sort(costs);
            int count = 0;
            foreach (var cost in costs)
            {
                if (coins >= cost)
                {
                    count++;
                    coins -= cost;
                }
                else
                    break;
            }
            return count;
        }
    }
}
