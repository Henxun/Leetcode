using System;
using System.Collections.Generic;

namespace CountUnhappyFriends
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] preferences = new int[4][];
            preferences[0] = new int[3] { 1, 2, 3 };
            preferences[1] = new int[3] { 3, 2, 0 };
            preferences[2] = new int[3] { 3, 1, 0 };
            preferences[3] = new int[3] { 1, 2, 0 };

            int[][] pairs = new int[2][];
            pairs[0] = new int[2] { 0, 1 };
            pairs[1] = new int[2] { 2, 3 };
            Console.WriteLine(UnhappyFriends1(4, preferences, pairs));
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
            Array.Fill(match, -1);
            for (int i = 0; i < pairs.Length; i++)
            {
                match[pairs[i][0]] = pairs[i][1];
                match[pairs[i][1]] = pairs[i][0];
            }

            int unHappyCount = 0;
            for (int x = 0; x < n; x++)
            {
                int y = match[x];
                if (y == -1)
                    continue;
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
