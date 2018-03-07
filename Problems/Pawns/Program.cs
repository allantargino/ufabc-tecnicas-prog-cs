using System;

namespace Pawns
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Logger.isEnabled = false;

            Console.WriteLine("Started!");

            // Player Configuration Enumeration
            var playerConfigurationGenerator = new PlayerConfigurationGenerator();
            var playerConfigurationEnumeration = playerConfigurationGenerator.Enumerate();

            // Player Moviment Enumeration
            var playerMovimentGenerator = new PlayerMovimentGenerator(playerConfigurationEnumeration);
            var playerMovimentEnumeration = playerMovimentGenerator.Enumerate();


            // Board Configuration Enumeration
            var boardColumnsGenerator = new BoardConfigurationGenerator(playerConfigurationEnumeration);
            var BoardConfigurationEnumeration = boardColumnsGenerator.Enumerate();

            // Board Moviment Enumeration
            var boardMovimentGenerator = new BoardMovimentGenerator(playerMovimentEnumeration, BoardConfigurationEnumeration);
            var boardMovimentEnumeration = boardMovimentGenerator.Enumerate();


            // State Configuration Enumeration

            // State Moviment Enumeration
            //var graphGenerator = new GraphGenerator(graphValidMovimentsGenerator);
            //graphGenerator.GenerateGraph();

            Console.WriteLine("Finished!");
            Console.ReadLine();
        }

    }
}
