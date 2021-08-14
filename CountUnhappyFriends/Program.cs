using System;
using System.Collections.Generic;

namespace CountUnhappyFriends
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static int UnhappyFriends(int n, int[][] preferences, int[][] pairs)
        {
            Dictionary<int, Dictionary<int, int>> order = new Dictionary<int, Dictionary<int, int>>();
            for (int i = 0; i < n; i++)
            {
                Dictionary<int, int> o = new Dictionary<int, int>();
                for (int j = 0; j < n - 1; j++)
                {
                    o.Add(preferences[i][j], n - j);
                }
                order.Add(i, o);
            }

            int ret = 0, m = pairs.Length;
            for (int i = 0; i < m; i++)
            {
                int x = pairs[i][0], y = pairs[i][1];

                bool xUnHappy = false, yUnHappy = false;
                for (int j = 0; j < m; j++)
                {
                    if (i == j)
                        continue;
                    int u = pairs[j][0], v = pairs[j][1];
                    if (!xUnHappy && Check(order, x, y, u, v)) xUnHappy = true;
                    if (!yUnHappy && Check(order, y, x, u, v)) yUnHappy = true;
                    if (xUnHappy && yUnHappy)
                        break;
                }
                if (xUnHappy) ret++;
                if (yUnHappy) ret++;
            }
            return ret;
        }

        static bool Check(Dictionary<int, Dictionary<int, int>> order, int x, int y, int u, int v)
        {
            if (order[x][u] > order[x][y] && order[u][x] > order[u][v]) return true;
            if (order[x][v] > order[x][y] && order[v][x] > order[v][u]) return true;
            return false;
        }

        static int UnhappyFriends1(int n, int[][] preferences, int[][] pairs)
        {
            int[,] order = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n - 1; j++)
                {
                    order[i, preferences[i][j]] = j;
                }
            }

            int[] match = new int[n];
            for (int i = 0; i < pairs.Length; i++)
            {
                match[pairs[i][0]] = pairs[i][1];
                match[pairs[i][1]] = pairs[i][0];
            }

            int unHappyCount = 0;
            for (int x = 0; x < n; x++)
            {
                int y = match[x];
                int index = order[x, y];

                for (int i = 0; i < index; i++)
                {
                    int u = preferences[x][i];
                    int v = match[u];
                    if (order[u, x] < order[u, v])
                    {
                        unHappyCount++;
                        break;
                    }                    
                }
            }
            return unHappyCount;
        }
    }
}
