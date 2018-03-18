using System;
using System.Collections.Generic;
using System.Text;

namespace Pawns
{
    public class PlayerConfigurationEnumeration
    {
        public Dictionary<int, PlayerConfiguration> PlayerConfigurations { get; set; }
        public Dictionary<PlayerConfiguration, int> PlayerConfigurationsIndex { get; set; }

        public PlayerConfiguration GetPlayerConfiguration(int id)
        {
            if (id < 0 || id > 20) throw new ArgumentOutOfRangeException(nameof(id));

            return PlayerConfigurations[id];
        }

        public PlayerConfiguration GetPlayerConfiguration(int p1, int p2)
        {
            var index = this.PlayerConfigurationsIndex[new PlayerConfiguration(p1, p2)];
            return GetPlayerConfiguration(index);
        }

    }
}
