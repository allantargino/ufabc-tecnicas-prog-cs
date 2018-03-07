using System;
using System.Collections.Generic;
using System.Text;

namespace Pawns
{
    public class GraphValidMovimentsGenerator
    {
        private ColumnValidMovimentsGenerator ColumnValidMovimentsGenerator { get; }
        private BoardColumnsGenerator BoardColumnsGenerator { get; }

        private IDictionary<BoardConfiguration, IEnumerable<BoardConfiguration>> ValidMovimentsPlayer1 { get; }
        private IDictionary<BoardConfiguration, IEnumerable<BoardConfiguration>> ValidMovimentsPlayer2 { get; }


        public GraphValidMovimentsGenerator(ColumnValidMovimentsGenerator columnValidMovimentsGenerator, BoardColumnsGenerator boardColumnsGenerator)
        {
            ValidMovimentsPlayer1 = new Dictionary<BoardConfiguration, IEnumerable<BoardConfiguration>>();
            ValidMovimentsPlayer2 = new Dictionary<BoardConfiguration, IEnumerable<BoardConfiguration>>();

            ColumnValidMovimentsGenerator = columnValidMovimentsGenerator;
            BoardColumnsGenerator = boardColumnsGenerator;
        }

        public void GenerateValidMoviments()
        {
            for (int player = 1; player <= 2; player++)
            {
                for (int i = 1; i <= 8000; i++)
                {
                    var configuration = BoardColumnsGenerator.GetGameConfiguration(i);
                    var validMoviments = GenerateValidMovimentsForBoardConfiguration(player, configuration);

                    SaveValidMoviments(player, configuration, validMoviments);
                }
            }
        }

        private IEnumerable<BoardConfiguration> GenerateValidMovimentsForBoardConfiguration(int player, BoardConfiguration boardConfiguration)
        {
            var validMoviments = new List<BoardConfiguration>();

            if (boardConfiguration.IsTerminal(player))
                return validMoviments;

            for (int i = 0; i <= 2; i++)
            {
                var k = new PlayerConfiguration[3];

                k[0] = boardConfiguration.Column1;
                k[1] = boardConfiguration.Column2;
                k[2] = boardConfiguration.Column3;

                var validMovimentsForK = ColumnValidMovimentsGenerator.GetValidMovimentsFor(player, k[i]);
                foreach (var moviment in validMovimentsForK)
                {
                    k[i] = moviment;
                    var validMoviment = BoardColumnsGenerator.GetGameConfiguration(k[0], k[1], k[2]);
                    validMoviments.Add(validMoviment);
                }
            }

            return validMoviments;
        }

        private void SaveValidMoviments(int player, BoardConfiguration key, IEnumerable<BoardConfiguration> value)
        {
            if (player == 1)
                ValidMovimentsPlayer1.Add(key, value);

            if (player == 2)
                ValidMovimentsPlayer2.Add(key, value);
        }

        public IEnumerable<BoardConfiguration> GetValidMoviments(int player, BoardConfiguration configuration)
        {
            if (player == 1)
                return ValidMovimentsPlayer1[configuration];

            if (player == 2)
                return ValidMovimentsPlayer2[configuration];

            throw new NotImplementedException();
        }
    }
}
