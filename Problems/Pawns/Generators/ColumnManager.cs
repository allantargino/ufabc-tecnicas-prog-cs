using System;
using System.Collections.Generic;

namespace Pawns
{
    public class ColumnManager
    {
        public Dictionary<int, PlayerConfiguration> Configuration { get; set; }
        private Dictionary<PlayerConfiguration, int> PlayerIndex { get; set; }

        public ColumnManager()
        {
            GenerateColumn();
        }

        public PlayerConfiguration GetPlayerConfiguration(int id)
        {
            if (id < 0 || id > 20) throw new ArgumentOutOfRangeException(nameof(id));

            return Configuration[id];
        }

        public PlayerConfiguration GetPlayerConfiguration(int p1, int p2)
        {
            var index =  this.PlayerIndex[new PlayerConfiguration(p1, p2)];
            return GetPlayerConfiguration(index);
        }

        private void GenerateColumn()
        {
            Configuration = new Dictionary<int, PlayerConfiguration>();
            PlayerIndex = new Dictionary<PlayerConfiguration, int>();

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


                    Configuration.Add(i, jogada);
                    PlayerIndex.Add(jogada, i);
                }
            }
        }
    }
}
