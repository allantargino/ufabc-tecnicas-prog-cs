using System;
using System.Diagnostics;

namespace Pawns
{
    [DebuggerDisplay("{PositionPlayer1}-{PositionPlayer2}")]
    public class PlayerConfiguration : IEquatable<PlayerConfiguration>
    {
        public int PositionPlayer1 { get; set; }
        public int PositionPlayer2 { get; set; }

        #region IEquatable
        public override bool Equals(object obj)
        {
            var configuration = obj as PlayerConfiguration;
            return Equals(configuration);
        }

        public bool Equals(PlayerConfiguration other)
        {
            return other != null &&
                PositionPlayer1 == other.PositionPlayer1 &&
                PositionPlayer2 == other.PositionPlayer2;
        }

        public override int GetHashCode()
        {
            var hashCode = 615292361;
            hashCode = hashCode * -1521134295 + PositionPlayer1.GetHashCode();
            hashCode = hashCode * -1521134295 + PositionPlayer2.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return $"{PositionPlayer1}-{PositionPlayer2}";
        }
        #endregion

        public PlayerConfiguration() { }

        public PlayerConfiguration(int p1, int p2)
        {
            PositionPlayer1 = p1;
            PositionPlayer2 = p2;
        }
    }
}
