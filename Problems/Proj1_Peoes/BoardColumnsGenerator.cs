using System;
using System.Collections.Generic;

namespace Proj1_Peoes
{
    public class BoardColumnsGenerator
    {
        private ColumnManager ColumnGenerator;
        private Dictionary<int, BoardConfiguration> BoardConfigurations;
        private Dictionary<BoardConfiguration, int> BoardIndex;

        public BoardColumnsGenerator(ColumnManager columnGenerator)
        {
            ColumnGenerator = columnGenerator;

            GenerateConfiguration();
        }

        private void GenerateConfiguration()
        {
            BoardConfigurations = new Dictionary<int, BoardConfiguration>();
            BoardIndex = new Dictionary<BoardConfiguration, int>();

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

                        var configuration = new BoardConfiguration(c1, c2, c3);

                        BoardConfigurations.Add(id, configuration);

                        BoardIndex.Add(configuration, id);

                        Logger.WriteLine($"{id}: {c1}, {c2}, {c3}");
                    }
                }
            }
        }

        public BoardConfiguration GetGameConfiguration(int id)
        {
            if (id < 1 || id > 8000) throw new ArgumentOutOfRangeException(nameof(id));

            return BoardConfigurations[id];
        }

        public BoardConfiguration GetGameConfiguration(PlayerConfiguration c1, PlayerConfiguration c2, PlayerConfiguration c3)
        {
            var index = this.BoardIndex[new BoardConfiguration(c1, c2, c3)];
            return GetGameConfiguration(index);
        }

    }
}
