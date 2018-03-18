using System;
using System.Collections.Generic;
using System.Text;

namespace Pawns
{
    public class PlayerMovimentEnumeration
    {
        public IDictionary<PlayerConfiguration, IEnumerable<PlayerConfiguration>> ValidMovimentsPlayer1 { get; set; }
        public IDictionary<PlayerConfiguration, IEnumerable<PlayerConfiguration>> ValidMovimentsPlayer2 { get; set;  }

        public IEnumerable<PlayerConfiguration> GetValidMovimentsFor(int player, PlayerConfiguration configuration)
        {
            if (player < 0 || player > 1) throw new ArgumentOutOfRangeException(nameof(player));

            if (player == 0)
                return ValidMovimentsPlayer1[configuration];

            if (player == 1)
                return ValidMovimentsPlayer2[configuration];

            throw new NotImplementedException();
        }
    }
}
