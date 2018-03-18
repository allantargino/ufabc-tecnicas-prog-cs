using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Pawns
{
    public static class GameFactory
    {
        private static PlayerConfigurationEnumeration playerConfigurationEnumeration;
        private static BoardConfigurationEnumeration BoardConfigurationEnumeration;
        private static StateConfigurationEnumeration stateConfigurationEnumeration;

        private static PlayerMovimentEnumeration playerMovimentEnumeration;
        private static BoardMovimentEnumeration boardMovimentEnumeration;
        private static StateMovimentEnumeration stateMovimentEnumeration;


        public static void Init()
        {
            // Player Configuration Enumeration
            var playerConfigurationGenerator = new PlayerConfigurationGenerator();
            playerConfigurationEnumeration = playerConfigurationGenerator.Enumerate();
            // Board Configuration Enumeration
            var boardConfigurationGenerator = new BoardConfigurationGenerator(playerConfigurationEnumeration);
            BoardConfigurationEnumeration = boardConfigurationGenerator.Enumerate();
            // State Configuration Enumeration
            var stateConfigurationGenerator = new StateConfigurationGenerator(BoardConfigurationEnumeration);
            stateConfigurationEnumeration = stateConfigurationGenerator.Enumerate();

            // Player Moviment Enumeration
            var playerMovimentGenerator = new PlayerMovimentGenerator(playerConfigurationEnumeration);
            playerMovimentEnumeration = playerMovimentGenerator.Enumerate();
            // Board Moviment Enumeration
            var boardMovimentGenerator = new BoardMovimentGenerator(playerMovimentEnumeration, BoardConfigurationEnumeration);
            boardMovimentEnumeration = boardMovimentGenerator.Enumerate();
            // State Moviment Enumeration
            var stateMovimentGenerator = new StateMovimentGenerator(stateConfigurationEnumeration, boardMovimentEnumeration);
            stateMovimentEnumeration = stateMovimentGenerator.Enumerate();
        }

        public static State GetInitialState(int initialPlayer = 0)
        {
            if (initialPlayer < 0 || initialPlayer > 1) throw new ArgumentOutOfRangeException(nameof(initialPlayer));

            return new State(initialPlayer,
                BoardConfigurationEnumeration.GetGameConfiguration(
                    new PlayerConfiguration(0, 4),
                    new PlayerConfiguration(0, 4),
                    new PlayerConfiguration(0, 4))
                    );
        }

        public static State GetPossibleState(int column, int moviment, State currentState)
        {
            var possibleStates = stateMovimentEnumeration.StateMoviments[currentState];

            if (currentState.Player == 0)
            {
                switch (column)
                {
                    case 1:
                        return possibleStates.First(
                            s =>
                            s.Configuration.Column1.PositionPlayer1 == moviment &&
                            s.Configuration.Column2.PositionPlayer1 == currentState.Configuration.Column2.PositionPlayer1 &&
                            s.Configuration.Column3.PositionPlayer1 == currentState.Configuration.Column3.PositionPlayer1
                            );
                    case 2:
                        return possibleStates.First(
                            s =>
                            s.Configuration.Column1.PositionPlayer1 == currentState.Configuration.Column1.PositionPlayer1 &&
                            s.Configuration.Column2.PositionPlayer1 == moviment &&
                            s.Configuration.Column3.PositionPlayer1 == currentState.Configuration.Column3.PositionPlayer1
                            );
                    case 3:
                        return possibleStates.First(
                            s =>
                            s.Configuration.Column1.PositionPlayer1 == currentState.Configuration.Column1.PositionPlayer1 &&
                            s.Configuration.Column2.PositionPlayer1 == currentState.Configuration.Column2.PositionPlayer1 &&
                            s.Configuration.Column3.PositionPlayer1 == moviment
                            );
                    default:
                        return null;
                }
            }
            else
            {
                switch (column)
                {
                    case 1:
                        return possibleStates.First(
                            s =>
                            s.Configuration.Column1.PositionPlayer2 == currentState.Configuration.Column1.PositionPlayer2 - moviment &&
                            s.Configuration.Column2.PositionPlayer2 == currentState.Configuration.Column2.PositionPlayer2 &&
                            s.Configuration.Column3.PositionPlayer2 == currentState.Configuration.Column3.PositionPlayer2
                            );
                    case 2:
                        return possibleStates.First(
                            s =>
                            s.Configuration.Column1.PositionPlayer2 == currentState.Configuration.Column1.PositionPlayer2 &&
                            s.Configuration.Column2.PositionPlayer2 == currentState.Configuration.Column2.PositionPlayer2 - moviment &&
                            s.Configuration.Column3.PositionPlayer2 == currentState.Configuration.Column3.PositionPlayer2
                            );                                    
                    case 3:                                       
                        return possibleStates.First(                     
                            s =>                                  
                            s.Configuration.Column1.PositionPlayer2 == currentState.Configuration.Column1.PositionPlayer2 &&
                            s.Configuration.Column2.PositionPlayer2 == currentState.Configuration.Column2.PositionPlayer2 &&
                            s.Configuration.Column3.PositionPlayer2 == currentState.Configuration.Column3.PositionPlayer2 - moviment
                            );
                    default:
                        return null;
                }
            }
        }

        public static GameAdvisor GenerateGameAdvisor()
        {
            return new GameAdvisor(stateMovimentEnumeration, BoardConfigurationEnumeration);
        }
    }
}
