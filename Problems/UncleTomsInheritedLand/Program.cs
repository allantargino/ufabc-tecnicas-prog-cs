using System;

namespace UncleTomsInheritedLand
{
    class Program
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
        
        public static int flat(int x, int y, int n, int m)
        {
            return m * x + y;
        }

        public static void Main(string[] args)
        {
            string[] input;

            while (true)
            {
                input = Console.ReadLine().Split(' ');
                int n = int.Parse(input[0]);
                int m = int.Parse(input[1]);

                if (n == 0 && m == 0)
                    break;

                int k = int.Parse(Console.ReadLine());

                bool[,] graph = new bool[n * m, n * m];
                bool[,] table = new bool[n, m];

                for (int i = 0; i < k; i++)
                {
                    input = Console.ReadLine().Split(' ');
                    table[int.Parse(input[0]) - 1, int.Parse(input[1]) - 1] = true;
                }

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (table[i, j] == false)
                        {
                            int node = flat(i, j, n, m);

                            // neighbors

                            // up
                            if ((i - 1) >= 0 && table[i - 1, j] == false)
                            {
                                graph[node, flat(i - 1, j, n, m)] = true;
                            }
                            //down
                            if ((i + 1) < n && table[i + 1, j] == false)
                            {
                                graph[node, flat(i + 1, j, n, m)] = true;
                            }
                            //left
                            if ((j - 1) >= 0 && table[i, j - 1] == false)
                            {
                                graph[node, flat(i, j - 1, n, m)] = true;
                            }
                            //right
                            if ((j + 1) < m && table[i, j + 1] == false)
                            {
                                graph[node, flat(i, j + 1, n, m)] = true;
                            }
                        }
                    }
                }

                int max = new GFG(m * n, m * n).MaxBPM(graph);
                Console.WriteLine(max / 2);
            }
        }
    }
}
