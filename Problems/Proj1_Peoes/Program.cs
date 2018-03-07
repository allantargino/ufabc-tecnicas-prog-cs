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
            var boardColumnsGenerator = new BoardColumnsGenerator(columnGenerator);

            var columnValidMovimentsGenerator = new ColumnValidMovimentsGenerator(columnGenerator);
            columnValidMovimentsGenerator.GenerateValidMoviments();

            var graphValidMovimentsGenerator = new GraphValidMovimentsGenerator(columnValidMovimentsGenerator, boardColumnsGenerator);
            graphValidMovimentsGenerator.GenerateValidMoviments();

            Console.ReadLine();
        }

    }
}
