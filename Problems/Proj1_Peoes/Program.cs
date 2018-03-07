using System;

namespace Proj1_Peoes
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Logger.isEnabled = false;

            Console.WriteLine("Start!");

            var columnGenerator = new ColumnManager();
            var gameConfiguration = new BoardColumnsGenerator(columnGenerator);

            var columnGraphGenerator = new ColumnGraphGenerator(columnGenerator);

            columnGraphGenerator.GenerateSingleColumnGraph();

            Console.ReadLine();
        }

    }
}
