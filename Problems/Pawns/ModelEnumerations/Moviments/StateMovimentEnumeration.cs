using System;
using System.Collections.Generic;
using System.Text;

namespace Pawns
{
    public class StateMovimentEnumeration
    {
        public IDictionary<State, IEnumerable<State>> ValidMovimentsPlayers { get; set; }
    }
}
