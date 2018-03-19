using System;
using System.Collections.Generic;
using System.Text;

namespace Pawns
{
    public static class GameRules
    {
        public static bool IsTerminal(this PlayerConfiguration playerConfiguration, int player)
        {
            if (player == 0)
                return playerConfiguration.PositionPlayer1 == 4;

            if (player == 1)
                return playerConfiguration.PositionPlayer2 == 0;

            throw new NotImplementedException();
        }

        public static bool IsTerminal(this BoardConfiguration boardConfiguration, int player)
        {
            if (boardConfiguration.Column1.IsTerminal(player)
                 && boardConfiguration.Column2.IsTerminal(player)
                 && boardConfiguration.Column3.IsTerminal(player))
                return true;
            else
                return false;
        }

        public static bool IsTerminal(this State state)
        {
            var terminal = state.Configuration.IsTerminal(state.Player);
            return terminal;
        }

        public static bool IsGameOver(this State state)
        {
            return state.Configuration.IsTerminal(0) || state.Configuration.IsTerminal(1);
        }

        public static State GetPossibleMoviment(State currentState, string line)
        {
            var chars = line.Split(' ');

            var column = int.Parse(chars[0]);
            var moviment = int.Parse(chars[1]);

            return GameFactory.GetPossibleState(column, moviment, currentState);
        }

        public static string GetDifferenceBetweenStates(State lastState, State currentState)
        {
            if (lastState == currentState)
                return "0 0";

            int column = -1;
            int moviment = -1;

            if (lastState.Configuration.Column1 != currentState.Configuration.Column1)
            {
                column = 1;
                if (currentState.Player == 1)
                    moviment = Math.Abs(lastState.Configuration.Column1.PositionPlayer1 - currentState.Configuration.Column1.PositionPlayer1);
                else
                    moviment = Math.Abs(lastState.Configuration.Column1.PositionPlayer2 - currentState.Configuration.Column1.PositionPlayer2);
            }
            else if (lastState.Configuration.Column2 != currentState.Configuration.Column2)
            {
                column = 2;
                if (currentState.Player == 1)
                    moviment = Math.Abs(lastState.Configuration.Column2.PositionPlayer1 - currentState.Configuration.Column2.PositionPlayer1);
                else
                    moviment = Math.Abs(lastState.Configuration.Column2.PositionPlayer2 - currentState.Configuration.Column2.PositionPlayer2);
            }
            else
            {
                column = 3;
                if (currentState.Player == 1)
                    moviment = Math.Abs(lastState.Configuration.Column3.PositionPlayer1 - currentState.Configuration.Column3.PositionPlayer1);
                else
                    moviment = Math.Abs(lastState.Configuration.Column3.PositionPlayer2 - currentState.Configuration.Column3.PositionPlayer2);

            }

            return $"{column} {moviment}";
        }
    }
}
