using System;

class URI
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

    public static void Main()
    {
        string[] input;

        int cases = int.Parse(Console.ReadLine());
        for (int i = 0; i < cases; i++)
        {

            // Set A
            input = Console.ReadLine().Split(' ');
            int m = int.Parse(input[0]);

            int[] setA = new int[m];
            for (int j = 0; j < m; j++)
                setA[j] = int.Parse(input[j + 1]);

            // Set B
            input = Console.ReadLine().Split(' ');
            int n = int.Parse(input[0]);

            int[] setB = new int[n];
            for (int j = 0; j < n; j++)
                setB[j] = int.Parse(input[j + 1]);

            bool[,] graph = new bool[m, n];

            for (int j = 0; j < m; j++)
            {
                var numA = setA[j];
                for (int k = 0; k < n; k++)
                {
                    var numB = setB[k];

                    if (numA == 0 && numB == 0)
                        graph[j, k] = true;
                    else if (numA != 0 && numB % numA == 0)
                        graph[j, k] = true;
                }
            }

            int max = new GFG(m, n).MaxBPM(graph);
            Console.WriteLine($"Case {i + 1}: {max}");

        }
    }
}