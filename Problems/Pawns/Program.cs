using System;

namespace Pawns
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Logger.isEnabled = false;

            Console.WriteLine("Start!");

            var columnGenerator = new ColumnManager();
            var boardColumnsGenerator = new BoardColumnsGenerator(columnGenerator);

            var columnValidMovimentsGenerator = new ColumnValidMovimentsGenerator(columnGenerator);
            columnValidMovimentsGenerator.GenerateValidMoviments();

            var graphValidMovimentsGenerator = new GraphValidMovimentsGenerator(columnValidMovimentsGenerator, boardColumnsGenerator);
            graphValidMovimentsGenerator.GenerateValidMoviments();

            var graphGenerator = new GraphGenerator(graphValidMovimentsGenerator);
            graphGenerator.GenerateGraph();

            Console.ReadLine();
        }

    }
}
