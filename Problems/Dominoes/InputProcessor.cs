using System;
using System.Collections.Generic;
using System.Text;

namespace Dominoes
{
    public static class InputProcessor
    {
        public static (int n, int k) ExtractParameters(string parametersLine)
        {
            var values = parametersLine.Split(" ");
            return (int.Parse(values[0]), int.Parse(values[1]));
        }

        public static Domino ExtractDomino(string dominoLine)
        {
            var values = dominoLine.Split(" ");
            return new Domino(int.Parse(values[0]), int.Parse(values[1]));
        }
    }
}
