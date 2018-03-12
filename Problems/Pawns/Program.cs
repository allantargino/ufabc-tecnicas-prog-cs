using System;
using System.Collections.Generic;
using System.Linq;

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
            var stateMovimentAfterSearch = Search(stateMovimentEnumeration, BoardConfigurationEnumeration);

            Console.WriteLine("Finished!");
            Console.ReadLine();
        }

        private static State GetNextMoviment(State currentState, StateMovimentEnumeration states)
        {
            var possibleStates = states.StateMoviments[currentState];

            if (currentState.NodeProperties.HasWinningStrategy)
                possibleStates.First(s => !s.NodeProperties.HasWinningStrategy);

            return possibleStates.ElementAt(new Random().Next(0, possibleStates.Count()-1));
        }

        private static StateMovimentEnumeration Search(StateMovimentEnumeration states, BoardConfigurationEnumeration board)
        {
            foreach (var state in states.StateMoviments)
            {
                var hasWinningStrategy = RecursiveDepthSearch(state.Key, states);
            }

            //var vizinhos = states.StateMoviments[new State(0, board.GetGameConfiguration(1))];
            //var winningStrategy = RecursiveDepthSearch(start, states);

            return states;
        }

        private static bool RecursiveDepthSearch(State currentState, StateMovimentEnumeration statesEnumeration)
        {
            if (currentState.NodeProperties.WasVisited)
                return currentState.NodeProperties.HasWinningStrategy;

            if (currentState.IsTerminal())
                return false;

            bool enemyWinningStrategy = false;
            var adjacentStates = statesEnumeration.StateMoviments[currentState];
            foreach (var adjacentState in adjacentStates)
            {
                enemyWinningStrategy = enemyWinningStrategy || RecursiveDepthSearch(adjacentState, statesEnumeration);
            }

            currentState.NodeProperties.WasVisited = true;
            currentState.NodeProperties.HasWinningStrategy = !enemyWinningStrategy;

            return currentState.NodeProperties.HasWinningStrategy;
        }

    }
}
