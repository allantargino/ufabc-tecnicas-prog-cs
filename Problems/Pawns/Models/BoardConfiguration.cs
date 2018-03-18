using System;
using System.Collections.Generic;

namespace Pawns
{
    public class BoardConfiguration : IEquatable<BoardConfiguration>
    {
        private PlayerConfiguration[] configuration;

        public PlayerConfiguration Column1 => configuration[0];
        public PlayerConfiguration Column2 => configuration[1];
        public PlayerConfiguration Column3 => configuration[2];


        public BoardConfiguration(PlayerConfiguration c1, PlayerConfiguration c2, PlayerConfiguration c3)
        {
            configuration = new PlayerConfiguration[] { c1, c2, c3 };
        }

        #region IEquatable
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

        public override string ToString()
        {
            return $"{configuration[0].ToString()}, {configuration[1].ToString()}, {configuration[2].ToString()}";
        }
        #endregion
    }
}
