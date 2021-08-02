using System;
using System.Linq;

namespace NetworkDelayTime
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] times = new int[][]
                {
                    new int[]{ 2, 1, 1 },
                    new int[]{ 2, 3, 1 },
                    new int[]{ 3, 4, 1 }
                };
            Console.WriteLine(NetworkDelayTime(times, 4, 2));
        }

        static int NetworkDelayTime(int[][] times, int n, int k)
        {
            const int INF = int.MaxValue / 2;
            int[,] graph = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    graph[i, j] = INF;
                }
            }

            for (int i = 0; i < times.Length; i++)
            {
                int x = times[i][0] - 1, y = times[i][1] - 1;
                graph[x, y] = times[i][2];
            }

            int[] dist = new int[n];
            Array.Fill(dist, INF);
            dist[k - 1] = 0;

            bool[] isgetPath = new bool[n];

            for (int i = 0; i < n; i++)
            {
                int x = -1;
                for (int j = 0; j < n; j++)
                {
                    if (!isgetPath[j] && (x == -1 || dist[j] < dist[x]))
                    {
                        x = j;
                    }
                }

                isgetPath[x] = true;
                for (int y = 0; y < n; y++)
                {
                    dist[y] = Math.Min(dist[y], dist[x] + graph[x, y]);
                }
            }

            int ans = dist.Max();
            return ans == INF ? -1 : ans;

        }
    }
}
