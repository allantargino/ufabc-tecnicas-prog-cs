using System;
using System.Collections.Generic;

namespace Pawns
{
    public class PlayerConfigurationGenerator
    {
        public PlayerConfigurationEnumeration Enumerate()
        {
            var playerConfiguration = new Dictionary<int, PlayerConfiguration>();
            var playerConfigurationIndex = new Dictionary<PlayerConfiguration, int>();

            int i = 0;

            for (int jogador_i = 0; jogador_i < 5; jogador_i++)
            {
                for (int jogador_j = 0; jogador_j < 5; jogador_j++)
                {
                    if (jogador_j == jogador_i)
                        jogador_j++;

                    if (jogador_j == 5)
                        break;

                    var id = i++;
                    var jogada = new PlayerConfiguration()
                    {
                        PositionPlayer1 = jogador_i,
                        PositionPlayer2 = jogador_j
                    };


                    playerConfiguration.Add(i, jogada);
                    playerConfigurationIndex.Add(jogada, i);
                }
            }

            return new PlayerConfigurationEnumeration()
            {
                PlayerConfigurations = playerConfiguration,
                PlayerConfigurationsIndex = playerConfigurationIndex
            };
        }
    }
}
