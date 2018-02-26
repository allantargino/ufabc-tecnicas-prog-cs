using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Proj1_Peoes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start!");

            var a = new GameConfiguration();

            Console.ReadLine();
        }



        [DebuggerDisplay("{PositionPlayer1}-{PositionPlayer2}")]
        public class PlayerConfiguration
        {
            public int PositionPlayer1 { get; set; }
            public int PositionPlayer2 { get; set; }

            public override string ToString()
            {
                return $"{PositionPlayer1}-{PositionPlayer2}";
            }
        }

        public class ColumnConfiguration
        {
            Dictionary<int, PlayerConfiguration> configuration;

            public ColumnConfiguration()
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

        public class GameConfiguration
        {
            ColumnConfiguration ColumnConfiguration;
            Dictionary<int, Tuple<PlayerConfiguration, PlayerConfiguration, PlayerConfiguration>> GameConfigurations;

            public GameConfiguration()
            {
                ColumnConfiguration = new ColumnConfiguration();
                GameConfigurations = GenerateConfiguration();
            }

            private Dictionary<int, Tuple<PlayerConfiguration, PlayerConfiguration, PlayerConfiguration>> GenerateConfiguration()
            {
                var configurations = new Dictionary<int, Tuple<PlayerConfiguration, PlayerConfiguration, PlayerConfiguration>>();

                for (int i = 0; i < 20; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        for (int k = 0; k < 20; k++)
                        {
                            int id = (int)(i * Math.Pow(20, 2) + j * Math.Pow(20, 1) + k + 1);

                            var c1 = ColumnConfiguration.GetPlayerConfiguration(i+1);
                            var c2 = ColumnConfiguration.GetPlayerConfiguration(j+1);
                            var c3 = ColumnConfiguration.GetPlayerConfiguration(k+1);

                            configurations.Add(id, new Tuple<PlayerConfiguration, PlayerConfiguration, PlayerConfiguration>(c1, c2, c3));

                            Console.WriteLine($"{id}: {c1}, {c2}, {c3}");
                        }
                    }
                }

                return configurations;
            }
        }
    }
}
