using System;
using System.Collections.Generic;

namespace Proj1_Peoes
{
    public class BoardColumnsGenerator
    {
        private ColumnManager ColumnGenerator;
        private Dictionary<int, BoardConfiguration> BoardConfigurations;

        public BoardColumnsGenerator(ColumnManager columnGenerator)
        {
            ColumnGenerator = columnGenerator;
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

                        var c1 = ColumnGenerator.GetPlayerConfiguration(i + 1);
                        var c2 = ColumnGenerator.GetPlayerConfiguration(j + 1);
                        var c3 = ColumnGenerator.GetPlayerConfiguration(k + 1);

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

        //TODO: Função inversa de dado BoardConfiguration -> id

    }
}
