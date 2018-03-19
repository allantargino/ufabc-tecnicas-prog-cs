using System;
using System.Collections.Generic;

namespace Dominoes
{
    class Program
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


        }
    }
}
