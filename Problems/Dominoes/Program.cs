using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Dominoes
{
    static class Program
    {
        static void Main(string[] args)
        {
            var parametersLine = Console.ReadLine();
            var parameters = InputProcessor.ExtractParameters(parametersLine);

            int n = parameters.Item1;
            int k = parameters.Item2;

            var dominoes = new List<Domino>();
            for (int i = 0; i < n; i++)
            {
                var dominoLine = Console.ReadLine();
                dominoes.Add(InputProcessor.ExtractDomino(dominoLine));
            }

            var solution = BackTracking(dominoes, new List<Domino>(), k);
            WriteSolution(solution);
        }

        static void WriteSolution(IList<Domino> solution)
        {
            if (solution == null)
                return;

            var builder = new StringBuilder();
            foreach (var domino in solution)
            {
                builder.Append($"{domino[0]} {domino[1]} ");
            }

            Console.WriteLine(builder.ToString());

        }

        static IList<Domino> BackTracking(IList<Domino> pool, IList<Domino> solution, int remains)
        {
            if (remains == 0)
                return solution;

            for (int i = 0; i < pool.Count; i++)
            {
                var newDomino = pool[i];
                var lastDomino = solution.GetLastElement();

                if (CompareCompatibility(lastDomino, newDomino))
                {
                    var index = pool.IndexOf(newDomino);
                    pool.Remove(newDomino);
                    solution.Add(newDomino);
                    var res = BackTracking(pool, solution, --remains);
                    if(res == null)
                    {
                        solution.Remove(newDomino);
                        pool.Insert(index, newDomino);
                        remains++;
                    }
                    else
                    {
                        return res;
                    }
                }

                if (CompareCompatibility(lastDomino, newDomino.Rotate()))
                {
                    pool.Remove(newDomino);
                    var rotate = newDomino.Rotate();
                    solution.Add(rotate);
                    var res = BackTracking(pool, solution, --remains);
                    if (res == null)
                    {
                        solution.Remove(rotate);
                        pool.Add(newDomino);
                        remains++;
                    }
                    else
                    {
                        return res;
                    }
                }
            }

            return null;
        }

        public static Domino GetLastElement(this IList<Domino> dominoes)
        {
            if (dominoes.Count == 0)
                return null;
            return dominoes[dominoes.Count - 1];
        }

        public static bool CompareCompatibility(Domino lastOne, Domino newOne)
        {
            if (lastOne == null) return true;
            return lastOne[1] == newOne[0];
        }


        static bool IsPartialCorrect(IList<Domino> dominoes)
        {
            var last = dominoes[0];
            for (int i = 1; i < dominoes.Count(); i++)
            {
                if (last[1] != dominoes[i][0])
                    return false;
                last = dominoes[i];
            }
            return true;
        }
    }

    [DebuggerDisplay("({Value0}, {Value1})")]
    public class Domino
    {
        private Tuple<int,int> Value { get; }

        public int Value0 => Value.Item1;
        public int Value1 => Value.Item2;

        public Domino(int v0, int v1)
        {
            Value = new Tuple<int,int>(v0, v1);
        }

        public int this[int index]
        {
            get
            {
                if (index < 0 || index > 1) throw new IndexOutOfRangeException("Index allowed: 0 or 1");
                if (index == 0)
                    return Value0;
                return Value1;
            }
        }

        public Domino Rotate()
        {
            return new Domino(Value1, Value0);
        }
    }

    public static class InputProcessor
    {
        public static Tuple<int,int> ExtractParameters(string parametersLine)
        {
            string[] values = parametersLine.Split(' ');
            return new Tuple<int,int>(int.Parse(values[0]), int.Parse(values[1]));
        }

        public static Domino ExtractDomino(string dominoLine)
        {
            var values = dominoLine.Split(' ');
            return new Domino(int.Parse(values[0]), int.Parse(values[1]));
        }
    }
}
