using System;
using System.Collections.Generic;
using System.Text;

namespace Pawns
{
    public class NodeProperties
    {
        public bool WasVisited { get; set; }
        public bool HasWinningStrategy { get; set; }

        public NodeProperties()
        {
            WasVisited = false;
        }
    }
}
