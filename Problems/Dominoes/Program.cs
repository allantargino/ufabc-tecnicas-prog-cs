using System;
using System.Collections.Generic;
using System.Linq;

namespace Dominoes
{
    static class Program
    {
        static void Main(string[] args)
        {
            var parametersLine = Console.ReadLine().Substring(3, 3); //hack
            (int n, int k) = InputProcessor.ExtractParameters(parametersLine);

            var dominoes = new List<Domino>();
            for (int i = 0; i < n; i++)
            {
                var dominoLine = Console.ReadLine();
                dominoes.Add(InputProcessor.ExtractDomino(dominoLine));
            }

            BackTracking(dominoes, new List<Domino>(), k);
        }

        static IList<Domino> BackTracking(IList<Domino> pool, IList<Domino> solution, int remains)
        {
            if (remains == 0)
                return solution;

            var newDomino = pool[0];
            var lastDomino = solution.GetLastElement();

            if (CompareCompatibility(lastDomino, newDomino))
            {

            }
            else if (CompareCompatibility(lastDomino, newDomino.Rotate()){

            }

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



        static bool IsFinalCorrect(IList<Domino> dominoes, int k)
        {
            if (IsPartialCorrect(dominoes) && dominoes.Count == k)
                return true;
            return false;
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
}
