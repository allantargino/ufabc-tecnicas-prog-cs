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

            var gameConfiguration = new BoardColumnsGenerator();
            var conf9 = gameConfiguration.GetGameConfiguration(9);

            Console.WriteLine($"Configuração {nameof(conf9)}: {conf9.ToString()}");

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

        public class BoardConfiguration
        {
            private Tuple<PlayerConfiguration, PlayerConfiguration, PlayerConfiguration> configuration;

            public BoardConfiguration(PlayerConfiguration c1, PlayerConfiguration c2, PlayerConfiguration c3)
            {
                configuration = new Tuple<PlayerConfiguration, PlayerConfiguration, PlayerConfiguration>(c1, c2, c3);
            }

            public override string ToString()
            {
                return $"{configuration.Item1.ToString()}, {configuration.Item2.ToString()}, {configuration.Item3.ToString()}";
            }
        }

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

        public class BoardColumnsGenerator
        {
            private ColumnGenerator ColumnGenerator;
            private Dictionary<int, BoardConfiguration> BoardConfigurations;

            public BoardColumnsGenerator()
            {
                ColumnGenerator = new ColumnGenerator();
                BoardConfigurations = GenerateConfiguration();
            }

            private Dictionary<int, BoardConfiguration> GenerateConfiguration()
            {
                var configurations = new Dictionary<int, BoardConfiguration>();

                for (int i = 0; i < 20; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        for (int k = 0; k < 20; k++)
                        {
                            int id = (int)(i * Math.Pow(20, 2) + j * Math.Pow(20, 1) + k + 1);

                            var c1 = ColumnGenerator.GetPlayerConfiguration(i+1);
                            var c2 = ColumnGenerator.GetPlayerConfiguration(j+1);
                            var c3 = ColumnGenerator.GetPlayerConfiguration(k+1);

                            configurations.Add(id, new BoardConfiguration(c1, c2, c3));

                            Logger.WriteLine($"{id}: {c1}, {c2}, {c3}");
                        }
                    }
                }

                return configurations;
            }

            public BoardConfiguration GetGameConfiguration(int id)
            {
                if (id < 1 || id > 8000) throw new ArgumentOutOfRangeException(nameof(id));

                return BoardConfigurations[id];
            }

        }
    }
}
