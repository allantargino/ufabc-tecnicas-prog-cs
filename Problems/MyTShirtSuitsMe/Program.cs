using System;

namespace MyTShirtSuitsMe
{
    public class Program
    {
        public class GFG
        {
            private int M;
            private int N;

            public GFG(int m, int n)
            {
                M = m;
                N = n;
            }

            public bool Bpm(bool[,] bpGraph, int u,
                     bool[] seen, int[] matchR)
            {
                for (int v = 0; v < N; v++)
                {
                    if (bpGraph[u, v] && !seen[v])
                    {
                        seen[v] = true;

                        if (matchR[v] < 0 || Bpm(bpGraph, matchR[v], seen, matchR))
                        {
                            matchR[v] = u;
                            return true;
                        }
                    }
                }
                return false;
            }

            public int MaxBPM(bool[,] bpGraph)
            {
                int[] matchR = new int[N];

                for (int i = 0; i < N; ++i)
                    matchR[i] = -1;

                int result = 0;
                for (int u = 0; u < M; u++)
                {
                    bool[] seen = new bool[N];
                    for (int i = 0; i < N; ++i)
                        seen[i] = false;

                    if (Bpm(bpGraph, u, seen, matchR))
                        result++;
                }
                return result;
            }
        }

        public enum Size
        {
            XS = 0,
            S = 1,
            M = 2,
            L = 3,
            XL = 4,
            XXL = 5
        }

        public static void Main()
        {
            string[] input;

            int cases = int.Parse(Console.ReadLine());
            for (int i = 0; i < cases; i++)
            {
                try
                {
                    input = Console.ReadLine().Split(' ');
                    int n = int.Parse(input[0]);
                    int m = int.Parse(input[1]);

                    bool[,] graph = new bool[m, n];

                    for (int j = 0; j < m; j++)
                    {
                        input = Console.ReadLine().Split(' ');

                        for (int k = 0; k < n / 6; k++)
                        {
                            graph[j, (int)Enum.Parse(typeof(Size), input[0]) + k * 6] = true;
                            graph[j, (int)Enum.Parse(typeof(Size), input[1]) + k * 6] = true;
                        }
                    }

                    int max = new GFG(m, n).MaxBPM(graph);
                    if (max >= m)
                        Console.WriteLine("YES");
                    else
                        Console.WriteLine("NO");
                }
                catch (Exception)
                {
                    Console.WriteLine("NO");
                }
            }
        }
    }
}
