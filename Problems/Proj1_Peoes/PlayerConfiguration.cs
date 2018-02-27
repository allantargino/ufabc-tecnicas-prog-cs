using System.Diagnostics;

namespace Proj1_Peoes
{
    partial class Program
    {
        [DebuggerDisplay("{PositionPlayer1}-{PositionPlayer2}")]
        public class PlayerConfiguration
        {
            public int PositionPlayer1 { get; set; }
            public int PositionPlayer2 { get; set; }

            public override string ToString()
            {
                return $"{PositionPlayer1}-{PositionPlayer2}";
            }
        }


    }
}
