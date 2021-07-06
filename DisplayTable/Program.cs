using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DisplayTable
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<IList<string>> orders = new List<IList<string>>();
            orders = new List<IList<string>>();
            orders.Add(new List<string>() { "pKKgO", "1", "qgGxK" });
            orders.Add(new List<string>() { "ZgW", "3", "XfuBe" });
            var ordersTable = DisplayTable(orders);
            foreach (var order in ordersTable)
            {
                Console.WriteLine(string.Join("\t", order));
            }
    }

        static IList<IList<string>> DisplayTable(IList<IList<string>> orders)
        {            
            //食物集合
            HashSet<string> foods = new HashSet<string>();

            //每桌订单
            Dictionary<int,Dictionary<string, int>> foodsCnt = new Dictionary<int, Dictionary<string, int>>();
            foreach (var order in orders)
            {
                foods.Add(order[2]);
                int table = int.Parse(order[1]);
                Dictionary<string, int> dic = foodsCnt.ContainsKey(table) ? foodsCnt[table] : new Dictionary<string, int>();
                if(dic.ContainsKey(order[2]))
                {
                    ++dic[order[2]];
                }
                else
                {
                    dic.Add(order[2], 1);
                }
                foodsCnt[table] = dic;
            }

            List<string> foodsName = foods.Select(s => s).ToList();
            foodsName.Sort((a, b) => { return string.CompareOrdinal(a, b); });

            IList<IList<string>> ordersTable = new List<IList<string>>();
            ordersTable.Add(new List<string> { "Table" });
            foreach (var food in foodsName)
            {
                ordersTable[0].Add(food);
            }

            foreach (var order in foodsCnt.OrderBy(s=>s.Key))
            {
                IList<string> o = new List<string>();
                o.Add(order.Key.ToString());
                foreach (var food in foodsName)
                {
                    o.Add(order.Value.ContainsKey(food) ? order.Value[food].ToString() : "0");
                }
                ordersTable.Add(o);
            }

            return ordersTable;
        }
    }
}
