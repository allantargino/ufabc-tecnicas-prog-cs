using System;
using System.Collections.Generic;

namespace Pawns
{
    public class State : IEquatable<State>
    {
        public int Player { get; set; }
        public BoardConfiguration Configuration { get; set; }
        public NodeProperties NodeProperties { get; set; }

        public State(int player, BoardConfiguration configuration)
        {
            Player = player;
            Configuration = configuration;
            NodeProperties = new NodeProperties();
        }

        #region IEquatable

        public override bool Equals(object obj)
        {
            return Equals(obj as State);
        }

        public bool Equals(State other)
        {
            return other != null &&
                   Player == other.Player &&
                   EqualityComparer<BoardConfiguration>.Default.Equals(Configuration, other.Configuration);
        }

        public override int GetHashCode()
        {
            var hashCode = -2100435591;
            hashCode = hashCode * -1521134295 + Player.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<BoardConfiguration>.Default.GetHashCode(Configuration);
            return hashCode;
        }

        #endregion
    }
}