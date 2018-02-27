using System;
using System.Collections.Generic;

namespace Proj1_Peoes
{
    partial class Program
    {
        public class ColumnGenerator
        {
            Dictionary<int, PlayerConfiguration> configuration;

            public ColumnGenerator()
            {
                configuration = GenerateColumn();
            }

            public PlayerConfiguration GetPlayerConfiguration(int id)
            {
                if (id < 0 || id > 20) throw new ArgumentOutOfRangeException(nameof(id));

                return configuration[id];
            }

            private Dictionary<int, PlayerConfiguration> GenerateColumn()
            {
                var column = new Dictionary<int, PlayerConfiguration>();
                int i = 0;

                for (int jogador_i = 0; jogador_i < 5; jogador_i++)
                {
                    for (int jogador_j = 0; jogador_j < 5; jogador_j++)
                    {
                        if (jogador_j == jogador_i)
                            jogador_j++;

                        if (jogador_j == 5)
                            break;

                        column.Add(++i, new PlayerConfiguration()
                        {
                            PositionPlayer1 = jogador_i,
                            PositionPlayer2 = jogador_j
                        });
                        //Console.WriteLine($"{jogador_i} - {jogador_j}");
                    }
                }
                return column;
            }
        }


    }
}
