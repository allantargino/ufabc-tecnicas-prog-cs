using System;
using System.Collections.Generic;
using System.Text;

namespace Pawns
{
    public class NodeProperties
    {
        public bool Visited { get; set; }
        public bool HasWinningStrategy { get; set; }

        public NodeProperties()
        {
            Visited = false;
        }
    }
}
