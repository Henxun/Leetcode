using System;
using System.Collections.Generic;

namespace N_Queens
{
    class Program
    {
        static void Main(string[] args)
        {
            var solutions = SolveNQueens(6);
            foreach (var solution in solutions)
            {
                Console.WriteLine($"方案{solutions.IndexOf(solution)}");
                Console.WriteLine(string.Join("\r\n",solution));
            }

            var solutions1 = SolveNQueens1(6);
            foreach (var solution in solutions1)
            {
                Console.WriteLine($"方案{solutions1.IndexOf(solution)}");
                Console.WriteLine(string.Join("\r\n", solution));
            }

        }

        public static IList<IList<string>> SolveNQueens(int n)
        {
            IList<IList<string>> solutions = new List<IList<string>>();
            int[] queens = new int[n];
            Array.Fill(queens, -1);

            //哪些列能被皇后攻击
            HashSet<int> columns = new HashSet<int>();

            //哪些（行-列）右斜线能被皇后攻击
            HashSet<int> diagonals1 = new HashSet<int>();

            //哪些（行+列）左斜线能被皇后攻击
            HashSet<int> diagonals2 = new HashSet<int>();
            BackTrack(solutions, queens, n, 0, columns, diagonals1, diagonals2);
            return solutions;
        }

        static IList<IList<string>> SolveNQueens1(int n)
        {
            IList<IList<string>> solutions = new List<IList<string>>();
            int[] queens = new int[n];
            Array.Fill(queens, -1);
            BackTrack1(solutions, queens, n, 0, 0, 0, 0);
            return solutions;
        }

        /// <summary>
        /// 基于集合的回溯
        /// </summary>
        /// <param name="solutions"></param>
        /// <param name="queens"></param>
        /// <param name="n"></param>
        /// <param name="row"></param>
        /// <param name="columns"></param>
        /// <param name="diagonals1"></param>
        /// <param name="diagonals2"></param>
        static void BackTrack(IList<IList<string>> solutions, int[] queens, int n, int row, HashSet<int> columns, HashSet<int> diagonals1, HashSet<int> diagonals2)
        {
            if(row == n)
            {
                //一次摆盘结束
                IList<string> board = GenerateBoard(queens, n);
                solutions.Add(board);
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    //是否在皇后攻击的列
                    if(columns.Contains(i))
                    {
                        continue;
                    }

                    //是否在皇后攻击的右斜线
                    int diagonal1 = row - i;
                    if (diagonals1.Contains(diagonal1))
                    {
                        continue;
                    }

                    //是否在皇后攻击的左斜线
                    int diagonal2 = row + i;
                    if(diagonals2.Contains(diagonal2))
                    {
                        continue;
                    }

                    queens[row] = i;
                    columns.Add(i);

                    diagonals1.Add(diagonal1);
                    diagonals2.Add(diagonal2);

                    BackTrack(solutions, queens, n, row + 1, columns, diagonals1, diagonals2);

                    //回溯
                    queens[row] = -1;
                    columns.Remove(i);
                    diagonals1.Remove(diagonal1);
                    diagonals2.Remove(diagonal2);
                }
            }
        }


        /// <summary>
        /// 基于位运算的回溯  
        /// 根据前面的位置生成下一行不能放置的位置
        /// </summary>
        /// <param name="solutions"></param>
        /// <param name="queens"></param>
        /// <param name="n"></param>
        /// <param name="row"></param>
        /// <param name="columns"></param>
        /// <param name="diagonals1"></param>
        /// <param name="diagonals2"></param>
        /// <returns></returns>
        static IList<IList<string>> BackTrack1(IList<IList<String>> solutions, int[] queens, int n, int row, int columns, int diagonals1, int diagonals2)
        {
            if (row == n)
            {
                IList<String> board = GenerateBoard(queens, n);
                solutions.Add(board);
            }
            else
            {
                int availablePositions = ((1 << n) - 1) & (~(columns | diagonals1 | diagonals2));
                while (availablePositions != 0)
                {
                    //x & (−x) 可以获得 xx 的二进制表示中的最低位的1的位置；
                    //x & (x - 1) 可以将 xx 的二进制表示中的最低位的1置成0。
                    int position = availablePositions & (-availablePositions);
                    availablePositions = availablePositions & (availablePositions - 1);
                    int column = BitCount(position - 1);
                    queens[row] = column;
                    //columns | position (被皇后攻击的列），(diagonals1 | position) << 1 （被皇后攻击的左斜线方向），(diagonals2 | position) >> 1) （被皇后攻击的右斜线方向）
                    BackTrack1(solutions, queens, n, row + 1, columns | position, (diagonals1 | position) << 1, (diagonals2 | position) >> 1);
                    queens[row] = -1;
                }
            }
            return solutions;
        }

        static List<string> GenerateBoard(int[] queens, int n)
        {
            List<string> board = new List<string>();

            for (int i = 0; i < n; i++)
            {
                char[] row = new char[n];
                Array.Fill(row, '.');
                row[queens[i]] = 'Q';
                board.Add(string.Join("", row));
            }
            return board;
        }

        static int BitCount(int n)
        {
            int count = 0;
            while (true)
            {
                if (n % 2 == 1)
                    count++;

                if (n/2 == 0)
                {
                    break;
                }

                n /= 2;
            }
            return count;
        }
    }
}
