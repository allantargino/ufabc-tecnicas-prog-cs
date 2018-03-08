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
            // Board Configuration Enumeration
            var boardConfigurationGenerator = new BoardConfigurationGenerator(playerConfigurationEnumeration);
            var BoardConfigurationEnumeration = boardConfigurationGenerator.Enumerate();
            // State Configuration Enumeration
            var stateConfigurationGenerator = new StateConfigurationGenerator(BoardConfigurationEnumeration);
            var stateConfigurationEnumeration = stateConfigurationGenerator.Enumerate();

            // Player Moviment Enumeration
            var playerMovimentGenerator = new PlayerMovimentGenerator(playerConfigurationEnumeration);
            var playerMovimentEnumeration = playerMovimentGenerator.Enumerate();
            // Board Moviment Enumeration
            var boardMovimentGenerator = new BoardMovimentGenerator(playerMovimentEnumeration, BoardConfigurationEnumeration);
            var boardMovimentEnumeration = boardMovimentGenerator.Enumerate();
            // State Moviment Enumeration
            var stateMovimentGenerator = new StateMovimentGenerator(stateConfigurationEnumeration, boardMovimentEnumeration);
            var stateMovimentEnumeration = stateMovimentGenerator.Enumerate();

            // Search Winning Strategy

            Console.WriteLine("Finished!");
            Console.ReadLine();
        }

    }
}
