using System;
using System.Collections.Generic;

namespace Pawns
{
    public class BoardConfigurationGenerator
    {
        private PlayerConfigurationEnumeration _playerConfigurationEnumeration;

        public BoardConfigurationGenerator(PlayerConfigurationEnumeration playerConfigurationEnumeration)
        {
            _playerConfigurationEnumeration = playerConfigurationEnumeration;
        }

        public BoardConfigurationEnumeration Enumerate()
        {
            var boardConfigurations = new Dictionary<int, BoardConfiguration>();
            var boardConfigurationsIndex = new Dictionary<BoardConfiguration, int>();

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    for (int k = 0; k < 20; k++)
                    {
                        int id = (int)(i * Math.Pow(20, 2) + j * Math.Pow(20, 1) + k + 1);

                        var c1 = _playerConfigurationEnumeration.GetPlayerConfiguration(i + 1);
                        var c2 = _playerConfigurationEnumeration.GetPlayerConfiguration(j + 1);
                        var c3 = _playerConfigurationEnumeration.GetPlayerConfiguration(k + 1);

                        var configuration = new BoardConfiguration(c1, c2, c3);

                        boardConfigurations.Add(id, configuration);

                        boardConfigurationsIndex.Add(configuration, id);

                        Logger.WriteLine($"{id}: {c1}, {c2}, {c3}");
                    }
                }
            }

            return new BoardConfigurationEnumeration()
            {
                BoardConfigurations = boardConfigurations,
                BoardConfigurationsIndex = boardConfigurationsIndex
            };
        }
    }
}
