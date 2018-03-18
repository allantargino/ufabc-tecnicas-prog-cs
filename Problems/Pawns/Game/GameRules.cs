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
    }
}
