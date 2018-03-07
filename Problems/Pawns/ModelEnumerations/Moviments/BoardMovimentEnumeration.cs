using System;
using System.Collections.Generic;
using System.Text;

namespace Pawns
{
    public class BoardMovimentEnumeration
    {
        public IDictionary<BoardConfiguration, IEnumerable<BoardConfiguration>> ValidMovimentsPlayer1 { get; set; }
        public IDictionary<BoardConfiguration, IEnumerable<BoardConfiguration>> ValidMovimentsPlayer2 { get; set; }


        public IEnumerable<BoardConfiguration> GetValidMoviments(int player, BoardConfiguration configuration)
        {
            if (player == 1)
                return ValidMovimentsPlayer1[configuration];

            if (player == 2)
                return ValidMovimentsPlayer2[configuration];

            throw new NotImplementedException();
        }
    }
}
