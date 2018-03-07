using System;
using System.Collections.Generic;

namespace Pawns
{
    public class BoardConfiguration:IEquatable<BoardConfiguration>
    {
        private Tuple<PlayerConfiguration, PlayerConfiguration, PlayerConfiguration> configuration;

        public PlayerConfiguration Column1 => configuration.Item1;
        public PlayerConfiguration Column2=> configuration.Item2;
        public PlayerConfiguration Column3 => configuration.Item3;


        public BoardConfiguration(PlayerConfiguration c1, PlayerConfiguration c2, PlayerConfiguration c3)
        {
            configuration = new Tuple<PlayerConfiguration, PlayerConfiguration, PlayerConfiguration>(c1, c2, c3);
        }

        public bool IsTerminal(int player)
        {
            if (Column1.IsTerminal(player) && Column2.IsTerminal(player) && Column3.IsTerminal(player))
                return true;
            return false;
        }

        public override string ToString()
        {
            return $"{configuration.Item1.ToString()}, {configuration.Item2.ToString()}, {configuration.Item3.ToString()}";
        }


        public override int GetHashCode()
        {
            var hashCode = 456749573;
            hashCode = hashCode * -1521134295 + EqualityComparer<PlayerConfiguration>.Default.GetHashCode(Column1);
            hashCode = hashCode * -1521134295 + EqualityComparer<PlayerConfiguration>.Default.GetHashCode(Column2);
            hashCode = hashCode * -1521134295 + EqualityComparer<PlayerConfiguration>.Default.GetHashCode(Column3);
            return hashCode;
        }

        public override bool Equals(object obj)
        {
            var configuration = obj as BoardConfiguration;
            return Equals(configuration);
        }

        public bool Equals(BoardConfiguration other)
        {
            return other != null &&
                   EqualityComparer<PlayerConfiguration>.Default.Equals(Column1, other.Column1) &&
                   EqualityComparer<PlayerConfiguration>.Default.Equals(Column2, other.Column2) &&
                   EqualityComparer<PlayerConfiguration>.Default.Equals(Column3, other.Column3);
        }
    }
}
