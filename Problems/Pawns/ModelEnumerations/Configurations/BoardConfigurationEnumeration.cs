using System;
using System.Collections.Generic;
using System.Text;

namespace Pawns
{
    public class BoardConfigurationEnumeration
    {
        public Dictionary<int, BoardConfiguration> BoardConfigurations { get; set; }
        public Dictionary<BoardConfiguration, int> BoardConfigurationsIndex { get; set; }


        public BoardConfiguration GetGameConfiguration(int id)
        {
            if (id < 1 || id > 8000) throw new ArgumentOutOfRangeException(nameof(id));

            return BoardConfigurations[id];
        }

        public BoardConfiguration GetGameConfiguration(PlayerConfiguration c1, PlayerConfiguration c2, PlayerConfiguration c3)
        {
            var index = this.BoardConfigurationsIndex[new BoardConfiguration(c1, c2, c3)];
            return GetGameConfiguration(index);
        }
    }
}
